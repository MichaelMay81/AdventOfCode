module AoC_Mike.Day3

open Helpers

let puzzle1 (input: string[]) =
    let stepsRight = 3
    let numOfColumns = input.[0].Length
    
    input
    |> Seq.mapi (fun i str -> (i*stepsRight%numOfColumns, str))
    |> Seq.map (fun (i, str) -> String.getNth i str)
    |> outputAndRemoveErrors
    |> Seq.filter ((=) '#')
    |> Seq.length
    
let puzzle (input: string[]) (stepsRight:int) (stepsDown:int) : int =    
    let calc numOfColumns =
        input
        |> Seq.mapi (fun i str -> if i % stepsDown = 0 then Some str else None)
        |> Seq.choose id
        |> Seq.mapi (fun i str -> String.getNth (i*stepsRight%numOfColumns) str)
        |> outputAndRemoveErrors
        |> Seq.filter ((=) '#')
        |> Seq.length
    
    input
    |> Array.getNth 0 // get number of columns
    |> function
       | Ok str -> calc str.Length
       | Error str -> outputErrorAndDefault -1 (Error str)
    
let puzzle2 (input: string[]) =
    puzzle input 1 1 *
    puzzle input 3 1 *
    puzzle input 5 1 *
    puzzle input 7 1 *
    puzzle input 1 2