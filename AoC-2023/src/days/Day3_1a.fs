module AoC2023.Day3_1a

let private parseNumber (input:char list) =
    let rec func (count:int) (number:int) (input:char list) =
        match input with
        | c::tail ->
            match c |> Day1_1.tryCastCharToInt with
            | Some digit ->
                let newNumber = number * 10 + digit
                func (count+1) newNumber tail
            | None -> count, number, input
        | _ -> count, number, input
    func 0 0 input

let rec private skipWhiteSpace (pos:int) (input:char list) =
    match input with
    | c::tail ->
        match c |> System.Char.IsDigit with
        | true -> pos, input
        | false -> skipWhiteSpace (pos+1) tail
    | [] -> pos, input

let private collectNeighbours (numStart:int) (numEnd:int) (mainLine:char list) (otherLines:char list list) =
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
    | '.' -> false
    | c when c |> System.Char.IsDigit -> false
    | _ -> true

let private collectLine (mainLine:char list) (otherLines:char list list) =
    let rec func (pos:int) (numbers:int list) (curMainLine:char list) (curOtherLines:char list list) =
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
    
let rec private collectAll (numbers:int list list) (lines:char list list) (restLines: char list list) =
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
    |> Seq.map Seq.toList
    |> Seq.toList
    |> collectAll [] []
    // |> List.rev
    // |> List.map List.rev
    |> Seq.collect id
    |> Seq.sum