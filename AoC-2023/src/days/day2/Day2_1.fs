module AoC2023.Day2_1

open FSharpPlus

type CubeColor =
| Red
| Green
| Blue
    with
    static member tryParse =
        function
        | "red" -> Some Red
        | "green" -> Some Green
        | "blue" -> Some Blue
        | _ -> None
    static member tryParse2 : string -> option<CubeColor> =
        Seq.head
        >> function
        | 'r' -> Some Red
        | 'g' -> Some Green
        | 'b' -> Some Blue
        | _ -> None

type CubeCount = {
    Count : int
    Color : CubeColor
}

type Game = {
    GameId : int
    Subsets : CubeCount list list
}

let parseCubeCount (tryParse:string -> option<CubeColor>) (move:string) =
    move
    |> trySscanf " %i %s"
    |> Option.bind (fun (id, color) ->
        tryParse color
        |> Option.map (fun cubeColor ->
            {   Count = id
                Color = cubeColor}))

let parseGameInfo (tryParse:string -> option<CubeColor>) (info:string) =
    info.Split(";")
    |> Seq.map (fun singleGrab ->
        singleGrab.Split(",")
        |> Seq.map (parseCubeCount tryParse))

let parseLine (tryParse:string -> option<CubeColor>) (line:string) =
    line
    |> trySscanf "Game %i:%s"
    |> Option.map (fun (gameId, info) ->
        gameId, parseGameInfo tryParse info)
    // unpack all Options
    |> Option.defaultValue (-1, [])
    |> (fun (gameId, info) ->
        {   GameId = gameId
            Subsets = info |> Seq.map (Seq.choose id >> Seq.toList) |> Seq.toList})

let puzzle (redCount:int) (greenCount:int) (blueCount:int) (games:Game seq) =
    games
    |> Seq.filter (fun {GameId=gameId;Subsets=subsets} ->
        subsets
        |> Seq.filter (
            Seq.filter (fun {Count=count; Color=color} ->
                match color with
                | Red -> count > redCount
                | Green -> count > greenCount
                | Blue -> count > blueCount)
            >> Seq.isEmpty
            >> not)
        |> Seq.isEmpty)
    |> Seq.map (fun {GameId=gameId;Subsets=_} -> gameId)
    |> Seq.sum