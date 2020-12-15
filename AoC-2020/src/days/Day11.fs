module AoC_Mike.Day11

open FSharpPlus

type Seat =
    | Empty
    | Occupied

type Position =
    | Floor
    | Seat of Seat
    
let charToPosition = function
    | '.' -> Floor
    | 'L' -> Seat Empty
    | '#' -> Seat Occupied
    | _ -> Floor
    
let positionToChar = function
    | Floor -> '.'
    | Seat Empty -> 'L'
    | Seat Occupied -> '#'

let analysePosition (pos:Position) (adjacentPoss:Position list) : Position =
    let adjacentSeats = adjacentPoss |> Seq.choose (function Floor -> None | Seat seat -> Some seat)
    match pos with
    | Floor -> pos
    | Seat seat -> match seat with
                   | Empty -> if adjacentSeats |> Seq.forall ((=) Empty)
                              then Seat Occupied
                              else Seat Empty
                   | Occupied -> if (adjacentSeats |> Seq.filter ((=) Occupied) |> Seq.length) >= 4
                                 then Seat Empty
                                 else Seat Occupied

let Tup3ToList (a, b, c) =
    [a; b; c]

let rec analyseRow (firstRowOpt:(Position*Position*Position) option) (preCurNexLines:(Position*Position*Position) list) (acc:Position list) : Position list =
    match preCurNexLines with
    | [] -> acc |> List.rev
    | (r2c0, r2c1, r2c2) :: tailPrecurNextLines ->
        match firstRowOpt with
        | None -> analyseRow (Some (r2c0, r2c1, r2c2)) tailPrecurNextLines acc
        | Some firstRow ->
            if tailPrecurNextLines |> List.isEmpty
            then acc |> List.rev
            else
                let thirdRow = tailPrecurNextLines |> List.head
                let newEl = analysePosition r2c1 ((firstRow |> Tup3ToList) @ [r2c0; r2c2] @ (thirdRow |> Tup3ToList))
                analyseRow (Some (r2c0, r2c1, r2c2)) tailPrecurNextLines (newEl :: acc)

let rec analyseLines (prevLine:Position list) (lines:Position list list) (acc:Position list list) : Position list list =
    match lines with
    | [] -> acc |> List.rev
    | currLine :: restLines ->
        if prevLine |> List.isEmpty
        then analyseLines currLine restLines acc
        elif restLines |> List.isEmpty
        then acc |> List.rev
        else
            let nextLine = restLines |> List.head
            let preCurNextLines = List.zip3 prevLine currLine nextLine
            let newLine = analyseRow None preCurNextLines []
            analyseLines currLine restLines (newLine :: acc)
            
let analysePositions (lines:Position list list) : Position list list =
    let numOfRows = lines |> List.head |> List.length
    let emptyLine = List.init (numOfRows + 2) (fun _ -> Floor)
    
    let linesWithEmpties =
        emptyLine
        :: (lines |> List.map (fun line -> (Floor :: line) |> List.append <| [Floor]))
        |> List.append <| [emptyLine]
    analyseLines [] linesWithEmpties []

let stringsToPositions : string seq -> Position list list =
    Seq.map (Seq.map charToPosition >> Seq.toList)
    >> Seq.toList
    
let positionsToString =
    List.map (List.map positionToChar >> (List.fold (fun state c -> state + string c) ""))
    >> List.fold (fun state str -> state + "\n" + str) ""
    
let puzzle1 (positions:string seq) : int =
    let rec loop (acc:int) (poss:Position list list) : (int * Position list list) =
        let newPoss = poss |> analysePositions
        if newPoss = poss
        then acc, newPoss
        else loop (acc+1) newPoss 
    
    positions
    |> stringsToPositions
    |> loop 1
    |> snd
    |> List.map (List.filter ((=) (Seat Occupied)) >> List.length)
    |> List.sum