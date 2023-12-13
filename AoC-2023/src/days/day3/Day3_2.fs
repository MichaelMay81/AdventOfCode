module AoC2023.Day3_2

type Gear = {
    X: int
    Y: int}

type Part =
| Number of int
| Symbol of char
| Gear of Gear
| Period

let private parse (x:int) (input:string) =
    let rec func (y:int) (output:Part list) (input:char list) =
        match input with
        | [] ->
            output
        | '.'::tail ->
            func (y+1) (Period::output) tail
        | '*'::tail ->
            func (y+1) (Gear {X=x;Y=y} :: output) tail
        | head::tail ->
            match head |> Day1_1.tryCastCharToInt with
            | Some i ->
                func (y+1) (Number i :: output) tail
            | None ->
                func (y+1) (Symbol head :: output) tail
    input |> Seq.toList
    |> func 0 []
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
    let rec func (pos:int) (numbers:(int*(Gear list)) list) (curMainLine:Part list) (curOtherLines:Part list list) =
        let pos, curMainLine = skipWhiteSpace pos curMainLine
        match curMainLine with
        | [] -> numbers
        | _ ->
            let count, number, curMainLine = parseNumber curMainLine
            let newPos = pos + count
            let neigbours =
                collectNeighbours pos (newPos-1) mainLine otherLines
                |> List.choose (function
                    | Gear gear -> Some gear 
                    | _ -> None)

            // printfn "%i %i %i" number pos newPos
            // printfn "%A" gearNeighbours

            match neigbours with
            | [] ->
                func newPos numbers curMainLine curOtherLines
            | neigbours ->
                let newNumber = number, neigbours
                func newPos (newNumber::numbers) curMainLine curOtherLines

    func 0 [] mainLine otherLines
    
let rec private collectAll (numbers:(int*(Gear list)) list) (lines:Part list list) (restLines: Part list list) =
    match lines, restLines with
    | [], mainLine::otherLine::restLines ->
        let newNumbers = collectLine mainLine [otherLine]
        collectAll (newNumbers @ numbers) [mainLine; otherLine] restLines
    | [otherLine1; mainLine], otherLine2::restLines ->
        let newNumbers = collectLine mainLine [otherLine1; otherLine2]
        collectAll (newNumbers @ numbers) [mainLine; otherLine2] restLines
    | [otherLine; mainLine], [] ->
        let newNumbers = collectLine mainLine [otherLine]
        (newNumbers @ numbers)
    | _, _ ->
        failwith $"this shouldn't happen {lines} {restLines}"

let puzzle (input: string seq) =
    input
    |> Seq.mapi parse
    |> Seq.toList
    |> collectAll [] []
    |> List.collect (fun (number, gears) ->
        gears |> List.map (fun gear -> gear, number))
    |> List.groupBy (fun (gear, _) -> gear)
    |> List.where (fun (_, numbers) -> numbers |> List.length = 2)
    |> List.map (fun (gear, numbers) ->
        // gear,
        numbers |> Seq.map snd |> Seq.fold ( * ) 1)
    |> Seq.sum