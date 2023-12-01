open AoC2023
open BenchmarkDotNet.Running

let input1 =
    "1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet"

let input2 =
    "two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen"

// input1 |> Day1.parse |> Day1.puzzle1 |> printfn "%A"
// "../inputs/Day1.txt" |> Helpers.readAllLines |> Day1.puzzle1 |> printfn "%A"
// input2 |> Day1.parse |> Day1.puzzle2_3 |> printfn "%A"
//"../inputs/Day1.txt" |> Helpers.readAllLines |> Day1.puzzle2 |> printfn "%A"
// ["8ninefivegzk7ftqbceightwogfv"] |> Day1.puzzle2 |> printfn "%A"

BenchmarkRunner.Run<Day1_2_bench.Bench>() |> ignore