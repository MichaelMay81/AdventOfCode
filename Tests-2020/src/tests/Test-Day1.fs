module Test_Day01

open System
open Xunit
open Swensen.Unquote
open AoC2020.Helpers
open AoC2020

let getPuzzleInput = Program.getPuzzleInput

let input = [ 1721; 979; 366; 299; 675; 1456 ]
    
[<Fact>]
let ``Puzzle 1, Test`` () =
    // xunit:
    Assert.Equal(514579, Day1.puzzle1 input)
    
    // unquote:
    // test <@ 4 = Day1.puzzle1 input) @>
    // 4 =! Day1.puzzle1 input
    
[<Fact>]
let ``Puzzle 1, Final`` () =
    let result = (getPuzzleInput "../inputs/Day1.txt" |> Seq.toList |> List.map int |> Day1.puzzle1)
    888331 =! result
    
[<Fact>]
let ``Puzzle 2, Test`` () =
    // xunit:
    Assert.Equal(241861950, Day1.puzzle2 input)
    
    // unquote:
    // test <@ 4 = Day1.puzzle1 input) @>
    // 4 =! Day1.puzzle1 input
    
[<Fact>]
let ``Puzzle 2, Final`` () =
    let result = (getPuzzleInput "../inputs/Day1.txt" |> Seq.toList |> List.map int |> Day1.puzzle2)
    130933530 =! result