module Test_Day14

open Xunit
open Swensen.Unquote
open AoC2020.Helpers
open AoC2020

let getPuzzleInput = Program.getPuzzleInput

[<Fact>]
let ``Test Day 14/1 Test`` () =
    let input = ["mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X"
                 "mem[8] = 11"
                 "mem[7] = 101"
                 "mem[8] = 0"]
    
    165L =! (input |> Day14_1.puzzle)

[<Fact>]
let ``Test Day 14/1 Final`` () =
    Ok 7440382076205L =! (readLines "../inputs/Day14.txt" |> Result.map Day14_1.puzzle)
    
[<Fact>]
let ``Test Day 14/2 Test`` () =
    let input = ["mask = 000000000000000000000000000000X1001X"
                 "mem[42] = 100"
                 "mask = 00000000000000000000000000000000X0XX"
                 "mem[26] = 1"]
    
    208L =! (input |> Day14_2.puzzle)
    
[<Fact>]
let ``Test Day 14/2 Final`` () =
    Ok 4200656704538L =! (readLines "../inputs/Day14.txt" |> Result.map Day14_2.puzzle)