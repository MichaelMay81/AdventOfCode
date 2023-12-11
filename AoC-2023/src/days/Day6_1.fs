module AoC2023.Day6_1

open FSharpPlus
open System

type Time = | Time of int64
type Distance = | Distance of int64

let lowerBound (Time t) (Distance d) = (float t - sqrt (float (t*t - 4L*d))) / 2.
let upperBound (Time t) (Distance d) = (float t + sqrt (float (t*t - 4L*d))) / 2.


let parse (input : string seq) =
    (input
        |> Seq.head
        |> sscanf "Time: %s"
        |> String.split [" "]
        |> Seq.filter (String.IsNullOrEmpty >> not)
        |> Seq.map int,
    input
        |> Seq.skip 1
        |> Seq.head
        |> sscanf "Distance: %s"
        |> String.split [" "]
        |> Seq.filter (String.IsNullOrEmpty >> not)
        |> Seq.map int)
    |> uncurry Seq.zip
    |> Seq.map (fun (time, distance) ->
        Time time, Distance distance)

let analyze (t:Time) (Distance d) =
    (lowerBound t (Distance (d+1L)) |> Math.Ceiling |> int64,
    upperBound t (Distance (d+1L)) |> Math.Floor |> int64)
    |> fun (lower, upper) ->
        upper - lower + 1L

let puzzle (input : string seq) =
    input
    |> parse
    |> Seq.map (uncurry analyze)
    |> Seq.fold ( * ) 1L