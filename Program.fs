open AoC_Mike
open Helpers
open FSharpPlus

let getPuzzleInput filePath =
    readLines filePath |> outputErrorAndDefault Seq.empty

let testAll () =
    let input = [ 1721; 979; 366; 299; 675; 1456 ]
    
    printfn "day1-1 Test:  %A" (Day1.puzzle1 input) 
    printfn "day1-1 Final: %A" (getPuzzleInput "Inputs/Day1.txt" |> Seq.toList |> List.map int |> Day1.puzzle1)

    printfn "day1-2 Test:  %A" (Day1.puzzle2 input)
    printfn "day1-2 Final: %A" (getPuzzleInput "Inputs/Day1.txt" |> Seq.toList |> List.map int |> Day1.puzzle2)
    
    let input = ["1-3 a: abcde"; "foobar"; "1-3 b: cdefg"; "2-9 c: ccccccccc"] |> List.toSeq
    printfn "day2-1 Test:  %A" (Day2.puzzle1 input)
    printfn "day2-1 Final: %A" (getPuzzleInput "Inputs/Day2.txt" |> Day2.puzzle1)
    
    printfn "day2-2 Test:  %A" (Day2.puzzle2 input)
    printfn "day2-2 Final: %A" (getPuzzleInput "Inputs/Day2.txt" |> Day2.puzzle2)
    
//    printfn "foobar %A" (["1-3 a: abcde" |> Day2.parse] |> filter |> Seq.map Day2.isPassCorrect2)
//    printfn "foobar %A" (["1-3 b: cdefg" |> Day2.parse] |> filter |> Seq.map Day2.isPassCorrect2)
//    printfn "foobar %A" (["2-9 c: ccccccccc" |> Day2.parse] |> filter |> Seq.map Day2.isPassCorrect2)

[<EntryPoint>]
let main argv =
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
    printfn "day3-1 Final:  %A" (getPuzzleInput "Inputs/Day3.txt" |> Seq.toArray |> Day3.puzzle1)
    
    printfn "day3-2 Test:  %A" (Day3.puzzle2 input)
    printfn "day3-2 Final:  %A" (readLines "Inputs/Day3.txt" |> Result.map ( Seq.toArray >> Day3.puzzle2))

    0 // return an integer exit code