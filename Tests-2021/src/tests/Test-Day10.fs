module Test_Day10

open Expecto
open Expecto.Flip
open AoC2021
open AoC2021.Helpers

let input1 = [
    "[({(<(())[]>[[{[]{<()<>>"
    "[(()[<>])]({[<{<<[]>>("
    "{([(<{}[<>[]}>{[]{[(<()>"
    "(((({<>}<{<{<>}{[]{[]{}"
    "[[<[([]))<([[{}[[()]]]"
    "[{[{({}]{}}([{[{{{}}([]"
    "{<[[]]>}<{[{[{[]{()[[[]"
    "[<(<(<(<{}))><([]([]()"
    "<{([([[(<>()){}]>(<<{{"
    "<{([{{}}[<[[[<>{}]]]>[]]"
]

[<Tests>]
let test1 = test "Day10 Part1 Test1" {
    input1
    |> Day10.puzzle1
    |> Expect.equal "" 26397
}

[<Tests>]
let final1 = testAsync "Day10 Part1 Final" {
    getPuzzleInput "../inputs/Day10.txt"
    |> Day10.puzzle1
    |> Expect.equal "" 343863
}

[<Tests>]
let test2 = test "Day10 Part2 Test1" {
    input1
    |> Day10.puzzle2
    |> Expect.equal "" 288957
}

[<Tests>]
let final2 = testAsync "Day10 Part2 Final" {
    getPuzzleInput "../inputs/Day10.txt"
    |> Day10.puzzle2
    |> Expect.equal "" 2924734236L
}