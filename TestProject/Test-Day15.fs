module Test_Day15

open Xunit
open Swensen.Unquote
open AoC_Mike.Helpers
open AoC_Mike

let getPuzzleInput = Program.getPuzzleInput

[<Fact>]
let ``Test Day 15/1 Test1`` () =
    0 =! ([0; 3; 6] |> Day15.puzzle1 10)

[<Fact>]
let ``Test Day 15/1 Test2`` () =
    436 =! ([0; 3; 6] |> Day15.puzzle1 2020)

[<Fact>]
let ``Test Day 15/1 Test3`` () =
    1 =! ([1; 3; 2] |> Day15.puzzle1 2020)
     
[<Fact>]
let ``Test Day 15/1 Test4`` () =
    10 =! ([2; 1; 3] |> Day15.puzzle1 2020)
     
[<Fact>]
let ``Test Day 15/1 Test5`` () =
    27 =! ([1; 2; 3] |> Day15.puzzle1 2020)
     
[<Fact>]
let ``Test Day 15/1 Test6`` () =
    78 =! ([2; 3; 1] |> Day15.puzzle1 2020)
    
[<Fact>]
let ``Test Day 15/1 Test7`` () =
    438 =! ([3; 2; 1] |> Day15.puzzle1 2020)
     
[<Fact>]
let ``Test Day 15/1 Test8`` () =
    1836 =! ([3; 1; 2] |> Day15.puzzle1 2020)

[<Fact>]
let ``Test Day 15/1 Final`` () =
    203 =! ([0; 5; 4; 1; 10; 14; 7] |> Day15.puzzle1 2020)
    