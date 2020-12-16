module Test_Day16

open System
open Xunit
open Swensen.Unquote
open AoC2020.Helpers
open AoC2020

let getPuzzleInput = Program.getPuzzleInput

let input = ["class: 1-3 or 5-7"
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

[<Fact>]
let ``Puzzle 1, Test1`` () =
     71 =! (input |> Day16.puzzle1)

[<Fact>]
let ``Puzzle 1, Final`` () =
     Ok 26009 =! (readLines "../inputs/Day16.txt" |> Result.map Day16.puzzle1)