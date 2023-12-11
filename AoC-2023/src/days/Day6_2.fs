module AoC2023.Day6_2

open FSharpPlus
open Day6_1

let parse (input : string seq) =
    (input
        |> Seq.head
        |> sscanf "Time: %s"
        |> String.replace " " ""
        |> int64,
    input
        |> Seq.skip 1
        |> Seq.head
        |> sscanf "Distance: %s"
        |> String.replace " " ""
        |> int64)
    |> (fun (time, distance) ->
        Time time, Distance distance)

let puzzle (input : string seq) =
    input
    |> parse
    |> uncurry analyze