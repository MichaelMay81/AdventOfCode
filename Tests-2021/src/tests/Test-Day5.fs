module Test_Day05

open Expecto
open Expecto.Flip
open AoC2021
open AoC2021.Helpers

let input1 = [
    "0,9 -> 5,9"
    "8,0 -> 0,8"
    "9,4 -> 3,4"
    "2,2 -> 2,1"
    "7,0 -> 7,4"
    "6,4 -> 2,0"
    "0,9 -> 2,9"
    "3,4 -> 1,4"
    "0,0 -> 8,8"
    "5,5 -> 8,2"
]
let input2 = "1,1 -> 1,3"
let input3 = "9,7 -> 7,7"
let input2intCoords = [
    {Day5.X=1;Day5.Y=1}
    {Day5.X=1;Day5.Y=2}
    {Day5.X=1;Day5.Y=3}
]
let input3intCoords = [
    {Day5.X=9;Day5.Y=7}
    {Day5.X=8;Day5.Y=7}
    {Day5.X=7;Day5.Y=7}
]

[<Tests>]
let test1 = test "Day5 Test1" {
    input2
    |> Day5.parseVentLine
    |> Day5.interpolateVentLine
    |> Expect.equal "" input2intCoords
}

[<Tests>]
let test2 = test "Day5 Test2" {
    input3
    |> Day5.parseVentLine
    |> Day5.interpolateVentLine
    |> Expect.equal "" input3intCoords
}

[<Tests>]
let test3 = test "Day5 Part1 Test" {
    input1
    |> Day5.parseVentLines
    |> Day5.puzzle1
    |> Expect.equal "" 5
}

[<Tests>]
let final1 = testAsync "Day5 Part1 Final" {
    getPuzzleInput "../inputs/Day5.txt"
    |> Day5.parseVentLines
    |> Day5.puzzle1
    |> Expect.equal "" 6856
}

[<Tests>]
let test4 = test "Day5 Part2 Test" {
    input1
    |> Day5.parseVentLines
    |> Day5.puzzle2
    |> Expect.equal "" 12
}

[<Tests>]
let final2 = testAsync "Day5 Part2 Final" {
    getPuzzleInput "../inputs/Day5.txt"
    |> Day5.parseVentLines
    |> Day5.puzzle2
    |> Expect.equal "" 20666
}