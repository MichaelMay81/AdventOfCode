module Test_Day08

open Expecto
open Expecto.Flip
open AoC2022.Day8_1
open AoC2022.Day8_2
open AoC2022.Helpers

let dayCount = 8
let finalInputPath = "../inputs/day8.txt"
let input = @"30373
25512
65332
33549
35390"

[<Tests>]
let test1 = test $"Day{dayCount} Part1 Test" {
  input
  |> puzzle1
  |> Expect.equal "" 21
}
[<Tests>]
let final1 = testAsync $"Day{dayCount} Part1 Final" {
  readAllText finalInputPath
  |> puzzle1
  |> Expect.equal "" 1736
}
[<Tests>]
let test2 = test $"Day{dayCount} Part2 Test" {
  input
  |> puzzle2
  |> Expect.equal "" 8
}
[<Tests>]
let final2 = testAsync $"Day{dayCount} Part2 Final" {
  readAllText finalInputPath
  |> puzzle2
  |> Expect.equal "" 268800
}