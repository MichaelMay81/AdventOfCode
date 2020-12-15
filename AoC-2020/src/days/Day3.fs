module AoC2020.Day3

open FSharpPlus
open Helpers

let private getNthInString i str =
    str
    |> String.tryItem i
    |> Option.toResultWith (sprintf "no %ith element in %A" i str)
    
let puzzle1 (input: string[]) =
    let stepsRight = 3
    let numOfColumns = input.[0].Length
    
    input
    |> Seq.mapi (fun i str -> (i*stepsRight%numOfColumns, str))
    |> Seq.map (fun (i, str) -> getNthInString i str)
    |> outputAndRemoveErrors
    |> Seq.filter ((=) '#')
    |> Seq.length
    
let puzzle (input: string[]) (stepsRight:int) (stepsDown:int) : int =
    
    let calc numOfColumns =
        input
        |> Seq.mapi (fun i str -> if i % stepsDown = 0 then Some str else None)
        |> Seq.choose id
        |> Seq.mapi (fun i str -> getNthInString (i*stepsRight%numOfColumns) str)
        |> outputAndRemoveErrors
        |> Seq.filter ((=) '#')
        |> Seq.length
    
    input
    // get number of columns
    |> Array.tryHead
    |> function
       | Some str ->
           if str = "" then
               Error (sprintf "First element of %A is empty" input)
           else Ok (calc str.Length)
       | None -> Error (sprintf "Couldn't access first element of %A" input)
    |> outputErrorAndDefault -1
    
let puzzle2 (input: string[]) =
    [(1, 1)
     (3, 1)
     (5, 1)
     (7, 1)
     (1, 2)]
    |> List.map (fun (v1, v2) -> puzzle input v1 v2)
    |> List.fold (*) 1
    
//    puzzle input 1 1 *
//    puzzle input 3 1 *
//    puzzle input 5 1 *
//    puzzle input 7 1 *
//    puzzle input 1 2