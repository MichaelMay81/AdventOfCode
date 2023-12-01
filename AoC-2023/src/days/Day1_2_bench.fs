module AoC2023.Day1_2_bench
open Helpers

open BenchmarkDotNet.Attributes

[<MemoryDiagnoser>]
type Bench() =

    [<Benchmark>]
    member _.benchmark_puzzle2_1 () =
        readAllLines "../inputs/day1.txt"
        |> Day1_2a.puzzle2
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle2_2 () =
        readAllLines "../inputs/day1.txt"
        |> Day1_2b.puzzle2
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle2_3 () =
        readAllLines "../inputs/day1.txt"
        |> Day1_2c.puzzle2
        |> ignore
