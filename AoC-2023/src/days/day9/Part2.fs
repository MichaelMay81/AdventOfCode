module AoC2023.Day9_2

open FSharpPlus

let analyze (input : int list) =
    let rec func (output:int list) (input: int list) =
        match input |> List.forall ((=) 0) with
        | true ->
            output
        | false ->
            input
            |> List.pairwise
            |> List.map (fun (v1,v2) -> v2 - v1)
            |> func ((input |> List.head)::output) 
    
    func [] input
    |> List.reduce (fun val2 val1 -> val1 - val2)

let puzzle (input : string seq) =
    input
    |> Seq.map (
        String.split [" "]
        >> Seq.toList
        >> List.map int
        >> analyze)
    |> Seq.toList
    |> Seq.sum