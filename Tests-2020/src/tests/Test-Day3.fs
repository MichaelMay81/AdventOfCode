module Test_Day03

open System
open Xunit
open Swensen.Unquote
open AoC2020.Helpers
open AoC2020

let getPuzzleInput = Program.getPuzzleInput

let input = [|"..##......."
              "#...#...#.."
              ".#....#..#."
              "..#.#...#.#"
              ".#...##..#."
              "..#.##....."
              ".#.#.#....#"
              ".#........#"
              "#.##...#..."
              "#...##....#"
              ".#..#...#.#"|]

[<Fact>]
let ``Puzzle 1, Test`` () =
    7 =! (Day3.puzzle1 input)

[<Fact>]
let ``Puzzle 1, Finale`` () =
    257 =! (getPuzzleInput "../inputs/Day3.txt" |> Seq.toArray |> Day3.puzzle1)

[<Fact>]
let ``Puzzle 2, Test`` () =
    336 =! (Day3.puzzle2 input)

[<Fact>]
let ``Puzzle 2, Final`` () =
    Ok 1744787392 =! (readLines "../inputs/Day3.txt" |> Result.map ( Seq.toArray >> Day3.puzzle2))