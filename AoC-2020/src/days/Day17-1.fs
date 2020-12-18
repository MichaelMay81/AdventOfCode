module AoC2020.Day17_1

open System
open System.ComponentModel.Design
open FSharpPlus

type Coordinates = {
    X: int
    Y: int
    Z: int
} with
    static member (+) (a, b) = {X=a.X+b.X; Y=a.Y+b.Y; Z=a.Z+b.Z}
    static member ofTuple (x, y, z) = {X=x; Y=y; Z=z}
    
type PocketDim = PocketDim of Set<Coordinates>
module PocketDims =
    let minMaxOfRange = Seq.fold (fun s v -> min (fst s) v, max (snd s) v) (Int32.MaxValue, Int32.MinValue)
    let rangeX (PocketDim dim) = dim |> Seq.map (fun d -> d.X) |> minMaxOfRange
    let rangeY (PocketDim dim) = dim |> Seq.map (fun d -> d.Y) |> minMaxOfRange
    let rangeZ (PocketDim dim) = dim |> Seq.map (fun d -> d.Z) |> minMaxOfRange
    let isActive coordinate (PocketDim dim) = dim |> Set.contains coordinate
    let countActive (PocketDim dim) = dim |> Set.count

let permute3 values1 values2 values3 =
    values1
    |> Seq.collect (fun x -> values2
                             |> Seq.collect (fun y -> values3
                                                      |> Seq.map (fun z -> (x, y, z))))
let permute3times value = permute3 value value value

let fetchActiveNeighbours (coords:Coordinates) (pocketDim:PocketDim) =
    {-1 .. 1}
    |> permute3times
    |> Seq.filter ((<>) (0,0,0))
    |> Seq.map (Coordinates.ofTuple >> (+) coords)
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
    permute3
        {fst rangeX - 1 .. snd rangeX + 1}
        {fst rangeY - 1 .. snd rangeY + 1}
        {fst rangeZ - 1 .. snd rangeZ + 1}
    |> Seq.map Coordinates.ofTuple
    |> Seq.filter (flip analyseNeighbours pocketDim)
    |> Set.ofSeq
    |> PocketDim
    
let parse (input:string seq) =
    input
    |> Seq.mapi (fun x l -> l |> Seq.mapi (fun y v -> (v, {X=x; Y=y; Z=0})))
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