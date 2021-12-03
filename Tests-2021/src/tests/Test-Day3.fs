module Test_Day03

open Expecto
open Expecto.Flip
open AoC2021
open AoC2021.Helpers

let input1 = [
        0b00100
        0b11110
        0b10110
        0b10111
        0b10101
        0b01111
        0b00111
        0b11100
        0b10000
        0b11001
        0b00010
        0b01010
    ]

[<Tests>]
let test1 = test "Day3 Part1 Test" {
  input1
  |> Day3.puzzle1
  |> Expect.equal "" 198
}

[<Tests>]
let test2 = test "Day3 Part2 Test" {
  input1
  |> Day3.puzzle2
  |> Expect.equal "" 230
}

[<Tests>]
let final1 = testAsync "Day3 Part1 Final" {
  getPuzzleInputAsBinaryInt "../inputs/Day3.txt"
  |> Day3.puzzle1
  |> Expect.equal "" 738234
}

[<Tests>]
let final2 = testAsync "Day3 Part2 Final" {
  getPuzzleInputAsBinaryInt "../inputs/Day3.txt"
  |> Day3.puzzle2
  |> Expect.equal "" 3969126
}