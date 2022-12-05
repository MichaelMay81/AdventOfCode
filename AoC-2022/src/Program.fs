open AoC2022
// open System.IO
open Helpers

[<EntryPoint>]
let main argv =
    let input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2"

    input |> Day5.puzzle1 |> printfn "%A"
    "../inputs/day5.txt" |> readAllText |> Day5.puzzle1 |> printfn "%A"
    
    input |> Day5.puzzle2 |> printfn "%A"
    "../inputs/day5.txt" |> readAllText |> Day5.puzzle2 |> printfn "%A"
    0