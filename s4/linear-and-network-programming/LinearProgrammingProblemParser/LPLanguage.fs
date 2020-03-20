module LinearProgrammingProblemParser.Language

open Farkle
open Farkle.Builder
open Farkle.Builder.Regex
open LinearProgrammingProblemParser.DomainTypes
open System

let inline private curry f x1 x2 = f(x1, x2)

let designtime =
    let number = Terminals.genericUnsigned<Number> "Number"
    let ST =
        ["st"; "s.t."; "μπ"; "μ.π."]
        |> List.map string
        |> choice
        |> terminal "ST" (T(fun _ _ -> ()))
    let X =
        char 'x' <&> (atLeast 1 <| chars PredefinedSets.Number)
        |> terminal "X" (T(fun _ data -> Int32.Parse(data.Slice(1)) |> X))

    let expression =
        let mkVariable isFirstVariable name =
            name ||= [
                if isFirstVariable then
                    !@ number .>>. X => (fun num x -> Variable(num, x))
                !& "+" .>>. number .>>. X => (fun num x -> Variable( num, x))
                !& "-" .>>. number .>>. X => (fun num x -> Variable(-num, x))
                !& "+"             .>>. X => (fun     x -> Variable( 1  , x))
                !& "-"             .>>. X => (fun     x -> Variable(-1  , x))
            ]
        let firstExpression = mkVariable true  "First Variable"
        let moreExpressions = mkVariable false "More Variables"

        "Expression" ||= [
            !@ firstExpression .>>. many moreExpressions => (fun x xs -> x :: xs |> Expression)
        ]

    let objective = "Objective" ||= [
        !& "min" .>>. expression => Objective.Minimize
        !& "max" .>>. expression => Objective.Maximize
    ]

    let signedNumber = "Signed Number" ||= [
        !@ number => id
        !& "+" .>>. number => id
        !& "-" .>>. number => (~-)
    ]

    let constraints =
        "Subject To" ||= [
            !@ expression .>> "="  .>>. signedNumber => (curry Constraint.Equal)
            !@ expression .>> "<=" .>>. signedNumber => (curry Constraint.LessThanOrEqual)
            !@ expression .>> ">=" .>>. signedNumber => (curry Constraint.GreaterThanOrEqual)
        ] |> many1

    let endMaybe = "End Maybe" ||= [
        !& "end" =% ()
        empty =% ()
    ]

    "Linear Programming Problem" ||= [
        !@ objective .>> ST .>>. constraints .>> endMaybe => (fun o c -> {Objective = o; Constraints = c})
    ]
    // LINDO's comments are line-based and start with an exclamation mark.
    |> DesigntimeFarkle.addLineComment "!"

let runtime = RuntimeFarkle.build designtime
