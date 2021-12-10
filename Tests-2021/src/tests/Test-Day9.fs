module Test_Day09

open Expecto
open Expecto.Flip
open AoC2021
open AoC2021.Helpers
open FSharpPlus

let input1 = [
    [2;1;9;9;9;4;3;2;1;0]
    [3;9;8;7;8;9;4;9;2;1]
    [9;8;5;6;7;8;9;8;9;2]
    [8;7;6;7;8;9;6;7;8;9]
    [9;8;9;9;9;6;5;6;7;8]
]

[<Tests>]
let test1 = test "Day9 Part1 Test1" {
    input1
    |> Day9.puzzle1
    |> Expect.equal "" 15
}

[<Tests>]
let final1 = testAsync "Day9 Part1 Final" {
    getPuzzleInput "../inputs/Day9.txt"
    |> Seq.map (fun str -> str |> Seq.map (string >> int) |> Seq.toList)
    |> Seq.toList
    |> Day9.puzzle1
    |> Expect.equal "" 480
}

[<Tests>]
let test2 = test "Day9 Part2 Test1" {
    input1
    |> Day9.puzzle2
    |> Expect.equal "" 1134
}

[<Tests>]
let final2 = testAsync "Day9 Part2 Final" {
    getPuzzleInput "../inputs/Day9.txt"
    |> Seq.map (fun str -> str |> Seq.map (string >> int) |> Seq.toList)
    |> Seq.toList
    |> Day9.puzzle2
    |> Expect.equal "" 1045660
}