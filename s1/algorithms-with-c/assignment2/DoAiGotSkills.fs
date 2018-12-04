// © by Theodore Tsirpanis

open FsCheck
open LanguagePrimitives
open System
open System.Diagnostics

type ProblemDomain = {
    Employees: (int * int Set) list
    AllSkills: int Set
}

let tryLeast =
    function
    | [] -> None
    | x -> x |> List.minBy Set.count |> Some

let solveIt {Employees = employees; AllSkills = allSkills} =
    let mutable minTries = employees.Length
    let rec impl hired skills =
        function
        | _ when Set.count hired > minTries -> None
        | _ when skills = allSkills ->
            minTries <- Set.count hired
            Some hired
        | [] -> None
        | (emp, skill) :: xs ->
            let fDontHireHim() = impl hired skills xs
            let fHireHim() = impl (Set.add emp hired) (Set.union skill skills) xs
            if Set.isSubset skill skills then
                fDontHireHim()
            else
                [
                    fHireHim()
                    fDontHireHim()
                ]
                |> List.choose id
                |> tryLeast
    impl Set.empty Set.empty employees

let problemDomainGen employees skills =
    Gen.choose (1, skills)
    |> Gen.nonEmptyListOf
    |> Gen.map set
    |> Gen.listOfLength employees
    |> Gen.map (List.mapi (fun idx x -> idx + 1, x))
    |> Gen.map (fun x -> {Employees = x; AllSkills = set [1 .. skills]})

let sample1 =
    [
        [5; 6]
        [2; 3]
        [1; 3]
        [1; 2]
        [2; 4; 6]
        [4; 6]
    ]
    |> List.mapi (fun idx x -> idx + 1, set x)

let allSkills1 = set [1 .. 6]

let tryGetInt def args idx =
    let impl x =
        let mutable v = 0
        if x <> "" && Int32.TryParse(x, &v) then
            Some v
        else
            None
    Array.tryItem idx args |> Option.defaultValue "" |> impl |> Option.defaultValue def

[<EntryPoint>]
let main args =
    let employees = tryGetInt 6 args 0
    let skills = tryGetInt employees args 1
    printfn "%d skills are needed, and there are %d employees available..." skills employees
    let sw = Stopwatch()
    let domain = Gen.eval skills (Random.newSeed()) (problemDomainGen employees skills)
    printfn "%A" domain.Employees
    sw.Start()
    let result = solveIt domain
    sw.Stop()
    printfn "Solution: %A" result
    printfn "Elapsed time: %O" sw.Elapsed
    0