module AoC2022.Day3

open Helpers
#nowarn "25"

let toPriority (c:char) : int =
    c |> int
    |> fun i ->
        if i > 96 then i - 96
        else i - 64 + 26

let puzzle1 (input : string seq) =
    input
    |> Seq.map (fun seq -> seq, (seq |> Seq.length) / 2)
    |> Seq.map (fun (seq, lengthHalf) ->
        seq |> Seq.take lengthHalf,
        seq |> Seq.skip lengthHalf)
    |> Seq.map (fun (s1, s2) -> intersect s1 s2)
    |> Seq.map (Seq.distinct)
    |> Seq.concat
    |> Seq.map(toPriority)
    |> Seq.sum

let puzzle2 (input : string seq) =
    input
    |> Seq.chunkBySize 3
    |> Seq.map (
        List.ofArray
        >> fun (head::tail) -> Seq.fold intersect head tail
        >> Seq.distinct)
    |> Seq.concat
    |> Seq.map(toPriority)
    |> Seq.sum