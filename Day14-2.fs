module AoC_Mike.Day14_2

open System
open FSharpPlus

type State = {
    Mask : string
    Mem : Map<int64, int64>
}

let initState = {
    Mask = String.Empty
    Mem = Map.empty
}

let applyMask (mask:string) (addr:int64) : int64 list =
    let applyBit (c:char) (i:int) (vs:int64 list) : int64 list =
        match c |> Day14_1.tryCharToInt with
        | Some 0L -> vs
        | Some 1L -> vs |> List.map ((|||) (1L <<< i))
        | _ ->
            (vs |> List.map ((|||) (1L <<< i)))
            @ (vs |> List.map ((&&&) ~~~ (1L <<< i)))
    
    mask
    |> Seq.toList
    |> List.rev
    |> List.mapi (fun i c -> i, c)
    |> List.fold (fun state (i, c) -> state |> applyBit c i) [addr]
    
let parse (state:State) (instruction:string) : State =
    match trySscanf "mask = %s" instruction with
    | Some s -> { state with Mask = s }
    | None ->
        match trySscanf "mem[%i] = %i" instruction with
        | Some (add, num) -> { state with Mem =
                                            add
                                            |> applyMask state.Mask
                                            |> List.fold (fun s v -> s.Add(v, num)) state.Mem }
        | None -> failwith "this shouldn't happen"
        
let puzzle (input:string seq) : int64 =
    input
    |> Seq.fold parse initState
    |> (fun state -> state.Mem |> Map.values |> Seq.sum)