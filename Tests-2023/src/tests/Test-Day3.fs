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
let test1 = test "Day3 Part1 Test" {
    input
    |> Day1_1.parse
    |> Array.toList
    |> Day3.puzzle
    |> Expect.equal "" 4361
}

[<Tests>]
let final1 = testAsync "Day3 Part1 Final" {
    readAllLines "../inputs/day3.txt"
    |> Array.toList
    |> Day3.puzzle
    |> Expect.equal "" 530849
}