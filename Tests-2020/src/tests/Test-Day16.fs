module Test_Day16

open System
open Xunit
open Swensen.Unquote
open AoC2020.Helpers
open AoC2020

let getPuzzleInput = Program.getPuzzleInput

let input1 = ["class: 1-3 or 5-7"
              "row: 6-11 or 33-44"
              "seat: 13-40 or 45-50"
              ""
              "your ticket:"
              "7,1,14"
              ""
              "nearby tickets:"
              "7,3,47"
              "40,4,50"
              "55,2,20"
              "38,6,12"]

let input2 = ["class: 0-1 or 4-19"
              "row: 0-5 or 8-19"
              "seat: 0-13 or 16-19"
              ""
              "your ticket:"
              "11,12,13"
              ""
              "nearby tickets:"
              "3,9,18"
              "15,1,5"
              "5,14,9"]

[<Fact>]
let ``Puzzle 1, Test1`` () =
     71 =! (input1 |> Day16_1.puzzle)

[<Fact>]
let ``Puzzle 1, Final`` () =
     Ok 26009 =! (readLines "../inputs/Day16.txt" |> Result.map Day16_1.puzzle)
     
[<Fact>]
let ``Puzzle 2, Test1`` () =
     ["row"; "class"; "seat"] =! (input2 |> Day16_2.test1 |> snd |> Seq.toList)
     
[<Fact>]
let ``Puzzle 2, Final`` () =
     Ok 589685618167L =! (readLines "../inputs/Day16.txt" |> Result.map Day16_2.final)