module Test_Day12


open Xunit
open Swensen.Unquote
open AoC_Mike.Helpers
open AoC_Mike

let getPuzzleInput = Program.getPuzzleInput

[<Fact>]
let ``Test Day 12/1 Test`` () =
    let input = ["F10"; "N3"; "F7"; "R90"; "F11"]
    
    25 =! (input
           |> List.map Day12.parseNavInst
           |> List.fold (fun state navInst -> Day12.processInstruction state navInst) Day12.initState
           |> Day12.manhattenDistance)
    
[<Fact>]
let ``Test Day 12/1 Final`` () =
    
    Ok 25 =! (readLines "Inputs/Day12.txt"
             |> Result.map (
                           Seq.map Day12.parseNavInst
                           >> Seq.fold (fun state navInst -> Day12.processInstruction state navInst) Day12.initState
                           >> Day12.manhattenDistance))