module AoC2020.Day1

// first try, tuple permutations with two recursive functions
let tuplesPerm1 input =
    let rec loop (el1:int) (inLi:int list) (accLi:(int*int) list) : (int*int) list =
        match inLi with
        | [] -> accLi
        | el2 :: inLi2 -> loop el1 inLi2 ((el1, el2) :: accLi)
        
    let rec loop2 el1 inLi accLi =
        match inLi with
        | [] -> accLi
        | el2 :: inLi2 ->
            let values = (loop el1 inLi []) :: accLi
            loop2 el2 inLi2 values
        
    match input with
    | [] -> []
    | el1 :: input -> (loop2 el1 input [])

// second try, tuple permutation with one generic loop and two recursive functions
//let tuplesPerm2 input =
//    let loopi f (el1:int) (inLi:int list) (accLi:'a list) : 'a list =
//        match inLi with
//        | [] -> accLi
//        | el2 :: inLi2 -> f el1 inLi accLi el2 inLi2
//        
//    let rec loopi1 = loopi (fun el1 _ accLi el2 inLi2 -> loopi1 el1 inLi2 ((el1, el2) :: accLi))
//    let rec loopi2 = loopi (fun el1 inLi accLi el2 inLi2 -> loopi2 el2 inLi2 ((loopi1 el1 inLi []) :: accLi))
//        
//    match input with
//    | [] -> []
//    | el1 :: input -> (loopi2 el1 input [])

// third try, tuple permutation with recursive function and map for inner loop
let tuplesPerm3 (input:'a list) : ('a*'a) seq =
    let rec loop (el1:'a option) (accLi:('a*'a) seq) (inLi:'a list) : ('a*'a) seq =
        match el1, inLi with
        // stop condition
        | _, [] -> accLi
        // init condition
        | None, el1 :: inLi -> loop (Some el1) accLi inLi
        // recursion
        | Some el1, el2 :: inLi2 ->
            let tupEl1 elN = (el1, elN)
            loop (Some el2) (inLi |> Seq.map tupEl1 |> (Seq.append accLi) ) inLi2
        
    input |> loop None []

// triple permutation with recursive function and map for inner loop
let triplesPerm (input:int list) : (int*int*int) seq =
    let rec loop (el1Opt:int option) (el2Opt:int option) (accLi:(int*int*int) seq) (inLi1:int list) (inLi2:int list) : (int*int*int) seq =
        match el1Opt, el2Opt, inLi1, inLi2 with
        // stop condition Final
        | _, _, [], _ -> accLi
        // init condition 1
        | None, _, el1 :: inLi1, _ ->
            loop (Some el1) None [] inLi1 []
        // init condition 2
        | Some _, None, el2 :: inLi2, _ ->
            loop el1Opt (Some el2) accLi inLi1 inLi2
        // stop condition inner rec
        | Some _, Some _, el1Next :: inLi1Next, [] ->
            loop (Some el1Next) None accLi inLi1Next []
        // recursion
        | Some el1, Some el2, _, el2Next :: inLi2Next->
            let toTriple e3 = (el1, el2, e3)
            loop el1Opt (Some el2Next) (inLi2 |> Seq.map toTriple |> (Seq.append accLi)) inLi1 inLi2Next
    
    loop None None [] input []

let puzzle1 input =
    let tups = tuplesPerm3 input
    let results = tups |> (Seq.filter (fun (a, b) -> (a + b) = 2020))
    assert(results |> Seq.length = 1)
    
    match results |> Seq.toList with
    | [] -> -1
    | (v1, v2) :: _ -> v1 * v2
    
let puzzle2 input =
    let tups = (triplesPerm input)
    let results = tups |> (Seq.filter (fun (a, b, c) -> (a + b + c) = 2020))
    assert(results |> Seq.length = 1)
    
    match results |> Seq.toList with
    | [] -> -1
    | (v1, v2, v3) :: _ -> v1 * v2 * v3