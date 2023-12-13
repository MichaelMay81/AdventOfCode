module Test_Day08

open Expecto
open Expecto.Flip
open AoC2023
open AoC2023.Helpers

let input1 = """RL

AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)"""

let input2 = """LLR

AAA = (BBB, BBB)
BBB = (AAA, ZZZ)
ZZZ = (ZZZ, ZZZ)"""

[<Tests>]
let tests = testList "Day8" [
    testCase "Part1 Test1" <| fun _  ->
        input1 
        |> Day1_1.parse
        |> Day8_1.puzzle
        |> Expect.equal "" 2

    testCase "Part1 Test2" <| fun _  ->
        input2
        |> Day1_1.parse
        |> Day8_1.puzzle
        |> Expect.equal "" 6

    testCase "Part1 Final" <| fun _ ->
        readAllLines "../inputs/day8.txt"
        |> Day8_1.puzzle
        |> Expect.equal "" 13207
]