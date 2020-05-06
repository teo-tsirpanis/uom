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
open System
open System.IO

type CommandLineArguments = {
    InputFile: string
    OutputFile: string option
    DebugMode: bool
}

let readInput argv =
    match argv with
    | [| input |] -> Ok {InputFile = input; OutputFile = None; DebugMode = false}
    | [| input; "--debug" |] -> Ok {InputFile = input; OutputFile = None; DebugMode = true}
    | [| input; output |] -> Ok {InputFile = input; OutputFile = Some output; DebugMode = false}
    | [| input; output; "--debug" |] -> Ok {InputFile = input; OutputFile = Some output; DebugMode = true}
    | _ -> Error "Invalid command-line arguments. Try <program name> input [output] [--debug]"

let parseIt args =
    let fDebug = if args.DebugMode then eprintfn "%O" else ignore
    RuntimeFarkle.parseFile Language.runtime fDebug args.InputFile
    |> Result.mapError string

[<EntryPoint>]
let main args =
    args
    |> readInput
    |> Result.bind (fun args ->
        args
        |> parseIt
        |> Result.map (fun lpp ->
            let out =
                match args.OutputFile with
                | Some path -> new StreamWriter(path) :> TextWriter
                | None -> Console.Out
            try
                let lppStr = DomainTypes.LPPWithMatrices.Create(lpp).Format()
                fprintfn out "%s" lppStr
            finally
                if args.OutputFile.IsSome then
                    out.Dispose()
        )
    )
    |> function
    | Ok () ->
        eprintfn "Success."
        0
    | Error x ->
        eprintfn "%s" x
        1
