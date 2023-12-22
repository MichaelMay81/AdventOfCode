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

let input = """LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)"""

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

    testCase "Part2 Test1" <| fun _  ->
        input2
        |> Day1_1.parse
        |> Day8_2.puzzle
        |> Expect.equal "" 6

    testCase "Part2 Final" <| fun _ ->
        readAllLines "../inputs/day8.txt"
        |> Day8_2.puzzle
        |> Expect.equal "" 12324145107121L
]