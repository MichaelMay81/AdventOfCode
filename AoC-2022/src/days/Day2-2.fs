module AoC2022.Day2_2

open Day2_1
#nowarn "25"

let rpsFromChar : char -> RPS = function
| 'A' -> Rock
| 'B' -> Paper
| 'C' -> Scissors

let outcomeFromChar = function
| 'X' -> Lost
| 'Y' -> Draw
| 'Z' -> Won

let calcMove oponentMove outcome =
    match oponentMove, outcome with
    | (Rock, Won)
    | (Scissors, Lost) -> Paper
    | (Paper, Won)
    | (Rock, Lost) -> Scissors
    | (Scissors, Won)
    | (Paper, Lost) -> Rock
    | _, Draw -> oponentMove

let parse (str:string) : (RPS * Outcome) list =
    str.Split("\n")
    |> Seq.map (fun str ->
        str.Split(" ")
        |> fun strA ->
            strA.[0] |> char |> rpsFromChar,
            strA.[1] |> char |> outcomeFromChar)
    |> Seq.toList

let calcTotalScore (guide:(RPS * Outcome) list) =
    guide
    |> Seq.map (fun (opMove, outcome) ->
        opMove, (calcMove opMove outcome), outcome)
    |> Seq.map (fun (opMove, yourMove, outcome) ->
        (battle opMove yourMove |> calcOutcomeScore)
        + calcRpsScore yourMove)
    |> Seq.sum
    