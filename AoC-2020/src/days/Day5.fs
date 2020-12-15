module AoC2020.Day5

open FSharpPlus

let puzzleCharToBinary = function
    | 'F' -> Some 0
    | 'B' -> Some 1
    | 'L' -> Some 0
    | 'R' -> Some 1
    | _ -> None

let puzzleStringToInt (input: string) : int =
    let foobar i c = c * (i ** 2.0)
    input
    |> String.toList
    |> List.rev
//    |> Seq.map (fun v -> printfn "%A" v; v)
    |> Seq.mapi (fun i c -> c
                            |> puzzleCharToBinary
                            |> Option.map (float >> (*) (2. ** (float i)) >> int))
//    |> Seq.map (fun v -> printfn "%A" v; v)
    |> Seq.choose id
    |> Seq.sum
    
let puzzle1 (input: string seq) =
    let seatsTaken = input |> Seq.map puzzleStringToInt
    seatsTaken |> Seq.max
    
let puzzle2 (input: string seq) =
    let seatsTaken = input |> Seq.map puzzleStringToInt
    let max = seatsTaken |> Seq.max
    let min = seatsTaken |> Seq.min
    {min .. max}
    |> Seq.map (fun i -> i, not (Seq.contains i seatsTaken))
    |> Seq.filter snd
    |> Seq.head
    |> fst