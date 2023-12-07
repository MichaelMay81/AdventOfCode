open AoC2023
open BenchmarkDotNet.Running

let input = """467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598.."""

input |> Day1_1.parse |> Array.toList |> Day3_2.puzzle |> printfn "%A"
// "../inputs/day3.txt" |> Helpers.readAllLines |> Array.toList |> Day3.puzzle |> printfn "%A"
// input1 |> Day1_1.parse |> Seq.map Day2_1.parseLine |> Day2_2.puzzle |> printfn "%A"
// "../inputs/day2.txt" |> Helpers.readAllLines |> Seq.map Day2_1.parseLine |> Day2_2.puzzle |> printfn "%A"
// ["8ninefivegzk7ftqbceightwogfv"] |> Day1.puzzle2 |> printfn "%A"

// BenchmarkRunner.Run<Day1_1_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day1_2_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day2_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day3_bench.Bench>() |> ignore