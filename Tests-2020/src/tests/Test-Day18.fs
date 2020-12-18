module Test_Day18

open System
open Xunit
open Swensen.Unquote
open AoC2020.Helpers
open AoC2020
open FSharpPlus

let input1 = "1 + 2 * 3 + 4 * 5 + 6"
let input2 = "1 + (2 * 3) + (4 * (5 + 6))"
let input3 = "2 * 3 + (4 * 5)"
let input4 = "5 + (8 * 3 + 9 + 3 * 4 * 3)"
let input5 = "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))"
let input6 = "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2"


[<Fact>]
let ``Puzzle 1, Test1`` () =
     71L =! (input1 |> Seq.filter ((<>) ' ') |> Seq.toList |> Day18.parseAndEvaluate)

[<Fact>]
let ``Puzzle 1, Test2`` () =
     51L =! (input2 |> Seq.filter ((<>) ' ') |> Seq.toList |> Day18.parseAndEvaluate)

[<Fact>]
let ``Puzzle 1, Test3`` () =
     26L =! (input3 |> Seq.filter ((<>) ' ') |> Seq.toList |> Day18.parseAndEvaluate)

[<Fact>]
let ``Puzzle 1, Test4`` () =
     437L =! (input4 |> Seq.filter ((<>) ' ') |> Seq.toList |> Day18.parseAndEvaluate)

[<Fact>]
let ``Puzzle 1, Test5`` () =
     12240L =! (input5 |> Seq.filter ((<>) ' ') |> Seq.toList |> Day18.parseAndEvaluate)

[<Fact>]
let ``Puzzle 1, Test6`` () =
     13632L =! (input6 |> Seq.filter ((<>) ' ') |> Seq.toList |> Day18.parseAndEvaluate)
     
[<Fact>]
let ``Puzzle 1, Finale`` () =
     Ok 21022630974613L =! (readLines "../inputs/Day18.txt" |> Result.map Day18.puzzle1)
     