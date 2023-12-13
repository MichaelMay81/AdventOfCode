module Test_Day07

open Expecto
open Expecto.Flip
open AoC2023
open AoC2023.Helpers

let input = """32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483"""

[<Tests>]
let tests = testList "Day7" [
    testCase "Part1 Test" <| fun _  ->
        input
        |> Day1_1.parse
        |> Day7_1.puzzle
        |> Expect.equal "" 6440

    testCase "Part1 Final" <| fun _ ->
        readAllLines "../inputs/day7.txt"
        |> Day7_1.puzzle
        |> Expect.equal "" 248453531
]