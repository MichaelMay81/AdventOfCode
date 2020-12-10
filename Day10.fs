module AoC_Mike.Day10

open FSharpPlus
open Helpers

let calcDistOfJoltage (input: int seq) : (int*int) list =
    let sortedList =
        input
        |> Seq.sort
        |> Seq.append [0]
        |> Seq.rev
        |> Seq.toList
        
    let sortedList2 = (sortedList.Head + 3) :: sortedList
    
    let foobar =
        sortedList2
        |> Seq.pairwise
        |> Seq.map (fun (a, b) -> a - b)
        |> Seq.groupBy id
        |> Seq.map (fun (key, ints) -> (key, ints |> Seq.length) )
        |> Seq.toList
    
    foobar

let puzzle1 (input:string seq) : int =
    input
    |> Seq.map int
    |> calcDistOfJoltage
    |> Seq.map snd
    |> Seq.fold (*) 1