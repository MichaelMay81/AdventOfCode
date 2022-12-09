module AoC2022.Day9_2

open FSharpPlus
open Day9_1
#nowarn "25"

let draw (fieldSize:Coords) (rope:Coords list) =
    [fieldSize.Y-1 .. -1 .. 0]
    |> List.map (fun y ->
        [0 .. fieldSize.X-1]
        |> List.map (fun x ->
            rope
            |> List.tryFindIndex ((=) {X=x; Y=y})
            |> function
            | None -> "."
            | Some i -> $"{i}")
            // $"{x}{y}")
        |> String.concat " ")
    |> String.concat "\n"

let drawState fieldSize move rope =
    printfn $"== {move} =="
    draw fieldSize rope |> printfn "%s"
    rope

let moveTail head tail =
    (moveTail { Head=head; Tail=tail }).Tail
    
let moveRope ((head::rope):Coords list) (move:char) =
    let head = moveHead head move
    rope
    |> Seq.fold (fun (head::newRope) nextEl ->
        (moveTail head nextEl)::head::newRope
    ) [head]
    |> List.rev

let play (moves:(char*int) list) =
    moves
    |> Seq.bind (fun (move, steps) ->
        List.init steps (fun _ -> move))
    |> Seq.fold ( fun (rope, visited) move ->
            moveRope rope move
            |> (drawState {X=26;Y=21} move)
            |> (fun rope -> rope, (rope|>Seq.rev|>Seq.head)::visited)
        ) (List.init 10 (fun _-> { X=11; Y=5}), [])

let puzzle2 =
    parse
    >> Seq.bind (fun (move, steps) ->
        List.init steps (fun _ -> move))
    >> Seq.fold ( fun (rope, visited) move ->
            moveRope rope move
            |> (fun rope -> rope, (rope|>Seq.rev|>Seq.head)::visited)
        ) (List.init 10 (fun _-> Coords.zero), [])
    >> fun (_, visited) ->
        visited
        |> Seq.distinct
        |> Seq.length