open AoC2022
open Helpers
open FSharpPlus
// open FParsec

[<EntryPoint>]
let main _ =
    let input = @"30373
25512
65332
33549
35390"

    input |> Day8_1.puzzle1 |> printfn "%A"
    "../inputs/day8.txt" |> readAllText |> Day8_1.puzzle1 |> printfn "%A"

    input |> Day8_2.puzzle2 |> printfn "%A"
    "../inputs/day8.txt" |> readAllText |> Day8_2.puzzle2 |> printfn "%A"

    0