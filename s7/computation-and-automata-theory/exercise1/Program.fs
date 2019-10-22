// University of Macedonia,
// Department of Applied Informatics,
// Semester 7,
// Computation & Automata Theory,
// Assignment 1

// Created by: Theodore Tsirpanis
// Professor: Ioannis Refanidis

open System
open System.Collections

type FAStateIndex = FAStateIndex of int

type FAState = {
    IsAccept: bool
    Edges: Map<char, FAStateIndex Set>
    EpsilonTransitions: FAStateIndex Set
}
with
    member x.GetNextStates c =
        match x.Edges.TryGetValue(c) with
        | true, states -> states
        | false, _ -> Set.empty

type FA = {
    InitialState: FAStateIndex
    States: FAState[]
}

let getState {States = fsStates} (FAStateIndex stateIdx) =
    fsStates.[stateIdx]

let EClosure fa states =
    let visited = HashSet()
    let q = Queue(states)
    while q.Count <> 0 do
        let state = q.Dequeue()
        if visited.Add(state) then
            state.EpsilonTransitions
            |> Set.iter (getState fa >> q.Enqueue)
    set visited

let faAdvance fa states c =
    states
    |> EClosure
    |> Seq.map (fun state -> state.GetNextStates(c))
    |> Set.unionMany

let faMatch fa str =
    let dict = Dictionary()
    let rec impl states i =
        if i = String.length str then
            states |> Set.exists (fun state -> state.IsAccept)
        else
            let newStates =
                let c = str.[i]
                match dict.TryGetValue((states, c)) with
                | true, newStates -> newStates
                | false, _ ->
                    let newStates = faAdvance fa states c
                    dict.Add((states, c), newStates)
                    newStates
            impl newStates (n + 1)
    impl (Set.singleton fa.InitialState) 0
