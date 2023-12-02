open AoC2023
open BenchmarkDotNet.Running

let input1 =
    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"

// input1 |> Day1_1.parse |> Seq.map Day2.parseLine |> Day2.puzzle 12 13 14 |> printfn "%A"
// "../inputs/day2.txt" |> Helpers.readAllLines |> Seq.map Day2_1.parseLine |> Day2_1.puzzle 12 13 14 |> printfn "%A"
// input1 |> Day1_1.parse |> Seq.map Day2_1.parseLine |> Day2_2.puzzle |> printfn "%A"
"../inputs/day2.txt" |> Helpers.readAllLines |> Seq.map Day2_1.parseLine |> Day2_2.puzzle |> printfn "%A"
// ["8ninefivegzk7ftqbceightwogfv"] |> Day1.puzzle2 |> printfn "%A"

// BenchmarkRunner.Run<Day1_2_bench.Bench>() |> ignore