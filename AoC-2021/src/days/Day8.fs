module AoC2021.Day8

open System
open FSharp.Collections
open FSharpPlus

let parse7sEntry entry =
    entry
    |> split ["|"]
    |> head
    |> split [" "]
    |> filter ((<>) "")
    |> toList, 
    entry
    |> split ["|"]
    |> skip 1
    |> head
    |> split [" "]
    |> filter ((<>) "")
    |> toList

let puzzle1 (entries: (string list * string list) seq) =
    entries
    |> map snd
    |> fold Seq.append []
    |> map length
    |> filter (fun length ->
        length=2 || // 1
        length=4 || // 4
        length=3 || // 7
        length=7)   // 8
    |> length


// // Intersection
// let intersect (a:string) (b:string) =
//     a |> filter (flip String.contains b)
// // Union
// let union (a:string) (b:string) =
//     a + (intersect b a)
// // Set difference
// let setDiff (u:string) (a:string) =
//     u |> filter (flip String.contains a >> not)

// Intersection
let intersect a b = a |> Set.filter (flip Set.contains b)
// Symmetric difference
let symDif (a:Set<'T>) (b:Set<'T>) = (a - b) + (b - a)
let setAll = "abcdefg" |> Set


let solve (patterns: Set<char> seq) =
    let patternsLengths = patterns |> map (fun p -> p, p |> length)
    let getStringsOfLength length = patternsLengths |> filter (snd >> (=) length) |> map fst
    let getStringOfLength = getStringsOfLength >> Seq.head
    let one = getStringOfLength 2
    let four =  getStringOfLength 4
    let seven = getStringOfLength 3
    let eigth = getStringOfLength 7
    let twoOrThreeOrFive = getStringsOfLength 5
    let sixOrNineOrZero = getStringsOfLength 6

    let segA = seven - one
    let segG =
        twoOrThreeOrFive
        |> Seq.map (flip (-) (four + seven))
        |> Seq.fold intersect setAll
    let segE = eigth - seven - four - segG
    let segD =
        twoOrThreeOrFive
        |> Seq.map (flip (-) (seven + segE + segG))
        |> Seq.fold intersect setAll
    let segB =
        sixOrNineOrZero
        |> Seq.map (flip (-) (seven + segE + segG))
        |> Seq.fold intersect setAll
    let segF =
        sixOrNineOrZero
        |> Seq.map (flip (-) (segA + segB + segD + segE + segG))
        |> Seq.fold intersect setAll
    let segC = one - segF

    let zero = seven + segB + segE + segG
    let two = segA + segC + segD + segE + segG
    let three = seven + segD + segG
    let five = segA + segB + segD + segF + segG
    let six = five + segE
    let nine = three + segB

    [zero; one; two; three; four; five; six; seven; eigth; nine]

let decode (patterns: Set<char> seq) (output: Set<char> seq) =
    let digits = solve patterns
    
    output
    |> map (fun value -> findIndex ((=) value) digits)

let puzzle2 (entries: (string list * string list) seq) =
    entries
    |> map (fun (patterns, output) -> patterns |> map Set, output |> map Set)
    |> map (fun (patterns, output) -> decode patterns output)
    |> map (fold (fun state value -> state * 10 + value) 0)
    |> sum
