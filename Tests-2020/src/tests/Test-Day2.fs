module Test_Day02

open System
open Xunit
open Swensen.Unquote
open AoC2020.Helpers
open AoC2020

let getPuzzleInput = Program.getPuzzleInput
let input = ["1-3 a: abcde"; "foobar"; "1-3 b: cdefg"; "2-9 c: ccccccccc"] |> List.toSeq

[<Fact>]
let ``Puzzle 1, Test`` () =
    2 =! (Day2.puzzle1 input)

[<Fact>]
let ``Puzzle 1, Final`` () =
    469 =! (getPuzzleInput "../inputs/Day2.txt" |> Day2.puzzle1)

[<Fact>]
let ``Puzzle 2, Test`` () =
    1 =! (Day2.puzzle2 input)

[<Fact>]
let ``Puzzle 2, Final`` () =
    267 =! (getPuzzleInput "../inputs/Day2.txt" |> Day2.puzzle2)
    
//    printfn "foobar %A" (["1-3 a: abcde" |> Day2.parse] |> filter |> Seq.map Day2.isPassCorrect2)
//    printfn "foobar %A" (["1-3 b: cdefg" |> Day2.parse] |> filter |> Seq.map Day2.isPassCorrect2)
//    printfn "foobar %A" (["2-9 c: ccccccccc" |> Day2.parse] |> filter |> Seq.map Day2.isPassCorrect2)
