module Test_Day06

open System
open Xunit
open Swensen.Unquote
open AoC2020.Helpers
open AoC2020

let getPuzzleInput = Program.getPuzzleInput

let input1 = ["abcx"; "abcy"; "abcz"]
let input2 = ["abc"; ""; "a"; "b"; "c"; ""; "ab"; "ac"; ""; "a"; "a"; "a"; "a"; ""; "b"]

[<Fact>]
let ``Puzzle 1, Test1`` () =
     6 =! (input1 |> Day6.puzzle1)

[<Fact>]     
let ``Puzzle 1, Test2`` () =
    11 =! (input2 |> Day6.puzzle1)
    
[<Fact>]
let ``Puzzle 1, Final`` () =
     Ok 6903 =! (readLines "../inputs/Day6.txt" |> Result.map Day6.puzzle1)
    
    
[<Fact>]
let ``Puzzle 2, Test1`` () =
     3 =! (input1 |> Day6.puzzle2)

[<Fact>]     
let ``Puzzle 2, Test2`` () =
    6 =! (input2 |> Day6.puzzle2)
    
[<Fact>]
let ``Puzzle 2, Final`` () =
     Ok 3493 =! (readLines "../inputs/Day6.txt" |> Result.map Day6.puzzle2)
