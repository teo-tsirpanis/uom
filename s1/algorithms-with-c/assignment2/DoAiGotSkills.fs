// © by Theodore Tsirpanis

open FsCheck
open LanguagePrimitives
open System
open System.Diagnostics
open System

type ProblemDomain = {
    Employees: int Set list
    SkillsCount: int
}
with
    override x.ToString() =
        x.Employees
        |> Seq.mapi (fun idx x -> x |> Seq.map string |> String.concat"; " |> sprintf "%d: %s" (idx + 1))
        |> String.concat Environment.NewLine

let solveIt {Employees = allEmployees; SkillsCount = skillsCount} =
    let approximateBest =
        let rec impl employees forHire skills =
            if Set.count skills = skillsCount then
                forHire
            else
                let bestEmployee = employees |> Seq.maxBy (fun x -> Set.difference x skills)
                impl (Set.remove bestEmployee employees) (Set.add bestEmployee forHire) (Set.union bestEmployee skills)
        impl (set allEmployees) Set.empty Set.empty |> Set.count
    // List length is expensive.
    let employeesCount = uint32 <| List.length allEmployees
    let rec backTrackIt employees forHire skills idx limit =
        match employees with
        | _ when Set.count skills = skillsCount -> forHire
        | [] -> set [1u .. employeesCount]
        | _ when Set.count forHire = limit -> set [1u .. employeesCount]
        | employeeForHire :: employees ->
            let notHired = backTrackIt employees forHire skills (idx + 1u) limit
            let limit =
                if Set.count notHired < limit then
                    Set.count notHired
                else
                    limit
            if Set.isSubset employeeForHire skills then
                notHired
            else
                [
                    notHired

                    backTrackIt
                        employees
                        (Set.add idx forHire)
                        (Set.union employeeForHire skills)
                        (idx + 1u)
                        limit
                ] |> List.minBy Set.count
    backTrackIt allEmployees Set.empty Set.empty 1u approximateBest


let problemDomainGen employees skills =
    Gen.choose (1, skills)
    |> Gen.nonEmptyListOf
    |> Gen.map set
    |> Gen.listOfLength employees
    |> Gen.map (fun x -> {Employees = x; SkillsCount = skills})

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
    printfn "%O" domain
    sw.Start()
    let result = solveIt domain
    sw.Stop()
    printfn "Solution: %A" result
    printfn "Elapsed time: %O" sw.Elapsed
    0