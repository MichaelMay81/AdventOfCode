module AoC2023.Day8_1

open FSharpPlus

type Node = {
    Left : string
    Right: string
}

type Map = {
    Instructions : char list
    Network : Map<string, Node>
}

let parseNode : string -> string*Node =
    sscanf "%s = (%s, %s)"
    >> fun (id, left, right) ->
        id, { Left=left; Right=right}

let parse (input : string seq) =
    {   Instructions = input |> Seq.head |> Seq.toList
        Network =
            input
            |> Seq.skip 2
            |> Seq.map parseNode
            |> Map }

let analyze (map:Map) =
    let rec func (steps:int) (instructions:char list) (currentNodeKey:string) =
        match currentNodeKey, instructions with
        | "ZZZ", _ ->
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
    
    "AAA" |> func 0 []

let puzzle (input : string seq) =
    input
    |> parse
    |> analyze
