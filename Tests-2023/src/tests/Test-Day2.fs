module Test_Day02

open Expecto
open Expecto.Flip
open AoC2023
open AoC2023.Helpers

let input =
    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"

[<Tests>]
let test1 = test "Day2 Part1 Test" {
  input
  |> Day1_1.parse
  |> Seq.map Day2_1.parseLine
  |> Day2_1.puzzle 12 13 14
  |> Expect.equal "" 8
}

[<Tests>]
let final1 = testAsync "Day2 Part1 Final" {
  readAllLines "../inputs/day2.txt"
  |> Seq.map Day2_1.parseLine
  |> Day2_1.puzzle 12 13 14
  |> Expect.equal "" 2449
}

[<Tests>]
let test2a = test "Day2 Part2 Test" {
  input
  |> Day1_1.parse
  |> Seq.map Day2_1.parseLine
  |> Day2_2.puzzle
  |> Expect.equal "" 2286
}

[<Tests>]
let final2a = testAsync "Day2 Part2 Final" {
  readAllLines "../inputs/day2.txt"
  |> Seq.map Day2_1.parseLine
  |> Day2_2.puzzle
  |> Expect.equal "" 63981
}