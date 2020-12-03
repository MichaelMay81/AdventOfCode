module AoC_Mike.Day3

open Helpers

let puzzle1 (input: string[]) =
    let stepsRight = 3
    let numOfColumns = input.[0].Length
    
    input
    |> Seq.mapi (fun i str -> (i*stepsRight%numOfColumns, str))
    |> Seq.map (fun (i, str) -> getNth i str)
    |> outputAndRemoveErrors
    |> Seq.filter ((=) '#')
    |> Seq.length
    
let puzzle (input: string[]) (stepsRight:int) (stepsDown:int) =
    let numOfColumns = input.[0].Length
    
    input
    |> Seq.mapi (fun i str -> ((i % stepsDown) = 0 , str))
    |> Seq.filter fst
    |> Seq.mapi (fun i (_, str) -> (i*stepsRight%numOfColumns, str))
    |> Seq.map (fun (i, str) -> getNth i str)
    |> outputAndRemoveErrors
    |> Seq.filter ((=) '#')
    |> Seq.length
    
let puzzle2 (input: string[]) =
    puzzle input 1 1 *
    puzzle input 3 1 *
    puzzle input 5 1 *
    puzzle input 7 1 *
    puzzle input 1 2