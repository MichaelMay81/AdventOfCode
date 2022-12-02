module Test_Day02

open Expecto
open Expecto.Flip
open AoC2022
open AoC2022.Helpers

let input = "A Y\nB X\nC Z"

[<Tests>]
let test1 = test "Day2 Part1 Test" {
  input
  |> Day2_1.parse
  |> Day2_1.calcTotalScore
  |> Expect.equal "" 15
}

[<Tests>]
let final1 = testAsync "Day2 Part1 Final" {
  readAllText "../inputs/day2.txt"
  |> Day2_1.parse
  |> Day2_1.calcTotalScore
  |> Expect.equal "" 8392
}

[<Tests>]
let test2 = test "Day2 Part2 Test" {
  input
  |> Day2_2.parse
  |> Day2_2.calcTotalScore
  |> Expect.equal "" 12
}

[<Tests>]
let final2 = testAsync "Day2 Part2 Final" {
  readAllText "../inputs/day2.txt"
  |> Day2_2.parse
  |> Day2_2.calcTotalScore
  |> Expect.equal "" 10116
}