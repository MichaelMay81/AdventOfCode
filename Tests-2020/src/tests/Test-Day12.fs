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
           |> List.map Day12_1.parseNavInst
           |> List.fold (fun state navInst -> Day12_1.processInstruction state navInst) Day12_1.initState
           |> Day12_1.manhattanDistance)
    
[<Fact>]
let ``Test Day 12/1 Final`` () =
    
    Ok 1631 =! (readLines "../inputs/Day12.txt"
                |> Result.map (
                           Seq.map Day12_1.parseNavInst
                           >> Seq.fold (fun state navInst -> Day12_1.processInstruction state navInst) Day12_1.initState
                           >> Day12_1.manhattanDistance))
    
[<Fact>]
let ``Test Day 12/2 Test`` () =
    let input = ["F10"; "N3"; "F7"; "R90"; "F11"]
    
    286 =! (input
            |> List.map Day12_1.parseNavInst
            |> List.fold (fun state navInst -> Day12_2.processInstruction state navInst) Day12_2.initState
            |> (fun state -> state.Ship |> Day12_2.manhattanDistance))
    
[<Fact>]
let ``Test Day 12/2 Final`` () =
    
    Ok 58606 =! (readLines "../inputs/Day12.txt"
                 |> Result.map (
                           Seq.map Day12_1.parseNavInst
                           >> Seq.fold (fun state navInst -> Day12_2.processInstruction state navInst) Day12_2.initState
                           >> (fun state -> state.Ship |> Day12_2.manhattanDistance)))