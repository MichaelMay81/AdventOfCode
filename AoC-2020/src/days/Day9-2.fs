module AoC_Mike.Day9_2

open System.Numerics
open FSharpPlus
open FSharpPlus.Control
open FSharpPlus.Internals
open Helpers

let findXmasRange (invNumber:int64) (input:int64 list) =
    let rec loop (input:int64 list) (resultList:int64 list) (sum:int64) =
        if sum = invNumber then
            resultList
        elif sum > invNumber then
            match resultList |> List.rev with
                | [] -> []
                | bottom :: resultList ->
                    loop input (resultList |> List.rev) (sum - bottom)
        else match input with
             | [] -> []
             | head :: input ->
                 loop input (head :: resultList) (sum + head)
                 
    loop input [] 0L
                

let puzzle (invNumber:int64) (input:string seq) : int64 =
    input
    |> Seq.toList
    |> List.map int64
    |> (findXmasRange invNumber)
    |> List.map (fun foobar -> printfn "%A" foobar; foobar)
    |> (fun list -> (list |> List.min) + (list |> List.rev |> List.max))