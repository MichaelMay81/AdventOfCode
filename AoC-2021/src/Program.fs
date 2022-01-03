open AoC2021
open AoC2021.Helpers
open FSharp.Collections

open FSharpPlus

[<EntryPoint>]
let main argv =
    let input1 = [
        "start-A"
        "start-b"
        "A-c"
        "A-b"
        "b-d"
        "A-end"
        "b-end"
    ]
    let input2 = [
        "dc-end"
        "HN-start"
        "start-kj"
        "dc-start"
        "dc-HN"
        "LN-dc"
        "HN-end"
        "kj-sa"
        "kj-HN"
        "kj-dc"
    ]
    let input3 = [
        "fs-end"
        "he-DX"
        "fs-he"
        "start-DX"
        "pj-DX"
        "end-zg"
        "zg-sl"
        "zg-pj"
        "pj-he"
        "RW-he"
        "fs-DX"
        "pj-RW"
        "zg-RW"
        "start-pj"
        "he-WI"
        "zg-he"
        "pj-fs"
        "start-RW"
    ]

    printfn "input1:"
    input1
    |> Day12.strings2Map
    |> Day12.findPaths
    |> List.map (printfn "%A")
    |> ignore

    input1
    |> Day12.puzzle1
    |> printfn "input1: %A" // 10

    input2
    |> Day12.puzzle1
    |> printfn "input2: %A" // 19

    input3
    |> Day12.puzzle1
    |> printfn "input3: %A" // 226

    getPuzzleInput "../inputs/Day12.txt"
    |> Day12.puzzle1
    |> printfn "puzzle1: %A" // 3230

    // input2
    // |> Day12.strings2Map
    // |> printfn "input2:\n%A"

    // input3
    // |> Day12.strings2Map
    // |> printfn "input3:\n%A"

    // input1
    // |> Day11.puzzle1 2
    // |> List.map (fun v -> (v |> List.map (printf "%A") |> ignore; printfn ""))
    // |> ignore

    // input2
    // |> Day11.puzzle1 10
    // |> fun (nof, dumbos) ->
    //     printfn "nof: %A" nof
    //     dumbos
    //     |> List.map (fun v -> (v |> List.map (printf " %A") |> ignore; printfn ""))
    //     |> ignore // 204

    // input2
    // |> Day11.puzzle1 100
    // |> fun (nof, dumbos) ->
    //     printfn "nof: %A" nof
    //     dumbos
    //     |> List.map (fun v -> (v |> List.map (printf " %A") |> ignore; printfn ""))
    //     |> ignore // 1656

    // getPuzzleInput "../inputs/Day11.txt"
    // |> Seq.map (fun str -> str |> Seq.map (string >> int) |> Seq.toList)
    // |> Seq.map Seq.toList
    // |> Seq.toList
    // |> Day11.puzzle1 100
    // |> fun (nof, dumbos) ->
    //     printfn "nof: %A" nof
    //     dumbos
    //     |> List.map (fun v -> (v |> List.map (printf " %A") |> ignore; printfn ""))
    //     |> ignore // 1719

    // input2
    // |> Day11.puzzle2
    // |> fun (days, dumbos) ->
    //     printfn "days: %A" days
    //     dumbos
    //     |> List.map (fun v -> (v |> List.map (printf " %A") |> ignore; printfn ""))
    //     |> ignore // 195

    // getPuzzleInput "../inputs/Day11.txt"
    // |> Seq.map (fun str -> str |> Seq.map (string >> int) |> Seq.toList)
    // |> Seq.map Seq.toList
    // |> Seq.toList
    // |> Day11.puzzle2
    // |> fun (days, dumbos) ->
    //     printfn "days: %A" days
    //     dumbos
    //     |> List.map (fun v -> (v |> List.map (printf " %A") |> ignore; printfn ""))
    //     |> ignore // 232

    0 // return an integer exit code