module Test_Day06

open Expecto
open Expecto.Flip
open AoC2021
open AoC2021.Helpers
open FSharpPlus

let input1 = [3;4;3;1;2]

[<Tests>]
let test1 = test "Day6 Part1 Test1" {
    input1
    |> Day6.puzzle1 18
    |> Expect.equal "" 26
}

[<Tests>]
let test2 = test "Day6 Part1 Test2" {
    input1
    |> Day6.puzzle1 80
    |> Expect.equal "" 5934
}

[<Tests>]
let final1 = testAsync "Day6 Part1 Final" {
    getPuzzleInput "../inputs/Day6.txt"
    |> Seq.head
    |> String.split [","]
    |> Seq.map int
    |> Seq.toList
    |> Day6.puzzle1 80
    |> Expect.equal "" 390923
}

[<Tests>]
let test3 = test "Day6 Part2 Test" {
    input1
    |> Day6.puzzle1 256
    |> Expect.equal "" 26984457539L
}

[<Tests>]
let final2 = testAsync "Day6 Part2 Final" {
    getPuzzleInput "../inputs/Day6.txt"
    |> Seq.head
    |> String.split [","]
    |> Seq.map int
    |> Seq.toList
    |> Day6.puzzle1 256
    |> Expect.equal "" 1749945484935L
}