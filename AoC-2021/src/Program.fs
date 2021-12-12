open AoC2021
open AoC2021.Helpers
open FSharp.Collections

open FSharpPlus

[<EntryPoint>]
let main argv =
    let input1 = [
        [1;1;1;1;1]
        [1;9;9;9;1]
        [1;9;1;9;1]
        [1;9;9;9;1]
        [1;1;1;1;1]
    ]
    let input2 = [
        [5;4;8;3;1;4;3;2;2;3]
        [2;7;4;5;8;5;4;7;1;1]
        [5;2;6;4;5;5;6;1;7;3]
        [6;1;4;1;3;3;6;1;4;6]
        [6;3;5;7;3;8;5;4;7;8]
        [4;1;6;7;5;2;4;6;4;5]
        [2;1;7;6;8;4;1;7;2;1]
        [6;8;8;2;8;8;1;1;3;4]
        [4;8;4;6;8;4;8;5;5;4]
        [5;2;8;3;7;5;1;5;2;6]
    ]

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

    input2
    |> Day11.puzzle2
    |> fun (days, dumbos) ->
        printfn "days: %A" days
        dumbos
        |> List.map (fun v -> (v |> List.map (printf " %A") |> ignore; printfn ""))
        |> ignore // 195

    getPuzzleInput "../inputs/Day11.txt"
    |> Seq.map (fun str -> str |> Seq.map (string >> int) |> Seq.toList)
    |> Seq.map Seq.toList
    |> Seq.toList
    |> Day11.puzzle2
    |> fun (days, dumbos) ->
        printfn "days: %A" days
        dumbos
        |> List.map (fun v -> (v |> List.map (printf " %A") |> ignore; printfn ""))
        |> ignore // 232

    0 // return an integer exit code