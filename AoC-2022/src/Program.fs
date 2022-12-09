open AoC2022
open Helpers
open FSharpPlus
// open FParsec

[<EntryPoint>]
let main _ =
    let input = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2"

    input |> Day9_1.puzzle1 |> printfn "%i"
    "../inputs/day9.txt" |> readAllText |> Day9_1.puzzle1 |> printfn "%i"

    0