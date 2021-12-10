module AoC2021.Day9

open System
open FSharpPlus
open Helpers

let itemOrDefault itemId defaultValue items =
    items
    |> Seq.tryItem itemId
    |> function
        | Some v -> v
        | None -> defaultValue

type Neighbours = (int*(int*int*int)*int)
type NeighbourHood = Neighbours seq seq

let withNeighbours (heightMap: int list list) : NeighbourHood =
    let border = 9
    
    let width = heightMap |> head |> length

    heightMap
    |> Seq.append [(List.init width (fun _ -> border))]
    |> Seq.append <|[(List.init width (fun _ -> border))]
    |> Seq.windowed 3
    |> Seq.map (fun lists ->
        let l0 = lists |> item 0
        let l2 = lists |> item 2
        lists
        |> item 1
        |> Seq.append [border]
        |> Seq.append <| [border]
        |> Seq.windowed 3
        |> Seq.map (fun vs -> vs|>item 0, vs|>item 1, vs|>item 2)
        |> Seq.zip3 l0 <| l2
    )

let puzzle1 (heightMap:int list list) =
    
    let width = heightMap |> head |> length
    let border = -1
    //let heightMap = heightMap |> Seq.collect id
    //let length = heightMap |> length
    // let ups = Seq.append
    //             (List.init width (fun _ -> 9))
    //             (heightMap |> take (length - width))
    // let lefts = Seq.append [9] (heightMap |> take (length - 1))
    // let rights = Seq.append (heightMap |> skip 1) [9]
    // let downs = Seq.append
    //                 (heightMap |> skip width)
    //                 (List.init width (fun _ -> 9))

    // heightMap
    // |> Seq.mapi (fun index value ->
    //     let up = itemOrDefault (index-width) 9 heightMap
    //     let left = itemOrDefault (index-1) 9 heightMap
    //     let right = itemOrDefault (index+1) 9 heightMap
    //     let down = itemOrDefault (index+width) 9 heightMap
    //     printfn "%i: %i %i %i %i %i" index value up left right down)
    
    let lowPoints =
        heightMap
        |> withNeighbours
        |> Seq.collect id
        |> Seq.filter (fun (up, (left, value, right), down) ->
                [up;left;right;down] |> Seq.forall ((<) value))
        |> Seq.map (fun (_, (_, value, _), _) -> value)
        
    lowPoints
    |> Seq.map ((+) 1) // risk value
    |> Seq.sum

let puzzle2 (heightMap:int list list) =
    // let mutable coordMap : Map<int*int,int> = Map.empty

    let checkNeighbours ((x, y):int*int) ((up, (left, value, right), down):Neighbours) =
        // coordMap <- coordMap.Add((x,y), coordMap |> MapTryGetValue ((x,y)) |>  function | None -> 1 | Some v -> v + 1)
        // printfn "checkNeighbours: %A" coordMap
        // printf "."

        [ (up,    (x,   y-1))
          (left,  (x-1, y))
          (right, (x+1, y))
          (down , (x,   y+1))]
        |> Seq.filter (fun (v, _) -> v <> 9)
        |> Seq.filter (fun (v, _) -> v > value)
        |> Seq.toList
        
    let tryGetNeighbour ((x, y):int*int) (hood:NeighbourHood) =
        hood
        |> Seq.tryItem y
        |> Option.map (Seq.tryItem x)
        |> Option.flatten

    let rec findBasin (coords:(int*int) seq) (hood:NeighbourHood) (acc:(int*(int*int)) seq) =
        if (coords |> length) = 0
        then acc
        else
            // printf "findBasin: %A" (coords |> Seq.toList)

            let newValues =
                coords
                |> Seq.map (fun coord -> tryGetNeighbour coord hood |> Option.map (fun nh -> coord,nh))
                |> Seq.choose id
                |> Seq.map (fun (coord, nh) -> checkNeighbours coord nh)
                |> Seq.collect id
                |> Seq.distinct
                |> Seq.filter (flip Seq.contains acc >> not)
                |> Seq.toList

            // printfn ""

            let _, newCoords = newValues |> unzip
            let newAcc = Seq.append acc newValues
            findBasin newCoords hood newAcc

    let hood = heightMap |> withNeighbours

    let lowPoints =
        hood
        |> Seq.mapi (fun y row -> row |> Seq.mapi (fun x nh -> (x,y), nh))
        |> Seq.collect id
        |> Seq.filter (fun (_, (up, (left, value, right), down)) ->
                [up;left;right;down] |> Seq.forall ((<) value))
        |> Seq.map (fun (coords, (_, (_, value, _), _)) -> value, coords)
        |> Seq.toList
    // let _, newCoords = lowPoints |> unzip

    let result =
        lowPoints
        |> Seq.map (fun pnt ->
            let _, newCoords = pnt
            findBasin [newCoords] hood [pnt])
        |> Seq.map length
        //|> Seq.map Seq.toList
        // |> Seq.toList
        |> Seq.sortDescending
        |> Seq.take 3
        |> Seq.fold (*) 1
    // printfn "Debug: %A %A" (coordMap |> Map.values |> Seq.sum ) coordMap
    result