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
        |> terminal "X" (T(fun _ data -> Int32.Parse(data.Slice(1)) |> X.Create))

    let expression =
        let mkProduction (firstPlus: ProductionBuilder) name =
            name ||= [
                firstPlus .>>. number .>>. X => (fun num x -> Variable(num, x))
                !& "-" .>>. number .>>. X => (fun num x -> Variable(-num, x))
                !& "+" .>>. X  => (fun x -> Variable(1, x))
                !& "-" .>>. X => (fun x -> Variable(-1, x))
            ]
        let firstExpression = mkProduction empty "First Expression"
        let moreExpressions = mkProduction (!& "+") "More Expressions"

        "Expression" ||= [
            !@ firstExpression .>>. many moreExpressions => (fun x xs ->
                x :: xs |> Expression)
        ]

    let objective = "Objective" ||= [
        !& "min" .>>. expression => Objective.Minimize
        !& "max" .>>. expression => Objective.Maximize
    ]

    let constraints =
        "Subject To" ||= [
            !@ expression .>> "=" .>>. number => (curry Constraint.Equal)
            !@ expression .>> "<=" .>>. number => (curry Constraint.LessThanOrEqual)
            !@ expression .>> ">=" .>>. number => (curry Constraint.GreaterThanOrEqual)
        ] |> many1

    "Linear Programming Problem" ||= [!@ objective .>> ST .>>. constraints => (fun o c ->
        {Objective = o; Constraints = c})]

let runtime = RuntimeFarkle.build designtime
