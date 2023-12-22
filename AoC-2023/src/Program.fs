open AoC2023
open BenchmarkDotNet.Running

// let input = """LR

// 11A = (11B, XXX)
// 11B = (XXX, 11Z)
// 11Z = (11B, XXX)
// 22A = (22B, XXX)
// 22B = (22C, 22C)
// 22C = (22Z, 22Z)
// 22Z = (22B, 22B)
// XXX = (XXX, XXX)"""

let input = [ Day8_2.getFactors 8; Day8_2.getFactors 12 ] |> List.map Seq.toList
let input2 = [ Day8_2.getFactors2 8; Day8_2.getFactors2 12 ] |> List.map Seq.toList
let input3 = [ Day8_2.getFactors3 8; Day8_2.getFactors3 12 ] |> List.map Seq.toList
let input4 = [ Day8_2.getFactors2 8; Day8_2.getFactors2 12 ]

printfn "%A" input
printfn "%A" input2
printfn "%A" input3
printfn "%A" input4

// input |> Day8_2.findGCF1 |> printfn "%A"
// input |> Day8_2.findGCF2 |> printfn "%A"
// input2 |> Day8_2.findGCF1 |> printfn "%A"
// input2 |> Day8_2.findGCF2 |> printfn "%A"

// input |> List.map List.toSeq |> Day8_2.findGCFSeq |> printfn "%A"
// input2 |> List.map List.toSeq |> Day8_2.findGCFSeq |> printfn "%A"
// input3 |> Day8_2.findGCFSeq |> printfn "%A"

// [8; 12] |> Day8_2.findLcd Day8_2.getFactors Day8_2.findGCF1 |> printfn "%i"
// [8; 12] |> Day8_2.findLcd Day8_2.getFactors Day8_2.findGCF2 |> printfn "%i"
// [8; 12] |> Day8_2.findLcd Day8_2.getFactors2 Day8_2.findGCF1 |> printfn "%i"
// [8; 12] |> Day8_2.findLcd Day8_2.getFactors2 Day8_2.findGCF2 |> printfn "%i"

// [8; 12] |> Day8_2.findLcdSeq Day8_2.getFactors Day8_2.findGCFSeq |> printfn "%i"
// [8; 12] |> Day8_2.findLcdSeq Day8_2.getFactors2 Day8_2.findGCFSeq |> printfn "%i"

//input |> Day1_1.parse |> Day8_2.puzzle |> printfn "%A"
// "../inputs/day8.txt" |> Helpers.readAllLines |> Day8_2.puzzle |> printfn "%A"

// "../inputs/day8_david.txt" |> Helpers.readAllLines |> Day8_2.puzzle |> printfn "%A"
// 22103062509257
// input |> Day1_1.parse |> Day8_2.puzzle |> printfn "%A"
// "../inputs/day8.txt" |> Helpers.readAllLines |> Day8_2.puzzle |> printfn "%A"

// BenchmarkRunner.Run<Day1_1_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day1_2_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day2_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day3_bench.Bench>() |> ignore
// BenchmarkRunner.Run<Day5_bench.Bench>() |> ignore
BenchmarkRunner.Run<Day8_bench.Bench>() |> ignore