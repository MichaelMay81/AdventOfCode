module AoC2021.Day10

open FSharpPlus

[<Literal>]
let RoundBracketClosed   = ')' // parentheses
[<Literal>]
let SquareBracketClosed  = ']' // brackets
[<Literal>]
let CurlyBracketClosed   = '}' // braces
[<Literal>]
let AngleBracketsClosed  = '>' // chevrons
let openBrackets = "([{<"
let closingBrackets = ")]}>"

let corresponds (openBracket:char) (closingBracket:char) =
    let i1 = openBrackets |> Seq.findIndex ((=)openBracket)
    let i2 = closingBrackets |> Seq.findIndex ((=) closingBracket)
    i1 = i2

let checkChar (c:char) (bracketStack:char list) =
    match openBrackets |> Seq.contains c with
    // open bracket
    | true -> 0, c :: bracketStack
    // closing bracket
    | false ->
        match bracketStack with
        // end of stack
        | [] -> failwith "mmmm" //-1, []
        | head :: tail ->
            match corresponds head c with
            // found closing to corresponding open bracket
            | true -> 0, tail
            // incorrect closing bracket
            | false ->
                match c with
                | RoundBracketClosed  -> 3, tail
                | SquareBracketClosed -> 57, tail
                | CurlyBracketClosed  -> 1197, tail
                | AngleBracketsClosed -> 25137, tail
                | _ -> failwith "wtf" //-2, tail

let rec checkLine (bracketStack:char list) (line:char list) =
    match line with
    | [] -> 0, bracketStack
    | head::restLine ->
        match checkChar head bracketStack with
        | 0, newBracketStack -> checkLine newBracketStack restLine
        | error, _ -> error, bracketStack

let puzzle1 (chunkLines:string seq) =
    chunkLines
    |> Seq.map (String.toList >> checkLine [] >> fst)
    |> Seq.sum

let openToClosing (openBracket:char) :char =
    let i = openBrackets |> Seq.findIndex ((=)openBracket)
    closingBrackets |> Seq.item i
    
let puzzle2 (chunkLines: string seq) =
    let rec opensToClosings input output =
        match input with
        | [] -> output |> List.rev
        | head :: tail ->
            opensToClosings tail ((openToClosing head) :: output)

    let rec calcScore (score:int64) input =
        match input with
        | [] -> score
        | head :: tail ->
            match head with
                | RoundBracketClosed  -> calcScore (score * 5L + 1L) tail
                | SquareBracketClosed -> calcScore (score * 5L + 2L) tail
                | CurlyBracketClosed  -> calcScore (score * 5L + 3L) tail
                | AngleBracketsClosed -> calcScore (score * 5L + 4L) tail
                | _ -> failwith "this shouldn't happen..."

    let scores =
        chunkLines
        |> Seq.map (fun line -> line, line |> String.toList |> checkLine [])
        |> Seq.filter (snd >> fst >> ((=) 0))
        |> Seq.map (fun (line, (_, stack)) -> opensToClosings stack [] |> calcScore 0)
        |> Seq.sort
        |> Seq.toList
    
    scores |> item (scores |> length |> (flip (/) 2))