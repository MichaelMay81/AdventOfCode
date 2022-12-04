module AoC2022.Day4

open FSharpPlus

let parse strs =
    strs |> Seq.map(sscanf "%i-%i,%i-%i")

let puzzle1 strs =
    strs
    |> parse
    |> Seq.filter (fun (minA, maxA, minB, maxB) ->
        (minA <= minB && maxA >= maxB) ||
        (minB <= minA && maxB >= maxA))
    |> Seq.length

let puzzle2 strs =
    strs
    |> parse
    |> Seq.filter (fun (minA, maxA, minB, maxB) ->
        (minA >= minB && minA <= maxB) ||
        (maxA >= minB && maxA <= maxB) ||
        (minB >= minA && minB <= maxA) ||
        (maxB >= minA && maxB <= maxA))
    |> Seq.length