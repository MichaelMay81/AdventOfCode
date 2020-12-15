module Test_Day05

open System
open Xunit
open Swensen.Unquote
open AoC2020.Helpers
open AoC2020

let getPuzzleInput = Program.getPuzzleInput
let input = [ "FBFBBFFRLR"; "BFFFBBFRRR"; "FFFBBBFRRR"; "BBFFBBFRLL"]

[<Fact>]
let ``Puzzle 1, Test`` () =
    [357; 567; 119; 820] =! (input |> Seq.map Day5.puzzleStringToInt |> Seq.toList)

[<Fact>]
let ``Puzzle 1, Final`` () =
    Ok 885 =! (readLines "../inputs/Day5.txt" |> Result.map Day5.puzzle1)

[<Fact>]
let ``Puzzle 2, Final`` () =
    Ok 623 =! (readLines "../inputs/Day5.txt" |> Result.map Day5.puzzle2)