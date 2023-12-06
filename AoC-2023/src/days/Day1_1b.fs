// Inspired by https://github.com/KaNaDaAT/AOC2023/blob/master/AdventOfCoding/Days/Day01/Day01A.cs

module AoC2023.Day1_1b

open System

let private firstDigit = Seq.find Char.IsDigit
let private lastDigit = Seq.rev >> Seq.find Char.IsDigit

let puzzle1 (input : string seq) =
    input
    |> Seq.map (fun ints ->
        $"{firstDigit ints}{lastDigit ints}")
    |> Seq.map int
    |> Seq.sum