module AoC2020.Day17_2

open System
open System.ComponentModel.Design
open FSharpPlus

type Coordinates = {
    X: int
    Y: int
    Z: int
    W: int
} with
    static member (+) (a, b) = {X=a.X+b.X; Y=a.Y+b.Y; Z=a.Z+b.Z; W=a.W+b.W}
    static member OfTuple (x, y, z, w) = {X=x; Y=y; Z=z; W=w}
    
type PocketDim = PocketDim of Set<Coordinates>
module PocketDims =
    let minMaxOfRange = Seq.fold (fun s v -> min (fst s) v, max (snd s) v) (Int32.MaxValue, Int32.MinValue)
    let rangeX (PocketDim dim) = dim |> Seq.map (fun d -> d.X) |> minMaxOfRange
    let rangeY (PocketDim dim) = dim |> Seq.map (fun d -> d.Y) |> minMaxOfRange
    let rangeZ (PocketDim dim) = dim |> Seq.map (fun d -> d.Z) |> minMaxOfRange
    let rangeW (PocketDim dim) = dim |> Seq.map (fun d -> d.W) |> minMaxOfRange
    let isActive coordinate (PocketDim dim) = dim |> Set.contains coordinate
    let countActive (PocketDim dim) = dim |> Set.count

let permute4 values1 values2 values3 values4 =
    values1
    |> Seq.collect (fun x -> values2
                             |> Seq.collect (fun y -> values3
                                                      |> Seq.collect (fun z -> values4
                                                                               |> Seq.map (fun w -> (x, y, z, w)))))
let permute4times value = permute4 value value value value

let fetchActiveNeighbours (coords:Coordinates) (pocketDim:PocketDim) =
    {-1 .. 1}
    |> permute4times
    |> Seq.filter ((<>) (0, 0, 0, 0))
    |> Seq.map (Coordinates.OfTuple >> (+) coords)
    |> Seq.filter ((PocketDims.isActive |> flip) pocketDim)

let analyseNeighbours (coordinate:Coordinates) (pocketDim:PocketDim) =
    let state = PocketDims.isActive coordinate pocketDim
    let neighbourCount =
        fetchActiveNeighbours coordinate pocketDim
        |> Seq.length
    
    match state, neighbourCount with
    | true, 2
    | true, 3 -> true
    | true, _ -> false
    | false, 3 -> true
    | false, _ -> false
    
let analysePocketDim (pocketDim:PocketDim) =
    let rangeX = pocketDim |> PocketDims.rangeX
    let rangeY = pocketDim |> PocketDims.rangeY
    let rangeZ = pocketDim |> PocketDims.rangeZ
    let rangeW = pocketDim |> PocketDims.rangeW
    permute4
        {fst rangeX - 1 .. snd rangeX + 1}
        {fst rangeY - 1 .. snd rangeY + 1}
        {fst rangeZ - 1 .. snd rangeZ + 1}
        {fst rangeW - 1 .. snd rangeW + 1}
    |> Seq.map Coordinates.OfTuple
    |> Seq.filter (flip analyseNeighbours pocketDim)
    |> Set.ofSeq
    |> PocketDim
    
let parse (input:string seq) =
    input
    |> Seq.mapi (fun x l -> l |> Seq.mapi (fun y v -> (v, {X=x; Y=y; Z=0; W=0})))
    |> Seq.concat
    |> Seq.choose (fun (v, coordinate) ->
                        match v with
                        | '#' -> Some coordinate
                        | '.' -> None
                        | _ -> failwith "this shouldn't happen")
    |> Set.ofSeq
    |> PocketDim
    
let repeat n f =
    Seq.init n (fun _ -> f)
    |> Seq.reduce (>>)
    
let puzzle (cycles:int) (input:string seq) : int=
    input
    |> parse
    |> (repeat cycles analysePocketDim)
    |> PocketDims.countActive