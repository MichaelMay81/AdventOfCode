module AoC2023.Day3_bench
open Helpers

open BenchmarkDotNet.Attributes

[<MemoryDiagnoser>]
type Bench() =

    [<Benchmark>]
    member _.benchmark_puzzle1a () =
        readAllLines "../inputs/day3.txt"
        |> Day3_1a.puzzle
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle1b () =
        readAllLines "../inputs/day3.txt"
        |> Day3_1b.puzzle
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle1c () =
        readAllLines "../inputs/day3.txt"
        |> Day3_1c.puzzle
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle1d () =
        readAllLines "../inputs/day3.txt"
        |> Day3_1d.puzzle
        |> ignore