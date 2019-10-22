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

type FA = {
    InitialState: FAStateIndex
    States: FAState[]
}

let getState {States = fsStates} (FAStateIndex stateIdx) =
    fsStates.[stateIdx]

let EClosure fa state =
    let visited = HashSet()
    let q = Queue()
    q.Enqueue(getState fa state)
    while q.Count <> 0 do
        let state = q.Dequeue()
        if visited.Add(state) then
            state.EpsilonTransitions
            |> Set.iter (getState fa >> q.Enqueue)
    set visited
