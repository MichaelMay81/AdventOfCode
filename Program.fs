open System
open System.IO
open AoC_Mike

let getPuzzleInput filePath : int seq =
    let filePath = Path.Combine(__SOURCE_DIRECTORY__, filePath)
    File.ReadLines(filePath)
    |> Seq.map Int32.TryParse
    |> Seq.filter (fun (parsed, _) -> parsed)
    |> Seq.map (fun (_, value) -> value)

[<EntryPoint>]
let main argv =
    let input = [ 1721; 979; 366; 299; 675; 1456 ]
    
    printfn "day1-1 Test:  %A" (Day1.puzzle1 input) 
    printfn "day1-1 Final: %A" (getPuzzleInput "Inputs/Day1.txt" |> Seq.toList |> Day1.puzzle1)

    printfn "day1-2 Test:  %A" (Day1.puzzle2 input)
    printfn "day1-2 Final: %A" (getPuzzleInput "Inputs/Day1.txt" |> Seq.toList |> Day1.puzzle2)
    0 // return an integer exit code