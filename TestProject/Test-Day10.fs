module Test_Day10


open Xunit
open Swensen.Unquote
open AoC_Mike.Helpers
open AoC_Mike

let getPuzzleInput = Program.getPuzzleInput

[<Fact>]
let ``Test Day 10/1 Test1`` () =
    let input = [16; 10; 15; 5; 1; 11; 7; 19; 6; 12; 4]
    [(3, 5); (1, 7)] =! (input |> Day10.calcDistOfJoltage)
    
[<Fact>]
let ``Test Day 10/1 Test2`` () =
    let input = [28; 33; 18; 42; 31; 14; 46; 20; 48; 47; 24; 23; 49; 45; 19
                 38; 39; 11; 1; 32; 25; 35; 8; 17; 7; 9; 4; 2; 34; 10; 3]
    [(3, 10); (1, 22)] =! (input |> Day10.calcDistOfJoltage)

[<Fact>]
let ``Test Day 10/1 Final`` () =
    Ok 2400 =! (readLines "Inputs/Day10.txt"
               |> Result.map Day10.puzzle1)