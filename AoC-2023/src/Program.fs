open AoC2023
open BenchmarkDotNet.Running

let input = """32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483"""

// input |> Day1_1.parse |> Day7_2.puzzle |> printfn "%A"
"../inputs/day7.txt" |> Helpers.readAllLines |> Day7_1.puzzle |> printfn "%A"

// BenchmarkRunner.Run<Day1_1_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day1_2_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day2_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day3_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day5_bench.Bench>() |> ignore