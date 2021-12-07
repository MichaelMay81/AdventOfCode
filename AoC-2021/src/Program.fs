open AoC2021
open AoC2021.Helpers
open Day5
open System

open FSharpPlus

[<EntryPoint>]
let main argv =
    let input1 = [3;4;3;1;2]

    // input1
    // |> Day6.puzzle1 2
    // |> printfn "%A" // 26

    input1
    |> Day6.puzzle1 18
    |> printfn "%A" // 26

    input1
    |> Day6.puzzle1 80
    |> printfn "%A" // 5934

    getPuzzleInput "../inputs/Day6.txt"
    |> Seq.head
    |> String.split [","]
    |> Seq.map int
    |> Seq.toList
    |> Day6.puzzle1 80
    |> printfn "%A" // 390923

    input1
    |> Day6.puzzle1 256
    |> printfn "%A" // 

    getPuzzleInput "../inputs/Day6.txt"
    |> Seq.head
    |> String.split [","]
    |> Seq.map int
    |> Seq.toList
    |> Day6.puzzle1 256
    |> printfn "%A"

    0 // return an integer exit code