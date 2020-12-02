module AoC_Mike.Day2

open FSharpPlus
open Helpers

type Policy1 = {
    Min: int
    Max: int
    Char: char
}
type Policy2 = {
    Pos1: int
    Pos2: int
    Char: char
}
type Policy =
    | Policy1 of Policy1
    | Policy2 of Policy2
    
type PolPass = {
    Policy: Policy
    Password: string
}

let parse (input:string) : Result<int*int*char*string, string> =
    input
    |> (fun str -> str, trySscanf "%i-%i %c: %s" str)
    |> (function
          | str, None -> Error ("couldn't parse: '" + str + "'")
          | _, Some (val1, val2, char, pass) -> Ok (val1, val2, char, pass))

let parsePolicy1 (input:string) : Result<PolPass, string> =
    let constructor = fun (v1, v2, c, p) -> {Policy = Policy1 {Min=v1; Max=v2; Char=c}; Password=p}
    input |> parse |> Result.map constructor
    
let parsePolicy2 (input:string) : Result<PolPass, string> =
    let constructor = fun (v1, v2, c, p) -> {Policy = Policy2 {Pos1=v1; Pos2=v2; Char=c}; Password=p}
    input |> parse |> Result.map constructor

let isPassCorrect (polPass: PolPass) : bool =
    match polPass with
    | { Policy= Policy1 policy; Password=password } ->
        let count = password |> Seq.filter ((=) policy.Char) |> Seq.length
        count >= policy.Min && count <= policy.Max
    | { Policy= Policy2 policy; Password=password } ->
        password
        |> Seq.mapi (fun i s -> (i+1),s)
        |> Seq.filter (fun (i,s) -> (s = policy.Char) && (i = policy.Pos1 || i = policy.Pos2))
        |> Seq.length = 1

let puzzle parser (input: string seq) : int =
    input |> Seq.map (parser >> Result.map isPassCorrect) // parse and check password
          |> outputAndRemoveErrors
          |> Seq.filter id // filter out all Trues
          |> Seq.length // how many valid passwords are there
    
let puzzle1 input =
    puzzle parsePolicy1 input
    
let puzzle2 input =
    puzzle parsePolicy2 input