module AoC2023.Day8_2

open FSharpPlus

// get factors as Seq (first try, wrong order)
let getFactors (number:int) : int seq =
    let rec func (factors:int seq) (testMultiple:int) =
        match testMultiple >= number, number % testMultiple with
        | true, _ ->
            factors
        | _, 0 ->
            func (seq { yield number / testMultiple; yield! factors }) (testMultiple + 1)
        | _, _ ->
            func factors (testMultiple + 1)

    func (seq { yield number }) 2 |> Seq.rev

// get factors as Seq
let getFactors2 (number:int) : int seq =
    let rec func (factors:int seq) (testMultiple:int) =
        match testMultiple >= number, number % testMultiple with
        | true, _ ->
            factors
        | _, 0 ->
            func (seq { yield testMultiple; yield! factors }) (testMultiple + 1)
        | _, _ ->
            func factors (testMultiple + 1)

    seq { yield number; yield! func Seq.empty 2 }

// get factors as Seq (with seq expression)
let getFactors3 (number:int) : int seq =
    seq {
        for i in number..(-1)..2 do
            if number % i = 0 then i
    }

// find greatest common factor
let findGCF1 (factors: int list list) =
    let rec func (equalFactors: int list list) (notEqualFactors: int list list) (currFactor: int) (factors: int list list) =
        // printfn "%A ? in %A (= %A | <> %A)" currFactor factors equalFactors notEqualFactors
        
        match factors, notEqualFactors with
        // all through, all equal, return result
        | [], [] ->
            Some currFactor
        | [], someFactors::notEqualFactors ->
            match someFactors with
            // ran out of elements, no result found
            | [] -> None
            // all through, not all equal, pick new factor
            | newCurrFactor::_ ->
                func [someFactors] [] newCurrFactor (equalFactors @ notEqualFactors)
        | someFactors::factors, _ ->
            match someFactors with
            // ran out of elements, no result found
            | [] -> None
            // equal
            | testFactor :: _ when testFactor = currFactor ->
                func (someFactors :: equalFactors) notEqualFactors currFactor factors
            //  smaller, make this the new factor to search for
            | testFactor :: _ when testFactor < currFactor ->
                func [someFactors] [] testFactor (factors @ equalFactors @ notEqualFactors)
            //  bigger, drop and continue
            | _ :: someFactors ->
                func equalFactors notEqualFactors currFactor (someFactors :: factors)

    let equalFactors = factors |> List.head
    let currFactor = equalFactors |> List.head
    let factors = factors |> List.skip 1

    func [equalFactors] [] currFactor factors
    |> Option.defaultValue 1

// find greatest common factor (but with only one match operator)
let findGCF2 (factors: int list list) =
    let rec func (equalFactors: int list list) (notEqualFactors: int list list) (currFactor: int) (factors: int list list) =
        // printfn "%A ? in %A (= %A | <> %A)" currFactor factors equalFactors notEqualFactors
        
        match factors, notEqualFactors with
        // all through, all equal, return result
        | [], [] ->
            Some currFactor
        // ran out of elements, no result found
        | [], []::_
        | []::_, _ ->
            None
        // all through, not all equal, pick new factor
        | [], (newCurrFactor::someFactors)::notEqualFactors ->
            func [newCurrFactor::someFactors] [] newCurrFactor (equalFactors @ notEqualFactors)
        // equal
        | (testFactor::someFactors)::factors, _ when testFactor = currFactor ->
            func ((testFactor::someFactors) :: equalFactors) notEqualFactors currFactor factors
        //  smaller, make this the new factor to search for
        | (testFactor::someFactors)::factors, _ when testFactor < currFactor ->
            func [testFactor::someFactors] [] testFactor (factors @ equalFactors @ notEqualFactors)
        //  bigger, drop and continue
        | (_::someFactors)::factors, _ ->
            func equalFactors notEqualFactors currFactor (someFactors :: factors)

    let equalFactors = factors |> List.head
    let currFactor = equalFactors |> List.head
    let factors = factors |> List.skip 1

    func [equalFactors] [] currFactor factors
    |> Option.defaultValue 1

// find greatest common factor of Sequences
let findGCFSeq (factors: int seq list) =
    let rec func (equalFactors: int seq list) (notEqualFactors: int seq list) (currFactor: int) (factors: int seq list) =
        
        match factors, notEqualFactors with
        // all through, all equal, return result
        | [], [] ->
            Some currFactor
        | [], someFactors::notEqualFactors ->
            someFactors
            |> Seq.tryHead
            |> Option.bind (fun newCurrFactor ->
                // all through, not all equal, pick new factor
                func [someFactors] [] newCurrFactor (equalFactors @ notEqualFactors))
        | someFactors::factors, _ ->
            someFactors
            |> Seq.tryHead
            |> Option.bind (fun testFactor ->
                // equal
                if testFactor = currFactor then
                    func (someFactors :: equalFactors) notEqualFactors currFactor factors
                //  smaller, make this the new factor to search for
                else if testFactor < currFactor then
                    func [someFactors] [] testFactor (factors @ equalFactors @ notEqualFactors)
                //  bigger, drop and continue
                else
                    let someFactors = someFactors |> Seq.skip 1
                    func equalFactors notEqualFactors currFactor (someFactors :: factors))

    let equalFactors = factors |> List.head
    let currFactor = equalFactors |> Seq.head
    let factors = factors |> List.skip 1

    let result =
        func [equalFactors] [] currFactor factors
        |> Option.defaultValue 1
    
    result

// find least common denominator (using lists)
let findLcd (getFactors:int -> int seq) (findGCF:int list list -> int) (numbers:int list) =
    let gcf =
        numbers
        |> List.map getFactors
        |> List.map Seq.toList
        |> findGCF
    
    numbers
    |> List.fold ( * ) 1
    |> flip (/) gcf

// find least common denominator (using seq)
let findLcdSeq (getFactors:int -> int seq) (findGCF:int seq list -> int) (numbers:int list) : int64=
    let gcf =
        numbers
        |> List.map getFactors
        |> findGCF
        |> (int64)
    
    numbers
    |> Seq.map (int64)
    |> Seq.reduce (fun v1 v2 -> v1 * v2 / gcf)

// count steps to solve puzzle
let private countSteps (map:Day8_1.Map) (startNodeKey:string) =
    let rec func (steps:int) (instructions:char list) (currentNodeKey:string) =
        match currentNodeKey.EndsWith 'Z', instructions with
        | true, _ ->
            steps
        | _, [] ->
            func steps map.Instructions currentNodeKey
        | _, head::tail ->
            map.Network[currentNodeKey]
            |> (fun node ->
                match head with
                | 'L' -> node.Left
                | 'R' -> node.Right
                | c -> failwith $"Unknown direction {c}")
            |> func (steps+1) tail
    
    startNodeKey |> func 0 []

let puzzle (input : string seq) : int64 =
    let map =
        input
        |> Day8_1.parse

    let startKeys =
        map.Network
        |> Map.keys
        |> Seq.filter (fun key -> key.EndsWith 'A')
        |> Seq.toList

    startKeys
    |> List.map (countSteps map)
    |> findLcdSeq getFactors2 findGCFSeq