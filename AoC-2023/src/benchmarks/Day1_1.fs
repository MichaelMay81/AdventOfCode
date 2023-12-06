module AoC2023.Day1_1_bench
open Helpers

open BenchmarkDotNet.Attributes

[<MemoryDiagnoser>]
type Bench() =

    [<Benchmark>]
    member _.benchmark_puzzle1_1a () =
        readAllLines "../inputs/day1.txt"
        |> Day1_1.puzzle1
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle1_2b () =
        readAllLines "../inputs/day1.txt"
        |> Day1_1b.puzzle1
        |> ignore
