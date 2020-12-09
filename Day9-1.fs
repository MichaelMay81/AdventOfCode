module AoC_Mike.Day9_1

open System.Numerics
open FSharpPlus
open FSharpPlus.Control
open FSharpPlus.Internals
open Helpers

let createTuples (preambleSize:int) (input:int list) : Result<(int*int) seq, string> =
    let rec loop (preamble:int seq) (list:int list) (acc:(int*int) seq): (int*int) seq =
        match list with
        | [] -> acc
        | el :: list ->
            let tupEl1 elN = (elN, el)
            let preamble = preamble |> Seq.skip 1
            let acc = preamble |> Seq.map tupEl1 |> (Seq.append acc)
            let preamble = [el] |> Seq.append preamble
            loop preamble list acc
    
    if preambleSize > (input |> List.length) then
        Error "preambleSize can't be bigger than size of input!"
    else
        let preamble = input |> List.take preambleSize
        let list = input |> List.skip preambleSize
        
        let preambleTups = Day1.tuplesPerm3 preamble
        let restTups = loop preamble list []
        
        Ok (restTups |> Seq.append preambleTups)
        

let nthTriangularNumber (n:int) =
    ((int (float n ** 2.) +  n) / 2)

// not working :(
let checkXMAS (preambleSize:int) (input:int seq) : Result<(int*int*int) option seq, string> =
    let input = input |> Seq.toList
    let checkIds = {preambleSize .. (input |> Seq.length) - 1}
    
    let check (tuples:(int*int*int) seq) (id:int) : (int*int*int) option =
        let preamble = tuples
                       |> (Seq.skip ((preambleSize-1) * (id - preambleSize)))
                       |> Seq.take (nthTriangularNumber (preambleSize - 1))
        let element = input |> Seq.item id
//        prbigintfn "%A %A %A" (id - preambleSize) ((preambleSize-1) * (id - preambleSize)) (nthTriangularNumber (preambleSize-1))
//        prbigintfn "%A is in %A" element preamble
        preamble
        |> Seq.filter (fun (_, _, el3) -> el3 = element)
        |> Seq.tryHead
        
    let tuplesCheck = createTuples preambleSize input
                      |> Result.map (Seq.map (fun (e1, e2) -> (e1, e2, e1 + e2)))
                      |> Result.map check
    
    let foobar = tuplesCheck
                 |> Result.map (fun f -> (checkIds |> Seq.map f))
//                 |> Result.map (Seq.map (Option.map (fun (e1, e2, _) -> (e1, e2))))
    foobar

// simpler less performant version, but at least it works :)
let checkXMAS2 (preambleSize:int) (input:int64 seq) : Result<Result<(int64*int64*int64), int64> seq, string> =
    if preambleSize > (input |> Seq.length) then
        Error "preambleSize can't be bigger than size of input!"
    else
        let getPreamble i = input
                            |> Seq.skip (i - preambleSize)
                            |> Seq.take preambleSize
                            |> Seq.toList
                            |> Day1.tuplesPerm3
                            |> Seq.map (fun (e1, e2) -> (e1, e2, e1 + e2))
        
        let getResult (el:int64) (preamble:(int64*int64*int64) seq) =
            preamble
            |> Seq.filter (fun (_, _, e3) -> e3 = el)
            |> Seq.tryHead
            |> Option.toResultWith el
        
        {preambleSize .. (input |> Seq.length) - 1}
//        |> Seq.map (fun i -> printfn "%A in %A" (input |> Seq.item i) (getPreamble i); i)
        |> Seq.map (fun i -> getResult (input |> Seq.item i) (getPreamble i))
        |> Ok
    

let puzzle (preambleSize:int) (input:string seq) : Result<int64, string> =
    input
    |> Seq.toList
    |> List.map int64
    |> (checkXMAS2 preambleSize)
    |> (Result.bind (Seq.choose (function Ok _ -> None | Error e -> Some e)
                    >> Seq.tryHead
                    >> Option.toResultWith "All values valid." ))
    
