module AoC2021.Day4

open FSharpPlus

let parsePuzzleInput lines =
    let lines = lines |> Seq.toList
    let drawnNumbers =
        lines
        |> Seq.head
        |> String.split [","]
        |> Seq.map int
        |> Seq.toList

    let rec parseBoard acc lines  =
        match lines with
        | [] -> acc
        | _ -> 
            let board =
                lines
                |> Seq.skip 1
                |> Seq.take 5
                |> String.concat " "
                |> String.split [" "]
                |> Seq.filter (String.length >> ((<) 0))
                |> Seq.map int
                |> Seq.toList
            
            parseBoard (board :: acc) (lines |> List.skip 6)
    
    let boards =
        lines
        |> List.skip 1
        |> parseBoard []

    drawnNumbers, boards

let private orderByFun func length board =
    board
    |> Seq.mapi (fun i v -> i,v)
    |> Seq.groupBy (fun (i,v) -> func i length)
    |> Seq.map (snd >> (Seq.map snd))
    |> Seq.map Seq.toList
    |> Seq.toList

let slice length board =
    orderByFun (/) length board

let columns length board =
    orderByFun (%) length board

let boardToString board =
    board
    |> slice 5
    |> Seq.map (Seq.fold (fun state num -> state + " " + (string num)) "")
    |> Seq.fold (fun state nums -> state + "\n" + nums) ""

let markedBoardToString board marks =
    let posToStr (num, mark) =
        if mark
            then $"\x1b[1m\u001b[34m%2i{num}\u001b[0m\x1b[0m"
            else $"%2i{num}"

    Seq.zip board marks
    |> slice 5
    |> Seq.map (Seq.fold (fun state tup -> state + " " + (posToStr tup)) "")
    |> Seq.fold (fun state nums -> state + "\n" + nums) ""

let marked (selectedNumbers: int seq) (board: int seq) =
    board
    |> Seq.map (flip Seq.contains selectedNumbers)

let isWinner marks =
    let rowCounts =
        marks
        |> slice 5
        |> Seq.map (Seq.filter id >> Seq.length)

    let columnCounts =
        marks
        |> columns 5
        |> Seq.map (Seq.filter id >> Seq.length)

    Seq.append rowCounts columnCounts
    |> Seq.map ((=) 5)
    |> Seq.contains true

let puzzle1 selectedNumbers boards =
    let findWinner boards sn =
        boards
        |> Seq.map (fun b -> b, (b |> marked sn))
        |> Seq.map (fun (b,m) -> (b, m), (isWinner m))
        |> Seq.filter snd
        |> Seq.map fst

    let lastNum, winners =
        { 5 .. (selectedNumbers |> Seq.length)}
        |> Seq.map (fun i ->
                    let sns =  Seq.take i selectedNumbers
                    let last = sns |> Seq.rev |> Seq.head
                    last, (sns |> (findWinner boards)))
        |> Seq.filter (snd >> Seq.isEmpty >> not)
        |> Seq.head
    let winBoard, winMarks =
        winners
        |> Seq.head

    let unmarkedNumsSum =
        Seq.zip winBoard winMarks
        |> Seq.filter (snd >> not)
        |> Seq.map fst
        |> Seq.fold (+) 0

    unmarkedNumsSum * lastNum

let puzzle2 selectedNumbers boards =
    let findLooser boards sn =
        boards
        |> Seq.map (fun b -> b, (b |> marked sn))
        |> Seq.map (fun (b,m) -> (b, m), (isWinner m))
        |> Seq.filter (snd >> not)
        |> Seq.map fst

    let lastId, lastWinners =
        { (selectedNumbers |> Seq.length) .. -1 .. 5 }
        |> Seq.map (fun i ->
                    let sns =  Seq.take i selectedNumbers
                    let foobar = (sns |> (findLooser boards))
                    i, foobar)
        |> Seq.filter (snd >> Seq.isEmpty >> not)
        |> Seq.head

    let lastNum = selectedNumbers |> Seq.skip lastId |> Seq.head

    let winBoard =
        lastWinners
        |> Seq.head
        |> fst
    let winMarks =
        winBoard
        |> marked (Seq.take (lastId+1) selectedNumbers)

    let unmarkedNumsSum =
        Seq.zip winBoard winMarks
        |> Seq.filter (snd >> not)
        |> Seq.map fst
        |> Seq.fold (+) 0

    unmarkedNumsSum * lastNum