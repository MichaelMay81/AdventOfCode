open AoC2022
open System.IO
open Helpers

[<EntryPoint>]
let main argv =
    let input = "A Y\nB X\nC Z"

    input |> Day2_1.parse |> Day2_1.calcTotalScore |> printfn "%A"
    "../inputs/day2.txt" |> readAllText |> Day2_1.parse |> Day2_1.calcTotalScore |> printfn "%A"

    input |> Day2_2.parse |> Day2_2.calcTotalScore |> printfn "%A"
    "../inputs/day2.txt" |> readAllText |> Day2_2.parse |> Day2_2.calcTotalScore |> printfn "%A"
    0