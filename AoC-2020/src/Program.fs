open AoC2020
open Helpers
open FSharpPlus

let getPuzzleInput filePath =
    readLines filePath |> outputErrorAndDefault Seq.empty
    
[<EntryPoint>]
let main argv =
    let input1 = ["L.LL.LL.LL"
                  "LLLLLLL.LL"
                  "L.L.L..L.."
                  "LLLL.LL.LL"
                  "L.LL.LL.LL"
                  "L.LLLLL.LL"
                  "..L.L....."
                  "LLLLLLLLLL"
                  "L.LLLLLL.L"
                  "L.LLLLL.LL"]
    let input2 = ["#.##.##.##"
                  "#######.##"
                  "#.#.#..#.."
                  "####.##.##"
                  "#.##.##.##"
                  "#.#####.##"
                  "..#.#....."
                  "##########"
                  "#.######.#"
                  "#.#####.##"]
//    printfn "%A" (input |> Day11.puzzle1)
    printfn "%A" (input2
                 |> Day11.stringsToPositions
                 //|> Day11.analysePositions
                 |> Day11.analysePositions
                 |> Day11.positionsToString)
    
    
    0 // return an integer exit code