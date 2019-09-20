open Farkle
open LinearProgrammingProblemParser
open LinearProgrammingProblemParser.DomainTypes
open System.IO

let readInput argv =
    if Array.length argv >= 1 then
        let fDebug = if argv.Length > 2 && argv.[1] = "--debug" then eprintfn "PARSER LOG: %O" else ignore
        Ok(File.ReadAllText(argv.[0]), fDebug)
    else Error "Invalid CLI arguments. Try <program name> filename [--debug]"

let parseIt (input, fDebug) =
    RuntimeFarkle.parseString Grammar.TheRuntimeFarkle fDebug input
    |> Result.mapError (sprintf "Error while parsing the problem statement: %O")
    |> Result.map (LPOutput.Create)

[<EntryPoint>]
let main args =
    readInput args
    |> Result.bind parseIt
    |> function
    | Ok x ->
        printfn "Success."
        printfn "%A" x
        0
    | Error x ->
        printfn "%s" x
        1
