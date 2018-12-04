// © by Theodore Tsirpanis
let tryMax =
    function
    | [] -> None
    | x -> List.max x |> Some

let solveIt employees allSkills =
    let rec impl hired skills =
        function
        | _ when skills = allSkills -> Some hired
        | [] -> None
        | (emp, skill) :: xs ->
            [
                impl hired skills xs
                impl (Set.add emp hired) (Set.union skill skills) xs
            ]
            |> List.choose id
            |> tryMax
    impl Set.empty Set.empty employees

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