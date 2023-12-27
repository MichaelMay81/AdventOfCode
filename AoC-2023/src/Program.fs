open AoC2023
open BenchmarkDotNet.Running

let input = """0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45"""

input |> Day1_1.parse |> Day9_1.puzzle |> printfn "%A"
"../inputs/day9.txt" |> Helpers.readAllLines |> Day9_1.puzzle |> printfn "%A"

// BenchmarkRunner.Run<Day1_1_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day1_2_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day2_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day3_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day5_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day8_bench.Bench>() |> ignore