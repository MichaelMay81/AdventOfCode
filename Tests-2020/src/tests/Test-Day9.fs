module Test_Day9

open System
open System.Numerics
open Xunit
open Swensen.Unquote
open AoC_Mike.Helpers
open AoC_Mike

let getPuzzleInput = Program.getPuzzleInput

[<Fact>]
let ``Test Day 9 Test Permutations`` () =
    let input = [1; 2; 3; 4]
    [(1, 2); (1, 3); (1, 4); (2, 3); (2, 4); (3, 4)] =! (input |> Day1.tuplesPerm3 |> Seq.toList)

[<Fact>]
let ``Test Day 9 Test Permutations with Preamble`` () =
    let input = [1; 2; 3; 4]
    let preambleSize = 3
    Ok [(1, 2); (1, 3); (2, 3); (2, 4); (3, 4)] =! (input |> Day9_1.createTuples preambleSize |> (Result.map Seq.toList))

[<Fact>]
let ``Test Day 9 checkXMAS Test1`` () =
    let input = ({1 .. 25} |> Seq.toList) @ [26]
    let preambleSize = 25
    Ok [Some (1,25,26)] =! (input |> Day9_1.checkXMAS preambleSize |> (Result.map Seq.toList))

[<Fact>]    
let ``Test Day 9 checkXMAS Test2`` () =
    let input = ({1 .. 25} |> Seq.toList) @ [49]
    let preambleSize = 25
    Ok [Some (24,25,49)] =! (input |> Day9_1.checkXMAS preambleSize |> (Result.map Seq.toList))

[<Fact>]
let ``Test Day 9 checkXMAS Test3`` () =
    let input = ({1 .. 25} |> Seq.toList) @ [100]
    let preambleSize = 25
    Ok [None] =! (input |> Day9_1.checkXMAS preambleSize |> (Result.map Seq.toList))
    
[<Fact>]
let ``Test Day 9 checkXMAS Test4`` () =
    let input = ({1 .. 25} |> Seq.toList) @ [50]
    let preambleSize = 25
    Ok [None] =! (input |> Day9_1.checkXMAS preambleSize |> (Result.map Seq.toList))
    
[<Fact>]
let ``Test Day 9 checkXMAS2 Test1`` () =
    let input = ({1L .. 25L} |> Seq.toList) @ [26L]
    let preambleSize = 25
    Ok [Ok (1L,25L,26L)] =! (input |> Day9_1.checkXMAS2 preambleSize |> (Result.map Seq.toList))

[<Fact>]    
let ``Test Day 9 checkXMAS2 Test2`` () =
    let input = ({1L .. 25L} |> Seq.toList) @ [49L]
    let preambleSize = 25
    Ok [Ok (24L,25L,49L)] =! (input |> Day9_1.checkXMAS2 preambleSize |> (Result.map Seq.toList))

[<Fact>]
let ``Test Day 9 checkXMAS2 Test3`` () =
    let input = ({1L .. 25L} |> Seq.toList) @ [100L]
    let preambleSize = 25
    Ok [Error 100L] =! (input |> Day9_1.checkXMAS2 preambleSize |> (Result.map Seq.toList))
    
[<Fact>]
let ``Test Day 9 checkXMAS2 Test4`` () =
    let input = ({1L .. 25L} |> Seq.toList) @ [50L]
    let preambleSize = 25
    Ok [Error 50L] =! (input |> Day9_1.checkXMAS2 preambleSize |> (Result.map Seq.toList))
    
//[<Fact>]
//let ``Test Day 9 checkXMAS Test5`` () =
//    let input = [35; 20; 15; 25; 47; 40; 62; 55; 65; 95; 102; 117; 150; 182; 127; 219; 299; 277; 309; 576]
//    let preambleSize = 5
//    Ok [None] =! (input |> Day9.checkXMAS preambleSize |> (Result.map Seq.toList))

[<Fact>]
let ``Test Day 9 checkXMAS2 Test5`` () =
    let input = [35; 20; 15; 25; 47; 40; 62; 55; 65; 95; 102; 117; 150; 182; 127; 219; 299; 277; 309; 576]
                |> List.map int64
    let preambleSize = 5
    Ok [127L] =! (input
                 |> Day9_1.checkXMAS2 preambleSize
                 |> (Result.map (Seq.choose (function Ok _ -> None | Error e -> Some e)>> Seq.toList )))
    
[<Fact>]
let ``Test Day 9/1 Final`` () =
    let preambleSize = 25
    Ok 15690279L =! (readLines "../inputs/Day9.txt" |> Result.bind (Day9_1.puzzle preambleSize))

[<Fact>]
let ``Test Day 9/2 Test`` () =
    let input = [35; 20; 15; 25; 47; 40; 62; 55; 65; 95; 102; 117; 150; 182; 127; 219; 299; 277; 309; 576] |> List.map int64
    let invNumber = 127L
    [40L; 47L; 25L; 15L] =! Day9_2.findXmasRange invNumber input
    
[<Fact>]
let ``Test Day 9/2 Final`` () =
    let invNumber = 15690279L
    Ok 2174232L  =! (readLines "../inputs/Day9.txt" |> Result.map (Day9_2.puzzle invNumber))