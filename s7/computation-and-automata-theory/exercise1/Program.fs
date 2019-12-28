// University of Macedonia,
// Department of Applied Informatics,
// Semester 7,
// Computation & Automata Theory,
// Assignment 1

// Created by: Theodore Tsirpanis
// Professor: Ioannis Refanidis

open System
open System.Collections.Generic

/// The state of an FA.
type FAState = {
    /// Whether this state is an accepting one.
    IsAccept: bool
    /// A tree map matching a character to a set of possible state indices.
    // Because types in F# are immutable, we have to store the state index.
    Edges: Map<char, int list>
    /// The indices of all the states that are connected to this one via
    /// an ε (epsilon) transition.
    EpsilonTransitions: int list
}
with
    /// A wrapper for the `Edges` field, but returns an
    /// empty set if no state can be reached from the given character.
    member x.GetNextStates c =
        match x.Edges.TryGetValue(c) with
        | true, states -> states
        | false, _ -> []

/// A Finite Automaton.
type FA = {
    /// The FA's initial state.
    InitialState: int
    /// The FA's states.
    States: FAState[]
}

/// Gets the `FAState` with the given `FAStateIndex`, from the given `FA`.
let getState {States = fsStates} stateIdx =
    fsStates.[stateIdx]

/// Computes the ε-closure of the given FA states.
// It accepts _a sequence of states_ to avoid wasteful computations.
let EClosure fa states =
    let visited = HashSet()
    let q = Queue(seq states)
    while q.Count <> 0 do
        let state = q.Dequeue()
        if visited.Add(state) then
            state.EpsilonTransitions
            |> List.iter (getState fa >> q.Enqueue)
    Seq.readonly visited

/// Gets the next FA states when encountering the given character.
let faAdvance fa states c =
    states
    |> EClosure fa
    |> Seq.collect (fun state -> state.GetNextStates(c))
    |> Seq.map (getState fa)
    |> set

/// Decides whether the given `FA` recognizes the given string.
let faMatch fa =
    // A dictionary is created only once per `FA`.
    // This allows memoization to persist past the
    // recognition of a string. But we have to pertially
    // apply this function, as we will see later.
    // Also, the dictionary is not thread-safe,
    // but we don't care for such a small program.
    let dict = Dictionary()
    let rec impl states str i =
        // We can terminate prematurely when the
        // set of the states is empty; we will
        // never recover from it.
        if Set.isEmpty states then
            false
        elif i = String.length str then
            // An NFA has accepted a string if it
            // is in at least one accepting state.
            states |> Set.exists (fun state -> state.IsAccept)
        else
            let newStates =
                let c = str.[i]
                // There is no reason to compute the
                // next states if we have ever been there before.
                match dict.TryGetValue((states, c)) with
                | true, newStates -> newStates
                | false, _ ->
                    let newStates = faAdvance fa states c
                    dict.Add((states, c), newStates)
                    newStates
            // This tail-recursive call is compiled into a while loop.
            impl newStates str (i + 1)
    let initialState = getState fa fa.InitialState |> Set.singleton
    fun str -> impl initialState str 0

/// Reads a Finite Automaton from the console.
let faRead() =
    let readInt() = Console.ReadLine() |> int
    // This active pattern converts the one-based string indices
    // from the input to zero-based integers for the program.
    let inline (|OneBasedInt|) str = int str - 1

    eprintf "How many states are there in the automaton? "
    let statesCount = readInt()
    let transitions = Array.create statesCount []
    let epsilonTransitions = Array.create statesCount []
    let acceptingStates = Array.create statesCount false

    eprintf "Which of them is the initial state? "
    let (OneBasedInt initialState) = readInt() - 1

    if initialState < 0 || initialState >= statesCount then
        failwithf "The state number must be between 1 and %d" statesCount

    eprintf "How many accepting states are there? "
    readInt() |> ignore

    eprintf "Write the accepting state numbers separated by a space: "
    Console.ReadLine().Split(' ')
    |> Array.iter(fun (OneBasedInt idx) -> acceptingStates.[idx] <- true)

    eprintf "How many transitions are there? "
    let transitionCount = readInt()

    eprintfn "Now, write each transition as follows: <state from> <character to encounter> <state to>."
    eprintfn "For ε-transitions, omit the character to encounter."
    eprintfn "The indices are one-based."
    for __ = 1 to transitionCount do
        match Console.ReadLine().Split(' ') with
        | [|OneBasedInt sFrom; c; OneBasedInt sTo|] ->
            // The transition is a normal one with a symbol.
            transitions.[sFrom]<- (char c, sTo) :: transitions.[sFrom]
        | [|OneBasedInt sFrom; OneBasedInt sTo|] ->
            // The transition lacks a symbol, therefore it is an ε-transition.
            epsilonTransitions.[sFrom] <- sTo :: epsilonTransitions.[sFrom]
        | _ -> failwith "Invalid input"
    let states = Array.init statesCount (fun idx ->
        let transitions =
            transitions.[idx]
            |> List.groupBy fst
            |> Seq.map (fun (c, states) -> c, List.map snd states)
            |> Map.ofSeq
        {IsAccept = acceptingStates.[idx]; Edges = transitions; EpsilonTransitions = epsilonTransitions.[idx]})
    {InitialState = initialState; States = states}

/// A little helper that writes colored text to the console.
let printColor color str =
    let oldColor = Console.ForegroundColor
    try
        Console.ForegroundColor <- color
        printf "%s" str
    finally
        Console.ForegroundColor <- oldColor

/// Interactively asks strings from the user and
/// checks whether they are recognized by the given `FA`.
let faInteractive fa =
    // We pass only the `FA` object to `faMatch`.
    // We got a function that gets a string.
    let fMatch = faMatch fa
    let rec loop() =
        match Console.ReadLine() with
        | null -> ()
        | str ->
            let isMatch = fMatch str
            printf "%s: " str
            if isMatch then
                printColor ConsoleColor.Green "SUCCESS\n"
            else
                printColor ConsoleColor.Red "FAILURE\n"
            loop()
    eprintfn "Write the strings you want to check against your Finite Automaton, each per line."
    // https://stackoverflow.com/questions/11968558/
    let eofCharacter = if Environment.OSVersion.Platform = PlatformID.Win32NT then 'Z' else 'D'
    eprintfn "To stop, press Ctrl+%c." eofCharacter
    loop()

[<EntryPoint>]
let main _args =
    eprintfn "This is a simulator for Finite Automata."
    eprintfn "Created by Theodore Tsirpanis (dai19090)."
    eprintfn ""
    let fa = faRead()
    eprintfn ""
    faInteractive fa
    0
