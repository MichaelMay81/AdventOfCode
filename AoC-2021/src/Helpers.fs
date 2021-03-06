module AoC2021.Helpers

open System.IO
open System

let tee deadEndFunction oneTrackInput =
    deadEndFunction oneTrackInput
    oneTrackInput

let readLines filePath : Result<string seq, string> =
    let filePath = Path.Combine(__SOURCE_DIRECTORY__, filePath)
    try
        Ok (File.ReadLines(filePath))
    with
    | :? FileNotFoundException -> Error ("Couldn't load file " + filePath)

// ---- Error Handling ----
let outputError (input:Result<'a, string>) : unit =
    match input with
    | Error str -> printfn "Error: %s" str
    | _ -> ()

let outputErrorAndDefault (defaultValue:'a) (input:Result<'a, string>) : 'a =
    match input with
    | Error _ ->
        outputError input
        defaultValue
    | Ok value -> value
    
let addLineNumToError i result = match result with
                                 | Error e -> Error (e + ", line " + i.ToString())
                                 | Ok v -> Ok v
                                 
let outputAndRemoveErrors (input:Result<'a, string> seq) : 'a seq =
    input |> Seq.mapi addLineNumToError
          |> Seq.map (tee outputError)
          |> Seq.choose (function Ok value -> Some value | Error _ -> None)

let getPuzzleInput filePath =
    readLines filePath |> outputErrorAndDefault Seq.empty

let getPuzzleInputAsInt filePath =
    getPuzzleInput filePath |> Seq.map int |> Seq.toList

let getPuzzleInputAsBinaryInt filePath =
    getPuzzleInput filePath |> Seq.map (fun str -> Convert.ToInt32(str, 2)) |> Seq.toList

let triplewise list =
    let rec twRec acc = function
        | [] | [_] | [_; _] -> acc |> List.rev
        | x1 :: x2 :: x3 :: tail ->
            x2 :: x3 :: tail
            |> twRec ((x1,x2,x3)::acc)
    twRec [] list

let MapTryGetValue k m =
    m
    |> Map.containsKey k
    |> function
        | false -> None
        | true -> Some m.[k]