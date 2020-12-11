module Test_Day10

open Xunit
open Swensen.Unquote
open AoC_Mike.Helpers
open AoC_Mike

let getPuzzleInput = Program.getPuzzleInput

let input1 = [16; 10; 15; 5; 1; 11; 7; 19; 6; 12; 4]
let input2 = [28; 33; 18; 42; 31; 14; 46; 20; 48; 47; 24; 23; 49; 45; 19
              38; 39; 11; 1; 32; 25; 35; 8; 17; 7; 9; 4; 2; 34; 10; 3]

[<Fact>]
let ``Test Day 10/1 Test1`` () =
    [(3, 5); (1, 7)] =! (input1 |> Day10_1.calcDistOfJoltage)
    
[<Fact>]
let ``Test Day 10/1 Test2`` () =
    [(3, 10); (1, 22)] =! (input2 |> Day10_1.calcDistOfJoltage)

[<Fact>]
let ``Test Day 10/1 Final`` () =
    Ok 2400 =! (readLines "Inputs/Day10.txt"
               |> Result.map Day10_1.puzzle)
    
[<Fact>]
let ``Test Day 10/2 Test1`` () =
    let result = [[0; 1; 4; 5; 6; 7; 10; 11; 12; 15; 16; 19; 22]
                  [0; 1; 4; 5; 6; 7; 10; 12; 15; 16; 19; 22]
                  [0; 1; 4; 5; 7; 10; 11; 12; 15; 16; 19; 22]
                  [0; 1; 4; 5; 7; 10; 12; 15; 16; 19; 22]
                  [0; 1; 4; 6; 7; 10; 11; 12; 15; 16; 19; 22]
                  [0; 1; 4; 6; 7; 10; 12; 15; 16; 19; 22]
                  [0; 1; 4; 7; 10; 11; 12; 15; 16; 19; 22]
                  [0; 1; 4; 7; 10; 12; 15; 16; 19; 22]] |> List.rev |> List.map List.rev
    result =! (input1 |> Day10_2.calcValidPermutations)
    
[<Fact>]
let ``Test Day 10/2 Test2`` () =
    let someResults = [
        [0; 1; 2; 3; 4; 7; 8; 9; 10; 11; 14; 17; 18; 19; 20; 23; 24; 25; 28; 31; 32; 33; 34; 35; 38; 39; 42; 45; 46; 47; 48; 49; 52]
        [0; 1; 2; 3; 4; 7; 8; 9; 10; 11; 14; 17; 18; 19; 20; 23; 24; 25; 28; 31; 32; 33; 34; 35; 38; 39; 42; 45; 46; 47; 49; 52]
        [0; 1; 2; 3; 4; 7; 8; 9; 10; 11; 14; 17; 18; 19; 20; 23; 24; 25; 28; 31; 32; 33; 34; 35; 38; 39; 42; 45; 46; 48; 49; 52]
        [0; 1; 2; 3; 4; 7; 8; 9; 10; 11; 14; 17; 18; 19; 20; 23; 24; 25; 28; 31; 32; 33; 34; 35; 38; 39; 42; 45; 46; 49; 52]
        [0; 1; 2; 3; 4; 7; 8; 9; 10; 11; 14; 17; 18; 19; 20; 23; 24; 25; 28; 31; 32; 33; 34; 35; 38; 39; 42; 45; 47; 48; 49; 52]
        [0; 3; 4; 7; 10; 11; 14; 17; 20; 23; 25; 28; 31; 34; 35; 38; 39; 42; 45; 46; 48; 49; 52]
        [0; 3; 4; 7; 10; 11; 14; 17; 20; 23; 25; 28; 31; 34; 35; 38; 39; 42; 45; 46; 49; 52]
        [0; 3; 4; 7; 10; 11; 14; 17; 20; 23; 25; 28; 31; 34; 35; 38; 39; 42; 45; 47; 48; 49; 52]
        [0; 3; 4; 7; 10; 11; 14; 17; 20; 23; 25; 28; 31; 34; 35; 38; 39; 42; 45; 47; 49; 52]
        [0; 3; 4; 7; 10; 11; 14; 17; 20; 23; 25; 28; 31; 34; 35; 38; 39; 42; 45; 48; 49; 52]] |> List.rev |> List.map List.rev

    let result = (input2 |> Day10_2.calcValidPermutations)
    test <@ someResults |> List.forall (fun list -> result |> List.contains list) @>
    
[<Fact>]
let ``Test Day 10/2 Test3`` () =
    19208 =! (input2 |> Day10_2.calcValidPermutations |> List.length)

[<Fact>]
let ``Test Day 10/2 Final`` () =
    Ok 338510590509056L =! (readLines "Inputs/Day10.txt"
                |> Result.map Day10_2.puzzle)