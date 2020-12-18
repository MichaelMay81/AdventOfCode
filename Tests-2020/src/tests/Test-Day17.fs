module Test_Day17

open System
open Xunit
open Swensen.Unquote
open AoC2020.Helpers
open AoC2020

let input = [".#."
             "..#"
             "###"]

let finaleInput = [".#.####."
                   ".#...##."
                   "..###.##"
                   "#..#.#.#"
                   "#..#...."
                   "#.####.."
                   "##.##..#"
                   "#.#.#..#"]

[<Fact>]
let ``Puzzle 1, Test1`` () =
     let misterRoger = (input |> Day17_1.parse |> (Day17_1.fetchActiveNeighbours {X=0; Y=0; Z=0}) |> Seq.toList)
     1 =! (misterRoger |> List.length)
     
[<Fact>]
let ``Puzzle 1, Test2`` () =
     let misterRoger = (input |> Day17_1.parse |> (Day17_1.fetchActiveNeighbours {X=1; Y=1; Z=0}) |> Seq.toList)
     5 =! (misterRoger |> List.length)
     
[<Fact>]
let ``Puzzle 1, Test3`` () =
     let misterRoger = (input |> Day17_1.parse |> (Day17_1.fetchActiveNeighbours {X=2; Y=2; Z=0}) |> Seq.toList)
     2 =! (misterRoger |> List.length)
     
[<Fact>]
let ``Puzzle 1, Test4`` () =
     112 =! (input |> Day17_1.puzzle 6)
             
[<Fact>]
let ``Puzzle 1, Finale`` () =
     276 =! (finaleInput |> Day17_1.puzzle 6)
     
[<Fact>]
let ``Puzzle 2, Test4`` () =
     848 =! (input |> Day17_2.puzzle 6)
             
[<Fact>]
let ``Puzzle 2, Finale`` () =
     2136 =! (finaleInput |> Day17_2.puzzle 6)