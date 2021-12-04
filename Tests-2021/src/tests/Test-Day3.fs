module Test_Day03

open Expecto
open Expecto.Flip
open AoC2021
open AoC2021.Helpers

let input1 = [
        0b00100 // 4
        0b11110 // 30
        0b10110 // 22
        0b10111 // 23
        0b10101 // 21
        0b01111 // 15
        0b00111 // 7
        0b11100 // 28
        0b10000 // 16
        0b11001 // 25
        0b00010 // 2
        0b01010 // 10
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