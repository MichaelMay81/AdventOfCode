module AoC2021.Day11

open FSharpPlus

let rec private calcFlashes (numOfFlashes:int) (dumbos: int list list) =
    // find flashes (all greate than 9)
    let tenUpCoords =
        dumbos
        |> Seq.mapi (fun y row -> row |> Seq.mapi (fun x v -> v, (x, y)))
        |> Seq.collect id
        |> Seq.filter (fst >> ((<)9))
        |> Seq.map snd

    match tenUpCoords |> length with
    | 0 -> numOfFlashes, dumbos
    | _ ->
        let numOfFlashes = numOfFlashes + (tenUpCoords |> length)

        // set 10s to 0s
        let dumbos =
            dumbos
            |> Seq.mapi (fun y row -> row |> Seq.mapi (fun x v ->
                tenUpCoords
                |> Seq.contains (x,y)
                |> function
                    | false -> v
                    | true -> 0))

        // get adjacent coordinates to the found zeroes
        let adjacentCoords =
            tenUpCoords
            |> map (fun (x,y) -> [
                x-1,y-1; x,y-1; x+1,y-1
                x-1,y;          x+1,y
                x-1,y+1; x,y+1; x+1,y+1])
            |> Seq.collect id
            |> groupBy id
            |> map (fun (coo, cooList) -> coo, cooList |> length)
            
        // increment adjacent values
        let dumbos =
            dumbos
            |> Seq.mapi (fun y row -> row |> Seq.mapi (fun x v ->
                adjacentCoords
                |> Seq.tryFind (fst >> ((=)(x,y)))
                |> function
                    | None -> v
                    | Some (_, inc) ->
                        match v with
                        | 0 -> 0
                        | _ -> v + inc ))
            |> Seq.map Seq.toList
            |> Seq.toList

        calcFlashes numOfFlashes dumbos

let rec private calcFlashesForDays (numOfFlashes:int) (days:int) (dumbos: int list list) =
    match days with
    | 0 -> numOfFlashes, dumbos
    | _ ->
        dumbos
        // increase by 1
        |> Seq.map (Seq.map ((+) 1))
        |> Seq.map Seq.toList
        |> Seq.toList
        |> calcFlashes numOfFlashes
        |> fun (nof,dumbos) -> calcFlashesForDays nof (days-1) dumbos


let puzzle1 (days:int) (dumbos: int list list) =
    calcFlashesForDays 0 days dumbos

let rec private calcSyncFlashes (days:int) (dumbos: int list list) =
    if (days % 20) = 0 then printf "."
    if (days % 100) = 0 then printf "%i" (days/100)

    let numOfDumbos = dumbos |> Seq.map length |> sum
    let numOfZeroes = dumbos |> Seq.collect id |> Seq.filter ((=)0) |> length

    // if days > 193 && days < 196 then
    //     printfn "\n%A: %A = %A" days numOfZeroes numOfDumbos
    //     dumbos
    //     |> List.map (fun v -> (v |> List.map (printf " %A") |> ignore; printfn ""))
    //     |> ignore // 204

    match numOfDumbos = numOfZeroes with
    | true ->
        days, dumbos
    | _ ->
        dumbos
        // increase by 1
        |> Seq.map (Seq.map ((+) 1))
        |> Seq.map Seq.toList
        |> Seq.toList
        |> calcFlashes 0
        |> fun (_,dumbos) -> calcSyncFlashes (days+1) dumbos

let puzzle2 (dumbos: int list list) =
    let result = calcSyncFlashes 0 dumbos
    printfn ""
    result