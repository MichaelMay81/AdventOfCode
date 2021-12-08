open AoC2021
open AoC2021.Helpers
open Day5
open System

open FSharpPlus

[<EntryPoint>]
let main argv =
    let input1 = [16;1;2;0;4;2;7;1;2;14]

    // (input1
    // |> List.sum
    // |> float)
    // / (input1 |> List.length |> float)
    // |> printfn "%A"

    // input1
    // |> List.map (flip (-) 4 >> Math.Abs)
    // |> List.sum
    // |> printfn "%A"

    input1
    |> Day7.puzzle1
    |> printfn "puzzle1: %A"

    input1
    |> Day7.solve1
    |> printfn "solve1: %A"

    input1
    |> Day7.solve1_fsp
    |> printfn "solve1 fsp: %A"

    getPuzzleInput "../inputs/Day7.txt"
    |> Seq.head
    |> String.split [","]
    |> Seq.map int
    // |> Seq.length
    |> Day7.puzzle1
    // |> Seq.sort
    // |> Seq.toList
    |> printfn "Finale %A"

    input1
    |> Day7.calculateLanternFishFuelConsumption 2
    |> printfn "Test1 Part2 %A" // 206

    input1
    |> Day7.calculateLanternFishFuelConsumption 5
    |> printfn "Test2 Part2 %A" // 168

    input1
    |> Day7.puzzle2
    |> printfn "Test3 Part2 %A"

    getPuzzleInput "../inputs/Day7.txt"
    |> Seq.head
    |> String.split [","]
    |> Seq.map int
    |> Seq.toList
    // input1
    //|> Day7.calculateLanternFishFuelConsumption 463
    |> Day7.puzzle2
    |> printfn "Final2 %A"

    // geometric Mean
    input1
    |> List.fold (*) 1
    |> float
    |> flip ( ** ) (1.0/(input1 |> List.length |> float))
    |> printfn "geo Mean: %A"

    getPuzzleInput "../inputs/Day7.txt"
    |> Seq.head
    |> String.split [","]
    |> Seq.map int
    |> Seq.max
    |> printfn "max: %A"

    // Mean
    // getPuzzleInput "../inputs/Day7.txt"
    // |> Seq.head
    // |> String.split [","]
    // |> Seq.map int
    // |> Seq.toList
    input1
    |> Day7.arithmeticMean
    |> printfn "Arithmetic Mean: %A"

    // Root Mean Square
    // inputDay7
    // |> List.map (float >> flip ( ** ) 2)
    // |> List.sum
    // |> flip (/) (inputDay7 |> List.length |> float)
    // |> Math.Sqrt
    // |> printfn "Mean: %A"

    // let input1 = [3;4;3;1;2]

    // // input1
    // // |> Day6.puzzle1 2
    // // |> printfn "%A" // 26

    // input1
    // |> Day6.puzzle1 18
    // |> printfn "%A" // 26

    // input1
    // |> Day6.puzzle1 80
    // |> printfn "%A" // 5934

    // getPuzzleInput "../inputs/Day6.txt"
    // |> Seq.head
    // |> String.split [","]
    // |> Seq.map int
    // |> Seq.toList
    // |> Day6.puzzle1 80
    // |> printfn "%A" // 390923

    // input1
    // |> Day6.puzzle1 256
    // |> printfn "%A" // 

    // getPuzzleInput "../inputs/Day6.txt"
    // |> Seq.head
    // |> String.split [","]
    // |> Seq.map int
    // |> Seq.toList
    // |> Day6.puzzle1 256
    // |> printfn "%A"

    0 // return an integer exit code