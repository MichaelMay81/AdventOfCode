module AoC2021.Day12

open System
open FSharpPlus

let strings2Map (caves:string seq) : Map<string, string list> =
    let connections =
        caves
        |> Seq.map (String.split ["-"])
        |> Seq.map (
            Seq.toList >>
            function
            | [] | [_] -> None
            | [i1; i2] -> Some (i1, i2)
            | i1 :: i2 :: _ -> Some (i1, i2))
        |> Seq.choose id
        |> Seq.toList
    
    let connections =
        connections
        |> List.append
            (connections |> List.map (fun (one, two) -> two, one))

    connections
    |> Seq.groupBy fst
    |> Seq.map (fun (cave,exits) -> cave, (exits |> Seq.map snd |> Seq.toList))
    |> Map.ofSeq

let findPaths (caves:Map<string, string list>) =
    let rec find (caves:Map<string, string list>) (smallCavesSeen:string list) (paths:string list list) : string list list=
        let current = paths |> List.head |> List.head
        match current = "end" with
        | true -> paths |> List.map List.rev
        | false ->
            
            // exits
            caves.[current]
            // w/o small caves seen
            |> List.filter (flip List.contains smallCavesSeen >> not)
            |> List.map (fun newCave ->
                let newPaths = paths |> List.map (List.cons newCave)
                match newCave |> (Seq.forall Char.IsLower) with
                | false ->
                    find caves smallCavesSeen newPaths
                | true ->
                    find caves (newCave::smallCavesSeen) newPaths
                )
            |> List.collect id

    find caves ["start"] [["start"]]

let puzzle1 (caves:string seq) =
    caves
    |> strings2Map
    |> findPaths
    |> length