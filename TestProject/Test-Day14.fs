module Test_Day14

open Xunit
open Swensen.Unquote
open AoC_Mike.Helpers
open AoC_Mike

let getPuzzleInput = Program.getPuzzleInput

[<Fact>]
let ``Test Day 14/1 Test`` () =
    let input = ["mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X"
                 "mem[8] = 11"
                 "mem[7] = 101"
                 "mem[8] = 0"]
    
    165L =! (input |> Day14.puzzle1)

[<Fact>]
let ``Test Day 14/1 Final`` () =
    Ok 2238L =! (readLines "Inputs/Day14.txt" |> Result.map Day14.puzzle1)