open AoC2023
open BenchmarkDotNet.Running

let input = """Time:      7  15   30
Distance:  9  40  200"""

// input |> Day1_1.parse |> Day6_2.puzzle |> printfn "%A"
"../inputs/day6.txt" |> Helpers.readAllLines |> Day6_2.puzzle |> printfn "%A"

// BenchmarkRunner.Run<Day1_1_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day1_2_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day2_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day3_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day5_bench.Bench>() |> ignore