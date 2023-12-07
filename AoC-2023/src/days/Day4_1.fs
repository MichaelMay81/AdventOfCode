module AoC2023.Day4_1

open FSharpPlus

let parse (input : string) =
    input
    |> sscanf "Card %i: %s | %s"
    |> (fun (cardNumber, winNumStr, numStr) ->
        cardNumber,
        winNumStr |> String.split [" "] |> Seq.where ((<>) ""),
        numStr |> String.split [" "] |> Seq.where ((<>) ""))

let analyzeCard (cardNumber:int) (winNumbers:string seq) (numbers:string seq) =
    let winners =
        numbers
        |> Seq.where (flip Seq.contains winNumbers)
        |> Seq.toList

    let points =
        match winners |> List.length with
        | 0 -> 0
        | length ->
            2f ** ((length - 1) |> float32) |> int

    cardNumber, points, winners

let puzzle (input : string seq) =
    input
    |> Seq.map (
        parse
        >> uncurryN analyzeCard)
    |> Seq.map (fun (_, points, _) -> points)
    |> Seq.sum