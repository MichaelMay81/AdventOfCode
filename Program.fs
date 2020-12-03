open System
open System.IO
open AoC_Mike
open Helpers
open FSharpPlus

//let getPuzzleInput filePath : int seq =
//    let filePath = Path.Combine(__SOURCE_DIRECTORY__, filePath)
//    File.ReadLines(filePath)
//    |> Seq.map Int32.TryParse
//    |> Seq.filter (fun (parsed, _) -> parsed)
//    |> Seq.map (fun (_, value) -> value)

[<EntryPoint>]
let main argv =
    let input = [ 1721; 979; 366; 299; 675; 1456 ]
    
//    printfn "day1-1 Test:  %A" (Day1.puzzle1 input) 
//    printfn "day1-1 Final: %A" (getPuzzleInput "Inputs/Day1.txt" |> Seq.toList |> Day1.puzzle1)
//
//    printfn "day1-2 Test:  %A" (Day1.puzzle2 input)
//    printfn "day1-2 Final: %A" (getPuzzleInput "Inputs/Day1.txt" |> Seq.toList |> Day1.puzzle2)
    
//    let input = ["1-3 a: abcde"; "foobar"; "1-3 b: cdefg"; "2-9 c: ccccccccc"] |> List.toSeq
//    printfn "day2-1 Test:  %A" (Day2.puzzle1 input)
//    printfn "day2-1 Final: %A" (readLines "Inputs/Day2.txt" |> outputErrorAndDefault Seq.empty |> Day2.puzzle1)
//    
//    printfn "day2-2 Test:  %A" (Day2.puzzle2 input)
//    printfn "day2-2 Final: %A" (readLines "Inputs/Day2.txt" |> outputErrorAndDefault Seq.empty |> Day2.puzzle2)
    
    let input = [|"..##......."
                  "#...#...#.."
                  ".#....#..#."
                  "..#.#...#.#"
                  ".#...##..#."
                  "..#.##....."
                  ".#.#.#....#"
                  ".#........#"
                  "#.##...#..."
                  "#...##....#"
                  ".#..#...#.#"|]
    
    printfn "day3-1 Test:  %A" (Day3.puzzle1 input)
    printfn "day3-1 Final:  %A" (readLines "Inputs/Day3.txt"
                                 |> outputErrorAndDefault Seq.empty
                                 |> Seq.toArray
                                 |> Day3.puzzle1)
    
    printfn "day3-2 Test:  %A" (Day3.puzzle2 input)
    printfn "day3-2 Final:  %A" (readLines "Inputs/Day3.txt"
                                 |> outputErrorAndDefault Seq.empty
                                 |> Seq.toArray
                                 |> Day3.puzzle2)
    
//    printfn "foobar %A" (["1-3 a: abcde" |> Day2.parse] |> filter |> Seq.map Day2.isPassCorrect2)
//    printfn "foobar %A" (["1-3 b: cdefg" |> Day2.parse] |> filter |> Seq.map Day2.isPassCorrect2)
//    printfn "foobar %A" (["2-9 c: ccccccccc" |> Day2.parse] |> filter |> Seq.map Day2.isPassCorrect2)
    0 // return an integer exit code