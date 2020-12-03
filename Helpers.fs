module AoC_Mike.Helpers

open System.IO

let filter (input: Result<'a, string> seq) : 'a seq =
    let errors = input
                 |> Seq.mapi (fun i e -> i, e)
                 |> Seq.choose (function (i, Error e) -> Some (i, e) | _ -> None)
                 
    for i, e in errors do
        printfn "Error (%i): %s" (i+1) e
        
    input |> Seq.choose (function Ok v -> Some v | _ -> None)

let tee deadEndFunction oneTrackInput =
    deadEndFunction oneTrackInput
    oneTrackInput

let readLines filePath : Result<string seq, string> =
    let filePath = Path.Combine(__SOURCE_DIRECTORY__, filePath)
    try
        Ok (File.ReadLines(filePath))
    with
    | :? FileNotFoundException -> Error ("Couldn't load file " + filePath)

let getNth (i:int) (s:string) =
    let rec loop c cl =
        match c, cl with
        | 0, e :: _ -> Ok e
        | _, [] -> Error ("no " + (string i) + "th element in '" + s + "'")
        | _, _ :: rest -> loop (c-1) rest
    loop i (s |> Seq.toList)

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