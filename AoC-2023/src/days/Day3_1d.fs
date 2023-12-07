module AoC2023.Day3_1d

type Part =
| Number of int
| Symbol of char
| Period

let private parse (input:string) =
    let rec func (output:Part list) (input:char list) =
        match input with
        | [] ->
            output
        | '.'::tail ->
            func (Period::output) tail
        | head::tail ->
            match head |> Day1_1.tryCastCharToInt with
            | Some i ->
                func (Number i :: output) tail
            | None ->
                func (Symbol head :: output) tail
    func [] (input |> Seq.toList)
    |> List.rev

let private parseNumber (input:Part list) =
    let rec func (input:Part list) (count:int) (number:int) =
        match input with
        | Number digit::tail ->
            number * 10 + digit
            |> func tail (count+1)
        | _ -> count, number, input
    func input 0 0

let rec private skipWhiteSpace (pos:int) (input:Part list) =
    match input with
    | []
    | Number _::_ ->
        pos, input
    | _::tail -> skipWhiteSpace (pos+1) tail

let private collectNeighbours (numStart:int) (numEnd:int) (mainLine:Part list) (otherLines:Part list list) =
    let numStart, numEnd, neigbours =
        match numStart > 0, numEnd < ((mainLine |> List.length) - 1) with
        | false, false -> numStart, numEnd, []
        | true, true ->
            numStart - 1,
            numEnd + 1,
            [ mainLine |> List.item (numStart - 1)
              mainLine |> List.item (numEnd + 1) ]
        | true, false ->
            numStart - 1,
            numEnd,
            [ mainLine |> List.item (numStart - 1) ]
        | false, true ->
            numStart,
            numEnd + 1,
            [ mainLine |> List.item (numEnd + 1) ]

    neigbours
    |> List.append (
        otherLines
        |> List.map (List.skip numStart >> List.take (numEnd-numStart+1))
        |> List.collect id)

let private isSymbol = function
    | Symbol _ -> true
    | _ -> false

let private collectLine (mainLine:Part list) (otherLines:Part list list) =
    let rec func (pos:int) (numbers:int list) (curMainLine:Part list) (curOtherLines:Part list list) =
        let pos, curMainLine = skipWhiteSpace pos curMainLine
        match curMainLine with
        | [] -> numbers
        | _ ->
            let count, number, curMainLine = parseNumber curMainLine
            let newPos = pos + count
            let neigbours = collectNeighbours pos (newPos-1) mainLine otherLines
            // printfn "%i %i %i" number pos newPos
            // printfn "%A" neigbours
            let numbers =
                //match neigbours |> List.forall (isSymbol >> not) with
                match neigbours |> List.exists isSymbol with
                | true -> number::numbers
                | false -> numbers
            func newPos numbers curMainLine curOtherLines
    func 0 [] mainLine otherLines
    
let rec private collectAll (numbers:int list list) (lines:Part list list) (restLines: Part list list) =
    match lines, restLines with
    | [], mainLine::otherLine::restLines ->
        let newNumbers = collectLine mainLine [otherLine]
        collectAll (newNumbers::numbers) [mainLine; otherLine] restLines
    | [otherLine1; mainLine], otherLine2::restLines ->
        let newNumbers = collectLine mainLine [otherLine1; otherLine2]
        collectAll (newNumbers::numbers) [mainLine; otherLine2] restLines
    | [otherLine; mainLine], [] ->
        let newNumbers = collectLine mainLine [otherLine]
        (newNumbers::numbers)
    | _, _ ->
        failwith $"this shouldn't happen {lines} {restLines}"

let puzzle (input: string seq) =
    input
    |> Seq.map parse
    |> Seq.toList
    |> collectAll [] []
    // |> List.rev
    // |> List.map List.rev
    |> Seq.collect id
    |> Seq.sum