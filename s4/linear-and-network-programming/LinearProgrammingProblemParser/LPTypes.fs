namespace LinearProgrammingProblemParser.DomainTypes

type X = X of int

type Variable = Variable of int * X

type Expression = Expression of Variable list
with
    member x.Variables = let (Expression x) = x in x

[<RequireQualifiedAccess>]
type Objective =
    | Minimize of Expression
    | Maximize of Expression
    member x.Expression =
        match x with
        | Minimize x
        | Maximize x -> x.Variables

[<RequireQualifiedAccess>]
type Constraint =
    | LessThanOrEqual of Expression * int
    | Equal of Expression * int
    | GreaterThanOrEqual of Expression * int
    member x.Expression =
        match x with
        | LessThanOrEqual (x, _)
        | Equal (x, _)
        | GreaterThanOrEqual (x, _) -> x.Variables
    member x.Value =
        match x with
        | LessThanOrEqual (_, x)
        | Equal (_, x)
        | GreaterThanOrEqual (_, x) -> x

type LinearProgrammingProblem = {
        Objective: Objective
        Constraints: Constraint list
    }

type LPOutput = {
    A: int [,]
    b: int []
    c: int []
    Eqin: int []
    MinMax: int
}
with
    static member Create {Objective = objective; Constraints = constraints} =
        let A, numberOfUnknowns =
            let expressions =
                constraints
                |> List.map (fun x -> x.Expression)
            let numberOfUnknowns = expressions |> Seq.concat |> Seq.map (fun (Variable (_, (X x))) -> x) |> Seq.max |> (+) 1
            let A = Array2D.zeroCreate constraints.Length numberOfUnknowns
            expressions |> List.iteri (fun idx x -> x |> List.iter (fun (Variable(var, X x)) -> Array2D.set A idx x var))
            A, numberOfUnknowns
        let b = constraints |> Seq.map (fun x -> x.Value) |> Array.ofSeq
        let c =
            let c = Array.zeroCreate numberOfUnknowns
            objective.Expression |> List.iter (fun (Variable (var, X x)) -> Array.set c x var)
            c
        let Eqin =
            constraints
            |> Seq.map (function
            | Constraint.LessThanOrEqual _ -> -1
            | Constraint.Equal _ -> 0
            | Constraint.GreaterThanOrEqual _ -> 1)
            |> Array.ofSeq
        let MinMax =
            match objective with
            | Objective.Minimize _ -> -1
            | Objective.Maximize _ -> 1
        {
            A = A
            b = b
            c = c
            Eqin = Eqin
            MinMax = MinMax
        }