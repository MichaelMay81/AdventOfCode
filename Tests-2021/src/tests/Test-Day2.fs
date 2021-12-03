module Test_Day02

open Expecto
open Expecto.Flip
open AoC2021
open AoC2021.Helpers

open AoC2021.Day2

let input1 = [
        Forward 5
        Down 5
        Forward 8
        Up 3
        Down 8
        Forward 2
    ]

[<Tests>]
let test1 = test "Day2 Part1 Test" {
  input1
  |> Day2_1.puzzle
  |> Expect.equal "" 150
}

[<Tests>]
let test2 = test "Day2 Part2 Test" {
  input1
  |> Day2_2.puzzle
  |> Expect.equal "" 900
}

[<Tests>]
let final1 = testAsync "Day2 Part1 Final" {
  getPuzzleInput "../inputs/Day2.txt"
  |> parseCmds
  |> Day2_1.puzzle
  |> Expect.equal "" 1459206
}

[<Tests>]
let final2 = testAsync "Day2 Part2 Final" {
  getPuzzleInput "../inputs/Day2.txt"
  |> parseCmds
  |> Day2_2.puzzle
  |> Expect.equal "" 1320534480
}