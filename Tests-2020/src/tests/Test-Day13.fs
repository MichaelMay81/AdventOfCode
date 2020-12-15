module Test_Day13

open Xunit
open Swensen.Unquote
open AoC_Mike.Helpers
open AoC_Mike

let getPuzzleInput = Program.getPuzzleInput

[<Fact>]
let ``Test Day 13/1 Test`` () =
    let input = ["939"; "7,13,x,x,59,x,31,19"]
    
    295 =! (input |> Day13.puzzle1)

[<Fact>]
let ``Test Day 13/1 Final`` () =
    Ok 2238 =! (readLines "../inputs/Day13.txt" |> Result.map Day13.puzzle1)