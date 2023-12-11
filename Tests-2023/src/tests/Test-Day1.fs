module Test_Day01

open Expecto
open Expecto.Flip
open AoC2023
open AoC2023.Helpers

let input1 = """1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet"""

let input2 = """two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen"""

[<Tests>]
let tests = testList "Day1" [
  testCase "Part1 Test" <| fun _  ->
    input1
    |> Day1_1.parse
    |> Day1_1.puzzle1
    |> Expect.equal "" 142

  testCase "Part1 Final" <| fun _ ->
    readAllLines "../inputs/day1.txt"
    |> Day1_1.puzzle1
    |> Expect.equal "" 54632

  testCase "Part1b Final" <| fun _  ->
    readAllLines "../inputs/day1.txt"
    |> Day1_1b.puzzle1
    |> Expect.equal "" 54632

  testCase "Part2a Test" <| fun _ ->
    input2
    |> Day1_1.parse
    |> Day1_2a.puzzle2
    |> Expect.equal "" 281

  testCase "Part2a Final" <| fun _ ->
    readAllLines "../inputs/day1.txt"
    |> Day1_2a.puzzle2
    |> Expect.equal "" 54019

  testCase "Part2b Test" <| fun _ ->
    input2
    |> Day1_1.parse
    |> Day1_2b.puzzle2
    |> Expect.equal "" 281

  testCase "Part2b Final" <| fun _ ->
    readAllLines "../inputs/day1.txt"
    |> Day1_2b.puzzle2
    |> Expect.equal "" 54019

  testCase "Part2c Test" <| fun _ ->
    input2
    |> Day1_1.parse
    |> Day1_2c.puzzle2
    |> Expect.equal "" 281

  testCase "Part2c Final" <| fun _ ->
    readAllLines "../inputs/day1.txt"
    |> Day1_2c.puzzle2
    |> Expect.equal "" 54019

  testCase "Part2d Final" <| fun _ ->
    readAllLines "../inputs/day1.txt"
    |> Day1_2d.puzzle2
    |> Expect.equal "" 54019
]