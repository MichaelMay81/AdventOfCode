module Test_Day09

open Expecto
open Expecto.Flip
open AoC2023
open AoC2023.Helpers

let input = """0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45"""
[<Tests>]
let tests = testList "Day9" [
    testCase "Part1 Test" <| fun _  ->
        input
        |> Day1_1.parse
        |> Day9_1.puzzle
        |> Expect.equal "" 114

    testCase "Part1 Final" <| fun _ ->
        readAllLines "../inputs/day9.txt"
        |> Day9_1.puzzle
        |> Expect.equal "" 1916822650

    testCase "Part2 Test" <| fun _  ->
        input
        |> Day1_1.parse
        |> Day9_2.puzzle
        |> Expect.equal "" 2

    testCase "Part2 Final" <| fun _ ->
        readAllLines "../inputs/day9.txt"
        |> Day9_2.puzzle
        |> Expect.equal "" 966
]