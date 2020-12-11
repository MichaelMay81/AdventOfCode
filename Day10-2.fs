module AoC_Mike.Day10_2

open FSharpPlus
open Helpers

// calculates all valid lists, but that takes time!
let calcValidPermutations (input: int seq) : int list list =
    let sortedList =
        input
        |> Seq.sort
        |> Seq.rev
        |> Seq.toList
        
    let sortedList2 = (sortedList.Head + 3) :: sortedList |> List.rev
    
    let addElToList (el:int) (list:int list) : int list list =
        if (el - list.Head) < 3 then
            [list; el :: list]
        elif (el - list.Head) = 3 then
            [el :: list]
        else []
        
    let rec loop2 (input: int list) (acc: int list list) : int List List =
        match input with
        | [] -> acc
        | newEl :: restInput ->
            let newAcc = 
                acc
                |> Seq.map (addElToList newEl)
                |> Seq.collect id
                |> Seq.toList
            newAcc |> loop2 restInput
            
    loop2 sortedList2 [[0]]
    
// just calculating the numbers, not creating any lists. O(n)
let calcValidPermutations3 (input: int seq) : int64 =
    let sortedList =
        input
        |> Seq.append [0; ((input |> Seq.max) + 3)]
        |> Seq.sort
        |> Seq.toList
        
    let rec calcNumOfPaths (el:int) (elAndCounts:(int*int64) list) (acc:int64) : int64 =
        match elAndCounts with
        | [] -> if acc = 0L then 1L else acc
        | (nextEl, co) :: restECs ->
            if el - nextEl > 3 then
                acc
            else
                calcNumOfPaths el restECs (acc + co)
    
    let rec walkThroughList (elAndCounts:(int*int64) list) (numbers:int list) : int64 =
        match numbers with
        | [] -> elAndCounts.Head |> snd
        | nextEl :: rest ->
            let count = calcNumOfPaths nextEl elAndCounts 0L
            walkThroughList ((nextEl, count) :: elAndCounts) rest
    
    walkThroughList [] sortedList
            
let puzzle (input:string seq) : int64 =
    input
    |> Seq.map int
    |> calcValidPermutations3