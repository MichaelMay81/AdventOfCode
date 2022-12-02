module Test_Day01

open Expecto
open Expecto.Flip
open AoC2022
open AoC2022.Helpers

let input = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000"

[<Tests>]
let test1 = test "Day1 Part1 Test" {
  input
  |> Day1.parse
  |> Day1.puzzle1
  |> Expect.equal "" 24000
}

[<Tests>]
let final1 = testAsync "Day1 Part1 Final" {
  readAllText "../inputs/day1.txt"
  |> Day1.parse
  |> Day1.puzzle1
  |> Expect.equal "" 72017
}

[<Tests>]
let test2 = test "Day1 Part2 Test" {
  input
  |> Day1.parse
  |> Day1.puzzle2
  |> Expect.equal "" 45000
}

[<Tests>]
let final2 = testAsync "Day1 Part2 Final" {
  readAllText "../inputs/day1.txt"
  |> Day1.parse
  |> Day1.puzzle2
  |> Expect.equal "" 212520
}