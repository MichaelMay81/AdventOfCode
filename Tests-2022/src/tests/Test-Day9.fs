module Test_Day09

open Expecto
open Expecto.Flip
open AoC2022.Day9_1
open AoC2022.Day9_2
open AoC2022.Helpers

let dayCount = 9
let finalInputPath = "../inputs/day9.txt"
let input = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2"

let input2 = @"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20"

[<Tests>]
let test1 = test $"Day{dayCount} Part1 Test" {
  input
  |> puzzle1
  |> Expect.equal "" 13
}
[<Tests>]
let final1 = testAsync $"Day{dayCount} Part1 Final" {
  readAllText finalInputPath
  |> puzzle1
  |> Expect.equal "" 6256
}
[<Tests>]
let test2 = test $"Day{dayCount} Part2 Test" {
  input2
  |> puzzle2
  |> Expect.equal "" 36
}
[<Tests>]
let final2 = testAsync $"Day{dayCount} Part2 Final" {
  readAllText finalInputPath
  |> puzzle2
  |> Expect.equal "" 2665
}