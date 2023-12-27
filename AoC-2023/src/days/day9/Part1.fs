module AoC2023.Day9_1

open FSharpPlus

let analyze (input : int list) =
    let rec func (output:int) (input: int list) =
        match input |> List.forall ((=) 0) with
        | true ->
            output
        | false ->
            input
            |> List.pairwise
            |> List.map (fun (v1,v2) -> v2 - v1)
            |> func (output + (input |> List.last)) 
    
    func 0 input

let puzzle (input : string seq) =
    input
    |> Seq.map (
        String.split [" "]
        >> Seq.toList
        >> List.map int
        >> analyze)
    |> Seq.sum