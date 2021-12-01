module Test_Day01

open Expecto
open Expecto.Flip
open AoC2021
open AoC2021.Helpers

let input1 = [199; 200; 208; 210; 200; 207; 240; 269; 260; 263]

[<Tests>]
let test1 = test "Day1 Part1 Test" {
  input1
  |> Day1.puzzle1
  |> Expect.equal "" 7
}

[<Tests>]
let test2 = test "Day1 Part2 Test" {
  input1
  |> Day1.puzzle2
  |> Expect.equal "" 5
}

[<Tests>]
let final1 = testAsync "Day1 Part1 Final" {
  getPuzzleInputAsInt "../inputs/Day1.txt"
  |> Day1.puzzle1
  |> Expect.equal "" 1711
}

[<Tests>]
let final2 = testAsync "Day1 Part2 Final" {
  getPuzzleInputAsInt "../inputs/Day1.txt"
  |> Day1.puzzle2
  |> Expect.equal "" 1743
}