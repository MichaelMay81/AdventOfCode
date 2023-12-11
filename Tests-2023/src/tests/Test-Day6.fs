module Test_Day06

open Expecto
open Expecto.Flip
open AoC2023
open AoC2023.Helpers

let input = """Time:      7  15   30
Distance:  9  40  200"""

[<Tests>]
let tests = testList "Day6" [
    testCase "Part1 Test" <| fun _  ->
        input
        |> Day1_1.parse
        |> Day6_1.puzzle
        |> Expect.equal "" 288L

    testCase "Part1 Final" <| fun _ ->
        readAllLines "../inputs/day6.txt"
        |> Day6_1.puzzle
        |> Expect.equal "" 219849L

    testCase "Part2 Test" <| fun _  ->
        input
        |> Day1_1.parse
        |> Day6_2.puzzle
        |> Expect.equal "" 71503L

    testCase "Part2 Final" <| fun _ ->
        readAllLines "../inputs/day6.txt"
        |> Day6_2.puzzle
        |> Expect.equal "" 29432455L
]