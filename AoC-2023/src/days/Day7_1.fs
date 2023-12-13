module AoC2023.Day7_1

open FSharpPlus

let isFiveOfAKind : char seq -> bool =
    Seq.groupBy id
    >> Seq.length
    >> (=) 1

let isFourOfAKind : char seq -> bool = 
    Seq.groupBy id
    >> Seq.map (snd >> Seq.length)
    >> Seq.exists ((=) 4)

let isFullHouse : char seq -> bool = 
    Seq.groupBy id
    >> Seq.map (snd >> Seq.length)
    >> fun groups ->
        (groups |> Seq.contains 3) &&
        (groups |> Seq.contains 2)

let isThreeOfAKind : char seq -> bool = 
    Seq.groupBy id
    >> Seq.map (snd >> Seq.length)
    >> fun groups ->
        (groups |> Seq.contains 3) &&
        (groups |> Seq.contains 2 |> not)

let isTwoPair : char seq -> bool = 
    Seq.groupBy id
    >> Seq.map (snd >> Seq.length)
    >> Seq.filter (fun l -> l = 2)
    >> Seq.length
    >> (=) 2

let isOnePair : char seq -> bool = 
    Seq.groupBy id
    >> Seq.map (snd >> Seq.length)
    >> Seq.filter (fun l -> l = 2)
    >> Seq.length
    >> (=) 1

let handTypeStrength = function
    | hand when hand |> isFiveOfAKind -> 6
    | hand when hand |> isFourOfAKind -> 5
    | hand when hand |> isFullHouse -> 4
    | hand when hand |> isThreeOfAKind -> 3 
    | hand when hand |> isTwoPair -> 2
    | hand when hand |> isOnePair -> 1
    | _ -> 0

let relStrength =
    function
    | 'A' -> 13
    | 'K' -> 12
    | 'Q' -> 11
    | 'J' -> 10
    | 'T' -> 9
    | '9' -> 8
    | '8' -> 7
    | '7' -> 6
    | '6' -> 5
    | '5' -> 4
    | '4' -> 3
    | '3' -> 2
    | '2' -> 1
    | c -> failwith $"Unknown Card: {c}"

// Less than zero 	x is less than y.
// Zero 	x equals y.
// Greater than zero 	x is greater than y. 
let compareHandType (handA:char seq) (handB:char seq) : int =
    match handA = handB with
    | true -> 0
    | false ->
        match (handTypeStrength handA).CompareTo (handTypeStrength handB) with
        | 0 ->
            Seq.zip (handA |> Seq.map relStrength) (handB |> Seq.map relStrength)
            |> Seq.map (fun (strA, strB) -> strA.CompareTo strB)
            |> Seq.tryFind (fun str -> str <> 0)
            |> function
            | Some str -> str
            | None -> 0
        | r -> r

let puzzle (input : string seq) =
    input
    |> Seq.map (String.split [" "])
    |> Seq.map (fun strs ->
        strs |> Seq.head,
        strs |> Seq.item 1 |> int)
    |> Seq.sortWith (fun (handA,_) (handB,_) ->
        compareHandType handA handB)
    |> Seq.mapi (fun i (_, bid) ->
        bid * (i + 1))
    |> Seq.sum