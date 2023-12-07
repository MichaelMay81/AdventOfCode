module Test_Day03

open Expecto
open Expecto.Flip
open AoC2023
open AoC2023.Helpers

let input =
    "467..114..
...*......
..35...633
.......#..
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598.."

[<Tests>]
let test1a = test "Day3 Part1a Test" {
    input
    |> Day1_1.parse
    |> Day3_1a.puzzle
    |> Expect.equal "" 4361
}

[<Tests>]
let final1a = testAsync "Day3 Part1a Final" {
    readAllLines "../inputs/day3.txt"
    |> Day3_1a.puzzle
    |> Expect.equal "" 530849
}

[<Tests>]
let final1b = testAsync "Day3 Part1b Final" {
    readAllLines "../inputs/day3.txt"
    |> Day3_1b.puzzle
    |> Expect.equal "" 530849
}

[<Tests>]
let final1c = testAsync "Day3 Part1c Final" {
    readAllLines "../inputs/day3.txt"
    |> Day3_1c.puzzle
    |> Expect.equal "" 530849
}

[<Tests>]
let final1d = testAsync "Day3 Part1d Final" {
    readAllLines "../inputs/day3.txt"
    |> Day3_1d.puzzle
    |> Expect.equal "" 530849
}