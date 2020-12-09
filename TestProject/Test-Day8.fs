module Test_Day8


open System
open Xunit
open Swensen.Unquote
open AoC_Mike.Helpers
open AoC_Mike

let getPuzzleInput = Program.getPuzzleInput

let input = ["nop +0"; "acc +1"; "jmp +4"; "acc +3"; "jmp -3"; "acc -99"; "acc +1"; "jmp -4"; "acc +6"] 

[<Fact>]
let ``Test Day 8/1 Test`` () =
    5 =! (input |> Day8.puzzle1)

[<Fact>]
let ``Test Day 8/1 Final`` () =
    Ok 1521 =! (readLines "Inputs/Day8.txt" |> Result.map Day8.puzzle1)