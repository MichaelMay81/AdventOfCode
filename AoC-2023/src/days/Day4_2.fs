module AoC2023.Day4_2

open FSharpPlus

let parse (input : string) =
    input
    |> sscanf "Card %i: %s | %s"
    |> (fun (cardNumber, winNumStr, numStr) ->
        cardNumber,
        winNumStr |> String.split [" "] |> Seq.where ((<>) ""),
        numStr |> String.split [" "] |> Seq.where ((<>) ""))

let map2 (mapping : 'T1 -> 'T1 -> 'T1) (list1:'T1 list) (list2:'T1 list) =
    let rec func result list1 list2 =
        match list1, list2 with
        | [], [] -> result
        | head1::rest1, head2::rest2 ->
            func ((mapping head1 head2) :: result) rest1 rest2
        | head1::rest1, [] ->
            func (head1::result) rest1 []
        | [], head2::rest2 ->
            func (head2::result) [] rest2
    func [] list1 list2

let rec calcNumOfCards (output : int list) (counts : int list) (input : int list) =
    match input, counts with
    | [], _ -> output
    | wins::restWins, [] ->
        let count = 1
        let counts = List.init wins (konst count)
        // printfn "foobar: %A %A" count newCount
        calcNumOfCards (count::output) counts restWins
    | wins::restWins, count::restCounts ->
        let count = count + 1
        let newCount = List.init wins (konst count)
        let counts =
            map2 (+) (newCount) restCounts
            |> List.rev
        // printfn "foobar: %A %A %A" count newCount counts
        calcNumOfCards (count::output) counts restWins 

let analyzeCard (cardNumber:int) (winNumbers:string seq) (numbers:string seq) =
    let winners =
        numbers
        |> Seq.where (flip Seq.contains winNumbers)
        |> Seq.toList

    cardNumber, winners

let puzzle (input : string seq) =
    input
    |> Seq.map (
        parse
        >> uncurryN analyzeCard)
    |> Seq.map (fun (_, winners) -> winners |> Seq.length)
    |> Seq.toList
    |> calcNumOfCards [] []
    |> Seq.sum