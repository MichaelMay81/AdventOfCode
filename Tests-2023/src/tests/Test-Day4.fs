module Test_Day04

open Expecto
open Expecto.Flip
open AoC2023
open AoC2023.Helpers

let input = """Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"""

[<Tests>]
let tests = testList "Day4" [
    testCase "Part1 Test" <| fun _  ->
        input
        |> Day1_1.parse
        |> Day4_1.puzzle
        |> Expect.equal "" 13
    
    testCase "Part1 Final" <| fun _ ->
        readAllLines "../inputs/day4.txt"
        |> Day4_1.puzzle
        |> Expect.equal "" 20829
    
    testCase "Part2 Test" <| fun _  ->
        input
        |> Day1_1.parse
        |> Day4_2.puzzle
        |> Expect.equal "" 30
    
    testCase "Part2 Final" <| fun _ ->
        readAllLines "../inputs/day4.txt"
        |> Day4_2.puzzle
        |> Expect.equal "" 12648035
]