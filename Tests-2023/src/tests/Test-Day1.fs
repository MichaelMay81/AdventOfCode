module Test_Day01

open Expecto
open Expecto.Flip
open AoC2023
open AoC2023.Helpers

let input1 = """1abc2
                pqr3stu8vwx
                a1b2c3d4e5f
                treb7uchet"""

let input2 = """two1nine
                eightwothree
                abcone2threexyz
                xtwone3four
                4nineeightseven2
                zoneight234
                7pqrstsixteen"""

[<Tests>]
let test1 = test "Day1 Part1 Test" {
  input1
  |> Day1.parse
  |> Day1.puzzle1
  |> Expect.equal "" 142
}

[<Tests>]
let final1 = testAsync "Day1 Part1 Final" {
  readAllLines "../inputs/day1.txt"
  |> Day1.puzzle1
  |> Expect.equal "" 54632
}

[<Tests>]
let test2 = test "Day1 Part2 Test" {
  input2
  |> Day1.parse
  |> Day1.puzzle2
  |> Expect.equal "" 281
}

[<Tests>]
let final2 = testAsync "Day1 Part2 Final" {
  readAllLines "../inputs/day1.txt"
  |> Day1.puzzle2
  |> Expect.equal "" 54019
}