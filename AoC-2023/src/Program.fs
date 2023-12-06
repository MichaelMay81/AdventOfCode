﻿open AoC2023
open BenchmarkDotNet.Running

let input1 = """1abc2
                pqr3stu8vwx
                a1b2c3d4e5f
                treb7uchet"""

// Day3.collect 0 [] ("467..114.." |> Seq.toList) ["...*......" |> Seq.toList] |> printfn "%A"
// Day3.collectLine [] ("467..114.." |> Seq.toList) ["...*......" |> Seq.toList] |> printfn "%A"

// input1 |> Day1_1.parse |> Array.toList |> Day1_1b.puzzle1 |> printfn "%A"
// "../inputs/day3.txt" |> Helpers.readAllLines |> Array.toList |> Day3.puzzle |> printfn "%A"
// input1 |> Day1_1.parse |> Seq.map Day2_1.parseLine |> Day2_2.puzzle |> printfn "%A"
// "../inputs/day2.txt" |> Helpers.readAllLines |> Seq.map Day2_1.parseLine |> Day2_2.puzzle |> printfn "%A"
// ["8ninefivegzk7ftqbceightwogfv"] |> Day1.puzzle2 |> printfn "%A"

BenchmarkRunner.Run<Day1_1_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day1_2_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day2_bench.Bench>() |> ignore