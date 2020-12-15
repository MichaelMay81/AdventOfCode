module Test_Day08


open System
open Xunit
open Swensen.Unquote
open AoC2020.Helpers
open AoC2020

let getPuzzleInput = Program.getPuzzleInput

let input = ["nop +0"; "acc +1"; "jmp +4"; "acc +3"; "jmp -3"; "acc -99"; "acc +1"; "jmp -4"; "acc +6"] 

[<Fact>]
let ``Test Day 8/1 Test`` () =
    Error 5 =! (input |> Day8_1.puzzle)

[<Fact>]
let ``Test Day 8/1 Final`` () =
    Error 1521 =! (readLines "../inputs/Day8.txt"
               |> function
                  | Error _ -> Ok 0
                  | Ok input -> input |> Day8_1.puzzle)
    
[<Fact>]
let ``Test Day 8/2 Test`` () =
    Ok 8 =! (input |> Day8_2.puzzle)
    
[<Fact>]
let ``Test Day 8/2 Final`` () =
    Ok 1016 =! (readLines "../inputs/Day8.txt"
               |> function
                  | Error _ -> Ok 0
                  | Ok input -> input |> Day8_2.puzzle)