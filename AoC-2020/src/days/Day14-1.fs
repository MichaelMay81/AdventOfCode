module AoC2020.Day14_1

open System
open FSharpPlus

type State = {
    Mask : string
    Mem : Map<int, int64>
}

let initState = {
    Mask = String.Empty
    Mem = Map.empty
}

let tryCharToInt (c:char) : int64 option =
        try
            Some (int64 (string c))
        with
        | :? FormatException -> None

let applyMask (mask:string) (value:int64) : int64 =
    let applyBit (c:char) (i:int) (v:int64) : int64 =
        match c |> tryCharToInt with
        | Some 1L -> v ||| (1L <<< i)
        | Some 0L -> v &&& ~~~ (1L <<< i)
        | _ -> v
    
    mask
    |> Seq.toList
    |> List.rev
    |> List.mapi (fun i c -> i, c)
    |> List.fold (fun state (i, c) -> state |> applyBit c i) value
    
let parse (state:State) (instruction:string) : State =
    match trySscanf "mask = %s" instruction with
    | Some s -> { state with Mask = s }
    | None ->
        match trySscanf "mem[%i] = %i" instruction with
        | Some (add, num) -> { state with Mem = state.Mem.Add(add, applyMask state.Mask num) }
        | None -> failwith "this shouldn't happen"
        
let puzzle (input:string seq) : int64 =
    input
    |> Seq.fold parse initState
    |> (fun state -> state.Mem |> Map.values |> Seq.sum)