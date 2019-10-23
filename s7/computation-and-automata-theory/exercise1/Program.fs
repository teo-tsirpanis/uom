// University of Macedonia,
// Department of Applied Informatics,
// Semester 7,
// Computation & Automata Theory,
// Assignment 1

// Created by: Theodore Tsirpanis
// Professor: Ioannis Refanidis

open System.Collections.Generic

/// A strongly typed index of a Finite Automaton (FA) state.
type FAStateIndex = FAStateIndex of int

/// The state of an FA.
type FAState = {
    /// Whether this state is an accepting one.
    IsAccept: bool
    /// A tree map matching a character to a set of possible state indices.
    // Because types in F# are immutable, we have to store the state index.
    Edges: Map<char, FAStateIndex Set>
    /// The indices of all the states that are connected to this one via
    /// an ε (epsilon) transition.
    EpsilonTransitions: FAStateIndex Set
}
with
    /// A wrapper for the `Edges` field, but returns an
    /// empty set if no state can be reached from the given character.
    member x.GetNextStates c =
        match x.Edges.TryGetValue(c) with
        | true, states -> states
        | false, _ -> Set.empty

/// A Finite Automaton.
type FA = {
    /// The FA's initial state.
    InitialState: FAStateIndex
    /// The FA's states.
    States: FAState[]
}

/// Gets the `FAState` with the given `FAStateIndex`, from the given `FA`.
let getState {States = fsStates} (FAStateIndex stateIdx) =
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
            |> Set.iter (getState fa >> q.Enqueue)
    set visited

/// Gets the next FA states when encountering the given character.
let faAdvance fa states c =
    states
    |> EClosure fa
    |> Seq.collect (fun state -> state.GetNextStates(c))
    |> Seq.map (getState fa)
    |> set

/// Decides whether the given `FA` recognizes the given string.
let faMatch fa str =
    let dict = Dictionary()
    let rec impl states i =
        if i = String.length str then
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
            impl newStates (i + 1)
    let initialState = getState fa fa.InitialState |> Set.singleton
    impl initialState 0
