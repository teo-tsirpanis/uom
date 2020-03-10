// University of Macedonia,
// Department of Applied Informatics,
// Semester 4,
// Linear & Network Programming,
// Assignment 1
//
// Created by: Theodore Tsirpanis
// Professor: Nikolaos Samaras

open Farkle
open LinearProgrammingProblemParser
open System.IO

let readInput argv =
    if Array.length argv >= 1 then
        let fDebug msg =
            if argv.Length >= 2 && argv.[1] = "--debug" then
                eprintfn "PARSER LOG: %O" msg
        Ok(File.ReadAllText(argv.[0]), fDebug)
    else
        Error "Invalid CLI arguments. Try <program name> filename [--debug]"

let parseIt (input, fDebug) =
    match RuntimeFarkle.parseString Language.runtime fDebug input with
    | Ok x -> Ok <| DomainTypes.LPPWithMatrices.Create x
    | Error err -> Error <| string err

[<EntryPoint>]
let main args =
    readInput args
    |> Result.bind parseIt
    |> function
    | Ok x ->
        eprintfn "Success."
        printfn "%A" x
        0
    | Error x ->
        printfn "%s" x
        1
