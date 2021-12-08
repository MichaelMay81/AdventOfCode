module AoC2021.Day7

open System
open FSharpPlus

let median points =
    let numOfPnts = ((points |> Seq.length) - 1) |> float
    points
    |> Seq.sort
    |> (fun sorted ->
        match (numOfPnts % 2.0) with
        | 0.0 ->
            let id1 = numOfPnts / 2.0 - 1.0 |> int
            let id2 = numOfPnts / 2.0 |> int
            
            let pnt1 = sorted |> Seq.item id1
            let pnt2 = sorted |> Seq.item id2

            (pnt1 + pnt2) / 2
        | _ ->
            sorted |> Seq.item ((numOfPnts-1.0) / 2.0 |> int)
    )

let arithmeticMean (points: int seq) =
    points
    |> Seq.sum
    |> float
    |> flip (/) (points |> Seq.length |> float)

let calculateFuelConsumption points position =
    points
    |> Seq.map ((-) position)
    |> Seq.map (float >> Math.Abs >> int)
    |> Seq.sum

let puzzle1 points =
    let med = median points
    calculateFuelConsumption points med

let gaussSumFormula value =
    value |> float
    |> function value -> value * (value  + 1.0) / 2.0

let calculateLanternFishFuelConsumption position points =
    points
    |> Seq.map ((-) position)
    |> Seq.map (float >> Math.Abs >> int64)
    |> Seq.map (gaussSumFormula >> int64)
    |> Seq.sum

let puzzle2 points =
    let mean = arithmeticMean points
    let pntFloor = mean |> Math.Floor |> int
    let pntCeiling = mean |> Math.Ceiling |> int
    
    [ calculateLanternFishFuelConsumption pntFloor points
      calculateLanternFishFuelConsumption pntCeiling points]
    |> Seq.min

// Haskel style
let solve1 pos =
    let median = pos |> List.item ((List.length pos) / 2)
    Seq.sum <| Seq.map (fun x -> Math.Abs (float <| x - median) |> int) pos

// Haskel style with FSharpPlus
let solve1_fsp (pos: int list) =
    let median = pos |> item ((length pos) / 2)
    sum <| map (fun x -> abs <| x - median) pos

// FSharp style
let solve1_fs (pos: int list) =
    let median = pos |> item ((length pos) / 2)
    pos
    |> map (flip (-) median >> abs)
    |> sum