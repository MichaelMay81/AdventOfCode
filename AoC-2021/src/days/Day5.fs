module AoC2021.Day5

open FSharpPlus
open System

type Coord = {
    X: int
    Y: int
}
type VentLine = {
    From: Coord
    To: Coord
}

let coordToString coord =
    //sprintf "{X=%i;Y=%i}" coord.X coord.Y
    sprintf "%i,%i" coord.X coord.Y
let ventLineToString vl =
    //sprintf "{From=%s;To=%s}" (coordToString vl.From) (coordToString vl.To)
    sprintf "%s -> %s" (coordToString vl.From) (coordToString vl.To)

let interpolateVentLine (vl:VentLine) = //: Coord list =
    let dist = { X = vl.To.X - vl.From.X; Y = vl.To.Y - vl.From.Y }
    let numPts = Math.Max (Math.Abs dist.X, Math.Abs dist.Y)
    let offsetX = (float dist.X) / (float numPts)
    let offsetY = (float dist.Y) / (float numPts)
    //printfn "dist:%A numPts:%A offX:%A offY:%A" dist numPts offsetX offsetY 
    {0 .. numPts}
    |> Seq.map (
        fun i -> {
            X = vl.From.X + (offsetX * (float i) |> int);
            Y = vl.From.Y + (offsetY * (float i) |> int)
        })
    |> Seq.toList

let parseVentLine strLine =
    strLine
    |> trySscanf "%i,%i -> %i,%i"
    |> function
    | Some (x1, y1, x2, y2) -> { From = {X=x1; Y=y1}; To = {X=x2; Y=y2} }
    | None -> failwith @"Parse Error: {strLine}"
    
let parseVentLines strLines =
    strLines
    |> Seq.mapi (
        fun i line ->
            line
            |> trySscanf "%i,%i -> %i,%i"
            |> function
            | Some (x1, y1, x2, y2) -> Some { From = {X=x1; Y=y1}; To = {X=x2; Y=y2} }
            | None ->
                printfn "Parse Error (line %i): %s" i line
                None
    )
    |> Seq.choose id
    |> Seq.toList

let createCoordMap ventLines =
    ventLines
    |> Seq.map interpolateVentLine
    |> Seq.collect id
    |> Seq.groupBy id
    |> Seq.map (fun (coord, coordList) -> coord, (coordList |> Seq.length))
    |> Seq.toList

let coordMapToString coordMap =
    let minX = coordMap |> Seq.map (fun ({X=x;Y=_},_) -> x) |> Seq.min
    let maxX = coordMap |> Seq.map (fun ({X=x;Y=_},_) -> x) |> Seq.max
    let minY = coordMap |> Seq.map (fun ({X=_;Y=y},_) -> y) |> Seq.min
    let maxY = coordMap |> Seq.map (fun ({X=_;Y=y},_) -> y) |> Seq.max

    {minY .. maxY}
    |> Seq.map
        (fun y ->
            {minX .. maxX}
            |> Seq.map
                (fun x ->
                    coordMap
                    |> Seq.tryFind (fst >> (=) {X=x;Y=y})
                    |> function
                       | None -> "."
                       | Some (_, count) -> (sprintf "%i" count))
                    // |> snd
                    // |> sprintf "%i ")
            |> Seq.fold (+) "")
    |> Seq.map ((+) "\n")
    |> Seq.fold (+) ""
    // s1 + "\n" + s2
    // (+) ((+) s1 "\n") s2
    // |> Seq.collect id
    // |> Seq.map (fun {X=x;Y=y})
    // |> Seq.toList

// let puzzle1 ventLines =
//     ventLines
//     |> createCoordMap
//     |> Seq.filter (snd >> (<) 1)
    // |> Seq.length

let puzzle2 =
    createCoordMap
    >> Seq.filter (snd >> (<) 1)
    >> Seq.length

let puzzle1 ventLines =
    ventLines
    |> Seq.filter (fun {From={X=x1;Y=y1};To={X=x2;Y=y2}} -> (x1=x2) || (y1=y2))
    |> puzzle2