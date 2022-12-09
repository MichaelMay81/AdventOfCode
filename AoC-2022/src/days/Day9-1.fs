module AoC2022.Day9_1

open FSharpPlus
open System

type Coords = {
    X : int
    Y : int
} with static member zero = { X=0; Y=0 }
type Rope = {
    Head : Coords
    Tail : Coords
} with static member init = { Head=Coords.zero; Tail=Coords.zero }

let draw (fieldSize:Coords) ({Head=head; Tail=tail}) =
    [fieldSize.Y-1 .. -1 .. 0]
    |> List.map (fun y ->
        [0 .. fieldSize.X-1]
        |> List.map (fun x ->
            match head={X=x; Y=y},tail={X=x; Y=y} with
            | false, true -> "T"
            | true, _ -> "H"
            | _, _ -> ".")
            // $"{x}{y}")
        |> String.concat " ")
    |> String.concat "\n"

let drawResult (fieldSize:Coords) (visited:Coords list) =
    [fieldSize.Y-1 .. -1 .. 0]
    |> List.map (fun y ->
        [0 .. fieldSize.X-1]
        |> List.map (fun x ->
            match List.contains {X=x; Y=y} visited with
            | false -> "."
            | true -> "#")
            // $"{x}{y}")
        |> String.concat " ")
    |> String.concat "\n"

let drawState fieldSize move rope =
    printfn $"== {move} =="
    draw fieldSize rope |> printfn "%s"
    rope

let parse =
    String.split ["\n"]
    >> Seq.map (
        String.split [" "])
    >> Seq.map (fun l ->
        (l |> Seq.head |> char), (l |> Seq.skip 1 |> Seq.head |> int))
    >> Seq.toList

let moveTail (rope:Rope) =
    let distX = rope.Head.X - rope.Tail.X
    let distY = rope.Head.Y - rope.Tail.Y
    match Math.Abs distX, Math.Abs distY with
    | 2, 0 | 0, 2 | 2, 1 | 1, 2 ->
        { rope with Tail = {
                X = rope.Tail.X + Math.Sign distX
                Y = rope.Tail.Y + Math.Sign distY }}
    | _, _ -> rope

let moveHead (head:Coords) (move:char) =
    match move with
    | 'R' -> { head with X=head.X+1 }
    | 'L' -> { head with X=head.X-1 }
    | 'U' -> { head with Y=head.Y+1 }
    | 'D' -> { head with Y=head.Y-1 }

let moveRope (rope:Rope) (move:char) =
    { rope with Head = moveHead rope.Head move }
    |> moveTail

let play (moves:(char*int) list) =
    moves
    |> Seq.bind (fun (move, steps) ->
        List.init steps (fun _ -> move))
    |> Seq.fold ( fun (rope, visited) move ->
            moveRope rope move
            |> (drawState {X=6;Y=5} move)
            |> (fun rope -> rope, rope.Tail::visited)
        ) (Rope.init, [])

let puzzle1 =
    parse
    >> Seq.bind (fun (move, steps) ->
        List.init steps (fun _ -> move))
    >> Seq.fold ( fun (rope, visited) move ->
            moveRope rope move
            |> (fun rope -> rope, rope.Tail::visited)
        ) (Rope.init, [])
    >> fun (_, visited) ->
        visited
        |> Seq.distinct
        |> Seq.length