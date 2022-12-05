module Test_Day05

open Expecto
open Expecto.Flip
open AoC2022.Day5
open AoC2022.Helpers

let dayCount = 5
let finalInputPath = "../inputs/day5.txt"
let input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2"

[<Tests>]
let test1 = test $"Day{dayCount} Part1 Test" {
  input
  |> puzzle1
  |> Expect.equal "" "CMZ"
}

[<Tests>]
let final1 = testAsync $"Day{dayCount} Part1 Final" {
  readAllText finalInputPath
  |> puzzle1
  |> Expect.equal "" "MQSHJMWNH"
}

[<Tests>]
let test2 = test $"Day{dayCount} Part2 Test" {
  input
  |> puzzle2
  |> Expect.equal "" "MCD"
}

[<Tests>]
let final2 = testAsync $"Day{dayCount} Part2 Final" {
  readAllText finalInputPath
  |> puzzle2
  |> Expect.equal "" "LLWJRBHVZ"
}