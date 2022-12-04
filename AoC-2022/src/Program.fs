open AoC2022
// open System.IO
open Helpers

[<EntryPoint>]
let main argv =
    let input = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8"            .Split "\n"

    input |> Day4.puzzle1 |> printfn "%A"
    "../inputs/day4.txt" |> readAllLines |> Day4.puzzle1 |> printfn "%A"
    
    input |> Day4.puzzle2 |> printfn "%A"
    "../inputs/day4.txt" |> readAllLines |> Day4.puzzle2 |> printfn "%A"
    0