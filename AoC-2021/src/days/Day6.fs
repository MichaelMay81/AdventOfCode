module AoC2021.Day6

open FSharpPlus

let puzzle1_FirstTry days initialState =
    let rec populate fishIn fishOut fishNew =
        //printfn "%A %A %A" fishIn fishOut fishNew
        match fishIn with
        | head :: tail ->
            match head with
            | 0 ->
                populate tail (6 :: fishOut) (8 :: fishNew)
            | daysLeft ->
                populate tail ((daysLeft-1) :: fishOut) fishNew
        | [] -> List.append fishNew fishOut |> List.rev

    let rec populateSchool daysPast state =
        printfn "day %i/%i (#fish: %i)" daysPast days (state|>List.length)
        if daysPast = days then
            state
        else
            populateSchool (daysPast+1) (populate state [] [])

    let result = populateSchool 0 initialState
    result |> List.length, result

let puzzle1 (days:int) (initialState:int list) =
    let rec populateSchool daysPast state =
        if daysPast = days then
            state
        else
            state
            |> List.tail
            |> List.mapi (fun i value ->
                match i with
                | 6 -> value + (state |> List.head)
                | _ -> value)
            |> flip List.append [(state |> List.head)]
            |> populateSchool (daysPast + 1)

    let counts =
        initialState
        |> List.groupBy id
        |> List.sortBy fst
        |> List.map (fun (x, xs) -> x, (xs |> List.length))

    {0 .. 8}
    |> Seq.toList
    |> List.map (fun x ->
        List.tryFind (fst >> (=) x) counts
        |> function
            | None -> 0L
            | Some (_, size) -> int64 size)
    |> populateSchool 0
    |> List.sum