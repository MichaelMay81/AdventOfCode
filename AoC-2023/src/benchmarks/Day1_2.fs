module AoC2023.Day1_2_bench
open Helpers

open BenchmarkDotNet.Attributes

[<MemoryDiagnoser>]
type Bench() =

    [<Benchmark>]
    member _.benchmark_puzzle2a () =
        readAllLines "../inputs/day1.txt"
        |> Day1_2a.puzzle2
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle2b () =
        readAllLines "../inputs/day1.txt"
        |> Day1_2b.puzzle2
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle2c () =
        readAllLines "../inputs/day1.txt"
        |> Day1_2c.puzzle2
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle2d () =
        readAllLines "../inputs/day1.txt"
        |> Day1_2d.puzzle2
        |> ignore