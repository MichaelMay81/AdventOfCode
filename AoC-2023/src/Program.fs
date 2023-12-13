open AoC2023
open BenchmarkDotNet.Running

let input1 = """RL

AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)"""

let input2 = """LLR

AAA = (BBB, BBB)
BBB = (AAA, ZZZ)
ZZZ = (ZZZ, ZZZ)"""

// input2 |> Day1_1.parse |> Day8_1.puzzle |> printfn "%A"
"../inputs/day8.txt" |> Helpers.readAllLines |> Day8_1.puzzle |> printfn "%A"

// BenchmarkRunner.Run<Day1_1_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day1_2_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day2_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day3_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day5_bench.Bench>() |> ignore