module AoC2023.Day2_bench
open Helpers

open BenchmarkDotNet.Attributes

[<MemoryDiagnoser>]
type Bench() =

    [<Benchmark>]
    member _.benchmark_puzzle1 () =
        readAllLines "../inputs/day2.txt"
        |> Seq.map (Day2_1.parseLine Day2_1.CubeColor.tryParse)
        |> Day2_1.puzzle 12 13 14
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle2 () =
        readAllLines "../inputs/day2.txt"
        |> Seq.map (Day2_1.parseLine Day2_1.CubeColor.tryParse)
        |> Day2_2.puzzle
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle1b () =
        readAllLines "../inputs/day2.txt"
        |> Seq.map (Day2_1.parseLine Day2_1.CubeColor.tryParse2)
        |> Day2_1.puzzle 12 13 14
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle2b () =
        readAllLines "../inputs/day2.txt"
        |> Seq.map (Day2_1.parseLine Day2_1.CubeColor.tryParse2)
        |> Day2_2.puzzle
        |> ignore

    