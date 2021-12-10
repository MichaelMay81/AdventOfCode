open AoC2021
open AoC2021.Helpers
open FSharp.Collections

open FSharpPlus

[<EntryPoint>]
let main argv =
    let input1 = [
        [2;1;9;9;9;4;3;2;1;0]
        [3;9;8;7;8;9;4;9;2;1]
        [9;8;5;6;7;8;9;8;9;2]
        [8;7;6;7;8;9;6;7;8;9]
        [9;8;9;9;9;6;5;6;7;8]
    ]

    input1
    |> Day9.puzzle1
    |> printfn "%A" // 15

    getPuzzleInput "../inputs/Day9.txt"
    |> Seq.map (fun str -> str |> Seq.map (string >> int) |> Seq.toList)
    |> Seq.toList
    |> Day9.puzzle1
    |> printfn "%A" // 239

    input1
    |> Day9.puzzle2
    |> printfn "%A" // 1134

    getPuzzleInput "../inputs/Day9.txt"
    |> Seq.map (fun str -> str |> Seq.map (string >> int) |> Seq.toList)
    |> Seq.toList
    |> Day9.puzzle2
    |> printfn "%A" // 1045660

    0 // return an integer exit code