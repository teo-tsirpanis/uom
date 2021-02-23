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
}

let readInput argv =
    match argv with
    | [| input |] -> Ok {InputFile = input; OutputFile = None}
    | [| input; output |] -> Ok {InputFile = input; OutputFile = Some output}
    | _ -> Error "Invalid command-line arguments. Try <program name> input [output]"

let parseIt args =
    RuntimeFarkle.parseFile Parser.runtime args.InputFile
    |> Result.mapError string

[<EntryPoint>]
let main args =
    args
    |> readInput
    |> Result.bind (fun args ->
        args
        |> parseIt
        |> Result.bind (fun lpp ->
            let out =
                match args.OutputFile with
                | Some path -> new StreamWriter(path) :> TextWriter
                | None -> Console.Out
            try
                let primal = DomainTypes.LPPWithMatrices.Create lpp
                out.WriteLine "The primal problem is:"
                out.WriteLine(Formatter.formatLPPWithMatrices 'x' primal)
                let dual = primal.Dual()
                out.WriteLine "Its dual is:"
                out.WriteLine(Formatter.formatLPPWithMatrices 'w' dual)
                let dualDual = dual.Dual()
                if dualDual = primal then
                    eprintfn "The dual's dual is equal to the primal as expected."
                    Ok ()
                else
                    Error "Error: The dual's dual is not equal to the primal."
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
