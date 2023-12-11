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
let tests = testList "Day3" [
    testCase "Part1a Test" <| fun _  ->
        input
        |> Day1_1.parse
        |> Day3_1a.puzzle
        |> Expect.equal "" 4361
    
    testCase "Part1a Final" <| fun _ ->
        readAllLines "../inputs/day3.txt"
        |> Day3_1a.puzzle
        |> Expect.equal "" 530849
    
    testCase "Part1b Final" <| fun _  ->
        readAllLines "../inputs/day3.txt"
        |> Day3_1b.puzzle
        |> Expect.equal "" 530849
    
    testCase "Part1c Final" <| fun _ ->
        readAllLines "../inputs/day3.txt"
        |> Day3_1c.puzzle
        |> Expect.equal "" 530849

    testCase "Part1d Final" <| fun _ ->
        readAllLines "../inputs/day3.txt"
        |> Day3_1d.puzzle
        |> Expect.equal "" 530849

    testCase "Part2 Test" <| fun _ ->
        input
        |> Day1_1.parse
        |> Day3_2.puzzle
        |> Expect.equal "" 467835

    testCase "Part2 Final" <| fun _ ->
        readAllLines "../inputs/day3.txt"
        |> Day3_2.puzzle
        |> Expect.equal "" 84900879
]