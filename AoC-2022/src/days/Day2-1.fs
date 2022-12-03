module AoC2022.Day2_1

#nowarn "25"

type RPS =
| Rock
| Paper
| Scissors

type Outcome =
| Won
| Lost
| Draw

let rpsFromChar : char -> RPS = function
| 'A' | 'X' -> Rock
| 'B' | 'Y' -> Paper
| 'C' | 'Z' -> Scissors

let battle oponent me =
    match (me, oponent) with
    | Rock, Scissors
    | Paper, Rock
    | Scissors, Paper -> Won
    | Rock, Paper
    | Paper, Scissors
    | Scissors, Rock -> Lost
    | _, _ -> Draw
    
let calcRpsScore = function
    | Rock -> 1
    | Paper -> 2
    | Scissors -> 3

let calcOutcomeScore = function
    | Lost -> 0
    | Draw -> 3
    | Won -> 6 

let parse (str:string) : RPS list list =
    str.Split("\n")
    |> Seq.map (fun str ->
        str.Split(" ")
        |> Seq.map(char >> rpsFromChar))
    |> Seq.map Seq.toList
    |> Seq.toList

let calcTotalScore (guide:RPS list list) =
    guide
    |> Seq.map (fun gl ->
        (battle gl.[0] gl.[1] |> calcOutcomeScore)
        + calcRpsScore gl.[1])
    |> Seq.sum