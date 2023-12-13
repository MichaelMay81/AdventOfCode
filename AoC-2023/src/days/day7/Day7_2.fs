module AoC2023.Day7_2

open FSharpPlus

let (|FiveOfAKind|FourOfAKind|FullHouse|ThreeOfAKind|TwoPair|OnePair|HighCard|) hand =
    let grouped =
        hand
        |> Seq.groupBy id
        |> Seq.map (fun (c, el) ->
            c,
            el |> Seq.length)
        |> Seq.toList

    let jCount =
        grouped
        |> Seq.tryFind (fst >> (=) 'J')
        |> Option.map snd
        |> Option.defaultValue 0

    let counts =
        grouped
        |> Seq.filter (fst >> (<>) 'J')
        |> Seq.map snd
        |> Seq.sortDescending
        |> Seq.toList
    let highest = counts |> Seq.tryItem 0 |> Option.defaultValue 0
    let second = counts |> Seq.tryItem 1 |> Option.defaultValue 0

    match highest + jCount, second with
    | 5, _ -> FiveOfAKind
    | 4, _ -> FourOfAKind
    | 3, 2 -> FullHouse
    | 3, _ -> ThreeOfAKind
    | 2, 2 -> TwoPair
    | 2, _ -> OnePair
    | _ -> HighCard

let handTypeStrength = function
    | FiveOfAKind -> 6
    | FourOfAKind -> 5
    | FullHouse -> 4
    | ThreeOfAKind -> 3 
    | TwoPair -> 2
    | OnePair -> 1
    | HighCard -> 0

let relStrength =
    function
    | 'A' -> 13
    | 'K' -> 12
    | 'Q' -> 11
    | 'T' -> 10
    | '9' -> 9
    | '8' -> 8
    | '7' -> 7
    | '6' -> 6
    | '5' -> 5
    | '4' -> 4
    | '3' -> 3
    | '2' -> 2
    | 'J' -> 1
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