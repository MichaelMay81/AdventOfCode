module Test_Day04

open Expecto
open Expecto.Flip
open AoC2022.Day4
open AoC2022.Helpers

let dayCount = 4
let finalInputPath = "../inputs/day4.txt"
let input = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8"            .Split "\n"

[<Tests>]
let test1 = test $"Day{dayCount} Part1 Test" {
  input
  |> puzzle1
  |> Expect.equal "" 2
}

[<Tests>]
let final1 = testAsync $"Day{dayCount} Part1 Final" {
  readAllLines finalInputPath
  |> puzzle1
  |> Expect.equal "" 424
}

[<Tests>]
let test2 = test $"Day{dayCount} Part2 Test" {
  input
  |> puzzle2
  |> Expect.equal "" 4
}

[<Tests>]
let final2 = testAsync $"Day{dayCount} Part2 Final" {
  readAllLines finalInputPath
  |> puzzle2
  |> Expect.equal "" 804
}