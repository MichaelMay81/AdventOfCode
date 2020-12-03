module AoC_Mike.Helpers

open System.IO

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
let outputError (input: Result<'a, string>) : unit =
    match input with
    | Error str -> printfn "Error: %s" str
    | _ -> ()

let outputErrorAndDefault (defaultValue:'a) (input: Result<'a, string>) : 'a =
    match input with
    | Error _ ->
            outputError input
            defaultValue
    | Ok value -> value
    
let addLineNumToError i result = match result with
                                 | Error e -> Error (e + ", line " + i.ToString())
                                 | Ok v -> Ok v
                                 
let outputAndRemoveErrors (input: Result<'a, string> seq) : 'a seq =
    input |> Seq.mapi addLineNumToError
          |> Seq.map (tee outputError)
          |> Seq.choose (function Ok value -> Some value | Error _ -> None)