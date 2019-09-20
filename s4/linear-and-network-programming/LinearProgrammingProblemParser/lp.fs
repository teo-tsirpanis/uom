module LinearProgrammingProblemParser.Grammar

open Farkle
open Farkle.PostProcessor
open LinearProgrammingProblemParser.DomainTypes
open System

//#region Grammar types

type Symbol =
/// (EOF)
| EOF                      =  0u
/// (Error)
| Error                    =  1u
/// Whitespace
| Whitespace               =  2u
/// '-'
| Minus                    =  3u
/// '+'
| Plus                     =  4u
/// '<='
| LtEq                     =  5u
/// '='
| Eq                       =  6u
/// '>='
| GtEq                     =  7u
/// max
| max                      =  8u
/// min
| min                      =  9u
/// Number
| Number                   = 10u
/// ST
| ST                       = 11u
/// X
| X                        = 12u

type Production =
/// <Expression Loop> ::= '+' Number X <Expression Loop>
| ExpressionLoopPlusNumberX  =  0u
/// <Expression Loop> ::= '-' Number X <Expression Loop>
| ExpressionLoopMinusNumberX =  1u
/// <Expression Loop> ::= '+' X <Expression Loop>
| ExpressionLoopPlusX        =  2u
/// <Expression Loop> ::= '-' X <Expression Loop>
| ExpressionLoopMinusX       =  3u
/// <Expression Loop> ::=
| ExpressionLoop             =  4u
/// <Expression> ::= Number X <Expression Loop>
| ExpressionNumberX          =  5u
/// <Expression> ::= '-' Number X <Expression Loop>
| ExpressionMinusNumberX     =  6u
/// <Expression> ::= '+' X <Expression Loop>
| ExpressionPlusX            =  7u
/// <Expression> ::= '-' X <Expression Loop>
| ExpressionMinusX           =  8u
/// <Objective> ::= min <Expression>
| Objectivemin               =  9u
/// <Objective> ::= max <Expression>
| Objectivemax               = 10u
/// <Subject To> ::= <Expression> '=' Number
| SubjectToEqNumber          = 11u
/// <Subject To> ::= <Expression> '<=' Number
| SubjectToLtEqNumber        = 12u
/// <Subject To> ::= <Expression> '>=' Number
| SubjectToGtEqNumber        = 13u
/// <Constraints Loop> ::= <Subject To> <Constraints Loop>
| ConstraintsLoop            = 14u
/// <Constraints Loop> ::=
| ConstraintsLoop2           = 15u
/// <Constraints> ::= <Subject To> <Constraints Loop>
| Constraints                = 16u
/// <Linear Programming Problem> ::= <Objective> ST <Constraints>
| LinearProgrammingProblemST = 17u

//#endregion

open Fuser

let inline private curry f x1 x2 = f(x1, x2)

///
let TheRuntimeFarkle =
    // The transformers convert terminals to anything you want.
    // If you don't care about a terminal (like single characters),
    // you can remove it from below. It will be automatically ignored.
    // And symbols other than terminals are automatically ignored,
    // even if they are listed below.
    let transformers =
        [
            Transformer.int Symbol.Number
            // According to the specification, x starts from one.
            Transformer.create Symbol.X <| C (fun x -> X <| Int32.Parse(x.Slice(1)) - 1)
        ]
    // The fusers merge the parts of a production into one object of your desire.
    // Do not delete anything here, or the post-processor will fail.
    let fusers =
        [
            take3Of Production.ExpressionLoopPlusNumberX (1, 2, 3) 4 (fun num x xs -> Variable(num, x) :: xs)
            take3Of Production.ExpressionLoopMinusNumberX (1, 2, 3) 4 (fun num x xs -> Variable(-num, x) :: xs)
            take2Of Production.ExpressionLoopPlusX (1, 2) 3 (fun x xs -> Variable(1, x) :: xs)
            take2Of Production.ExpressionLoopMinusX (1, 2) 3 (fun x xs -> Variable(-1, x) :: xs)
            constant<Variable list> (int Production.ExpressionLoop) 0 []
            create3 Production.ExpressionNumberX (fun num x xs -> Variable(num, x) :: xs |> Expression)
            take3Of Production.ExpressionMinusNumberX (1, 2, 3) 4 (fun num x xs -> Variable(-num, x) :: xs |> Expression)
            take2Of Production.ExpressionPlusX (1, 2) 3 (fun x xs -> Variable(1, x) :: xs |> Expression)
            take2Of Production.ExpressionMinusX (1, 2) 3 (fun x xs -> Variable(-1, x) :: xs |> Expression)
            take1Of Production.Objectivemin 1 2 Objective.Minimize
            take1Of Production.Objectivemax 1 2 Objective.Maximize
            take2Of Production.SubjectToEqNumber (0, 2) 3 (curry Constraint.Equal)
            take2Of Production.SubjectToLtEqNumber (0, 2) 3 (curry Constraint.LessThanOrEqual)
            take2Of Production.SubjectToGtEqNumber (0, 2) 3 (curry Constraint.GreaterThanOrEqual)
            create2 Production.ConstraintsLoop (fun (x: Constraint) xs -> x :: xs)
            constant<Constraint list> (int Production.ConstraintsLoop2) 0 []
            create2 Production.Constraints (fun (x: Constraint) xs -> x :: xs)
            take2Of Production.LinearProgrammingProblemST (0, 2) 3 (fun objective constraints -> {Objective = objective; Constraints = constraints})
        ]
    RuntimeFarkle.ofEGTFile
        (PostProcessor.ofSeq<LinearProgrammingProblem> transformers fusers)
        "lp.egt"
