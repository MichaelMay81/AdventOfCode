module AoC2023.Day8_bench

open BenchmarkDotNet.Attributes
open Day8_2

[<MemoryDiagnoser>]
type Bench() =

    [<Benchmark>]
    member _.benchmark_SeqExpr () =
        [93653473; 2147483647]
        |> List.map getFactors3
        |> findGCFSeq
        |> ignore

    [<Benchmark>]
    member _.benchmark_Seq () =
        [93653473; 2147483647]
        |> List.map getFactors2
        |> findGCFSeq
        |> ignore

    [<Benchmark>]
    member _.benchmark_SeqRev () =
        [93653473; 2147483647]
        |> List.map getFactors
        |> findGCFSeq
        |> ignore

    [<Benchmark>]
    member _.benchmark_List1 () =
        [93653473; 2147483647]
        |> List.map getFactors2
        |> List.map Seq.toList
        |> findGCF1
        |> ignore

    [<Benchmark>]
    member _.benchmark_List2 () =
        [93653473; 2147483647]
        |> List.map getFactors2
        |> List.map Seq.toList
        |> findGCF2
        |> ignore