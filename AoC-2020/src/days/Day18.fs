module AoC2020.Day18

let parseAndEvaluate (input:char list) : int64 =
    let inline charToInt c = int64 c - int64 '0'
    
    let rec loop (f:int64->int64->int64) (acc:int64) (input:char list): (int64 * char list) =
        match input with
        | [] -> acc, List.empty
        | head :: tail ->
            match head with
            | '+' -> loop (+) acc tail
            | '*' -> loop (*) acc tail
            | '(' ->
                let num, newTail = loop (+) 0L tail
                loop f (f acc num) newTail
            | ')' -> acc, tail
            | num -> loop f (f acc (charToInt num)) tail
    loop (+) 0L input |> fst

let puzzle1 (input:string seq) : int64 =
    input
    |> Seq.map (Seq.filter ((<>) ' ') >> Seq.toList >> parseAndEvaluate)
    |> Seq.sum
    
let parseAndEvaluate2 (input:char list) : int64 =
    let inline charToInt c = int64 c - int64 '0'
    
    let rec loop (f:char) (acc:int64) (input:char list): (int64 * char list) =
        let applyFun num tail=
            match f with
            | '+' -> loop f (acc + num) tail
            | '*' -> 
                let newNum, newTail = loop f num tail
                (acc * newNum), newTail
            | _ -> failwith "this shouldn't happen"
        
        match input with
        | [] -> acc, List.empty
        | head :: tail ->
            match head with
            | '+'
            | '*' -> loop head acc tail
            | '(' -> 
                let num, newTail = loop '*' 1L tail
                applyFun num newTail
            | ')' -> acc, tail
            | num -> applyFun (charToInt num) tail
    loop '*' 1L input |> fst

let puzzle2 (input:string seq) : int64 =
    input
    |> Seq.map (Seq.filter ((<>) ' ') >> Seq.toList >> parseAndEvaluate2)
    |> Seq.sum