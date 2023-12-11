module AoC2023.Day5_bench
open Helpers

open BenchmarkDotNet.Attributes

[<MemoryDiagnoser>]
type Bench() =

    [<Benchmark>]
    member _.benchmark_puzzle1 () =
        "../inputs/day5.txt"
        |> readAllLines
        |> Day5_1.puzzle
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle1b_Reverse () =
        "../inputs/day5.txt"
        |> readAllLines
        |> Day5_1b.puzzle
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle2b_Bruteforce () =
        "../inputs/day5.txt"
        |> readAllLines
        |> Day5_2.puzzle
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle2b_BruteParallel () =
        "../inputs/day5.txt"
        |> readAllLines
        |> Day5_2b.puzzle
        |> ignore

    [<Benchmark>]
    member _.benchmark_puzzle2c_Reverse () =
        "../inputs/day5.txt"
        |> readAllLines
        |> Day5_2c.puzzle
        |> ignore