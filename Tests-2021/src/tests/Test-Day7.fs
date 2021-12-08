module Test_Day07

open Expecto
open Expecto.Flip
open AoC2021
open AoC2021.Helpers
open FSharpPlus

let input1 = [16;1;2;0;4;2;7;1;2;14]

[<Tests>]
let test1 = test "Day7 Part1 Test1" {
    input1
    |> Day7.puzzle1
    |> Expect.equal "" 37
}

[<Tests>]
let final1 = testAsync "Day7 Part1 Final" {
    getPuzzleInput "../inputs/Day7.txt"
    |> Seq.head
    |> String.split [","]
    |> Seq.map int
    |> Day7.puzzle1
    |> Expect.equal "" 347011
}

[<Tests>]
let test2 = test "Day7 Part2 Test1" {
    input1
    |> Day7.calculateLanternFishFuelConsumption 2
    |> Expect.equal "" 206
}

[<Tests>]
let test3 = test "Day7 Part2 Test2" {
    input1
    |> Day7.calculateLanternFishFuelConsumption 5
    |> Expect.equal "" 168
}

[<Tests>]
let test4 = test "Day7 Part2 Test3" {
    input1
    |> Day7.puzzle2
    |> Expect.equal "" 168
}

[<Tests>]
let final2 = testAsync "Day7 Part2 Final" {
    getPuzzleInput "../inputs/Day7.txt"
    |> Seq.head
    |> String.split [","]
    |> Seq.map int
    |> Seq.toList
    |> Day7.puzzle2
    |> Expect.equal "" 98363777
}