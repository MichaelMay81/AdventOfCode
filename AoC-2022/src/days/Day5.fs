module AoC2022.Day5

open FSharpPlus

type Rap = {
    Count : int
    From : int
    To : int
}

let rec parseStacks (input:string list) (result:string seq seq) : string list list=
    match input with
    | (line::rest) ->
        line
        |> String.split ["    "; " "]
        |> Seq.zip  result
        |> Seq.map (fun (list, el) -> list |> Seq.append [el])
        |> Seq.toList
        |> parseStacks rest
    | [] -> result |> Seq.map Seq.toList |> Seq.toList

let parseReArrangmentProcedures =
    String.split ["\n"]
    >> Seq.map(sscanf "move %i from %i to %i")
    >> Seq.map(fun (c, f, t) -> { Count=c; From=f-1; To=t-1 })
    >> Seq.toList

let parse =
    String.split ["\n\n"]
    >> Seq.toList
    >> fun (stacks::rap::_) ->
        (stacks
        |> String.split ["\n"]
        |> Seq.rev
        |> Seq.toList
        |> fun (head::tail) ->
            head
            |> String.split ["   "]
            |> Seq.map (fun _ -> Seq.empty)
            |> parseStacks tail)
        |> List.map (List.filter ((<>) "")),
        rap
        |> parseReArrangmentProcedures

let runRap (revContainers:bool) (containers:string list list) (rap:Rap) =
    containers
    // Take From
    |> List.updateAt 
        rap.From 
        (containers
        |> List.item rap.From
        |> List.skip rap.Count)
    // Put into To
    |> List.updateAt 
        rap.To
        (containers
        |> List.item rap.To
        |> List.append 
            (containers
            |> List.item rap.From
            |> List.take rap.Count
            |> (fun l -> if revContainers then List.rev l else l)))

let formatResult =
    List.map (List.head)
    >> List.map (sscanf "[%s]")
    >> String.concat ""

let puzzle1 =
    parse
    >> (fun (containers, raps) ->
        List.fold (fun cs rap ->
            // printfn "%A" cs
            // printfn "%A" rap
            runRap true cs rap) containers raps)
    >> formatResult

let puzzle2 =
    parse
    >> (fun (containers, raps) ->
        List.fold (fun cs rap ->
            runRap false cs rap) containers raps)
    >> formatResult