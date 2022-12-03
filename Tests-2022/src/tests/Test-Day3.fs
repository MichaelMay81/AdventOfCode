module Test_Day03

open Expecto
open Expecto.Flip
open AoC2022.Day3
open AoC2022.Helpers

let dayCount = 3
let finalInputPath = "../inputs/day3.txt"
let input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw".Split "\n"

[<Tests>]
let test1 = test $"Day{dayCount} Part1 Test" {
  input
  |> puzzle1
  |> Expect.equal "" 157
}

[<Tests>]
let final1 = testAsync $"Day{dayCount} Part1 Final" {
  readAllLines finalInputPath
  |> puzzle1
  |> Expect.equal "" 8088
}

[<Tests>]
let test2 = test $"Day{dayCount} Part2 Test" {
  input
  |> puzzle2
  |> Expect.equal "" 70
}

[<Tests>]
let final2 = testAsync $"Day{dayCount} Part2 Final" {
  readAllLines finalInputPath
  |> puzzle2
  |> Expect.equal "" 2522
}