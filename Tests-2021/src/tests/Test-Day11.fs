module Test_Day11

open Expecto
open Expecto.Flip
open AoC2021
open AoC2021.Helpers

// let input1 = [
//     [1;1;1;1;1]
//     [1;9;9;9;1]
//     [1;9;1;9;1]
//     [1;9;9;9;1]
//     [1;1;1;1;1]
// ]
let input2 = [
    [5;4;8;3;1;4;3;2;2;3]
    [2;7;4;5;8;5;4;7;1;1]
    [5;2;6;4;5;5;6;1;7;3]
    [6;1;4;1;3;3;6;1;4;6]
    [6;3;5;7;3;8;5;4;7;8]
    [4;1;6;7;5;2;4;6;4;5]
    [2;1;7;6;8;4;1;7;2;1]
    [6;8;8;2;8;8;1;1;3;4]
    [4;8;4;6;8;4;8;5;5;4]
    [5;2;8;3;7;5;1;5;2;6]
]

// input1
// |> Day11.puzzle1 2
// |> List.map (fun v -> (v |> List.map (printf "%A") |> ignore; printfn ""))
// |> ignore

[<Tests>]
let test1 = test "Day11 Part1 Test1" {
    input2
    |> Day11.puzzle1 10
    |> fun (nof, _) ->
        nof |> Expect.equal "" 204
}

[<Tests>]
let test2 = test "Day11 Part1 Test2" {
    input2
    |> Day11.puzzle1 100
    |> fun (nof, _) ->
        nof |> Expect.equal "" 1656
}

[<Tests>]
let final1 = testAsync "Day11 Part1 Final" {
    getPuzzleInput "../inputs/Day11.txt"
    |> Seq.map (fun str -> str |> Seq.map (string >> int) |> Seq.toList)
    |> Seq.map Seq.toList
    |> Seq.toList
    |> Day11.puzzle1 100
    |> fun (nof, _) ->
        nof |> Expect.equal "" 1719
}

[<Tests>]
let test3 = test "Day11 Part2 Test1" {
    input2
    |> Day11.puzzle2
    |> fun (nof, _) ->
        nof |> Expect.equal "" 195
}

[<Tests>]
let final2 = testAsync "Day11 Part2 Final" {
    getPuzzleInput "../inputs/Day11.txt"
    |> Seq.map (fun str -> str |> Seq.map (string >> int) |> Seq.toList)
    |> Seq.map Seq.toList
    |> Seq.toList
    |> Day11.puzzle2
    |> fun (nof, _) ->
        nof |> Expect.equal "" 232
}