open AoC2021
open AoC2021.Helpers
open Day5
open System

[<EntryPoint>]
let main argv =
    let input1 = [
        "0,9 -> 5,9"
        "8,0 -> 0,8"
        "9,4 -> 3,4"
        "2,2 -> 2,1"
        "7,0 -> 7,4"
        "6,4 -> 2,0"
        "0,9 -> 2,9"
        "3,4 -> 1,4"
        "0,0 -> 8,8"
        "5,5 -> 8,2"
    ]
    let input2 = "1,1 -> 1,3" |> parseVentLine
    let input3 = "9,7 -> 7,7" |> parseVentLine

    // printfn "%A" (input1 |> parseVentLines)
    input1
    |> parseVentLines
    |> List.map (ventLineToString >> (printfn "%s"))
    |> ignore

    printf "%A: " (input2 |> ventLineToString)
    input2
    |> interpolateVentLine
    |> List.map coordToString
    |> (printfn "%A")

    printf "%A: " (input3 |> ventLineToString)
    input3
    |> interpolateVentLine
    |> List.map coordToString
    |> (printfn "%A")

    input1
    |> parseVentLines
    |> puzzle1
    // |> List.map (fun (coord, count) -> sprintf "%s: %i" (coordToString coord) count)
    |> printfn "%A"

    input1
    |> parseVentLines
    //|> Seq.filter (fun {From={X=x1;Y=y1};To={X=x2;Y=y2}} -> (x1=x2) || (y1=y2))
    |> createCoordMap
    |> coordMapToString
    |> printfn "%A"

    input1
    |> parseVentLines
    //|> Seq.filter (fun {From={X=x1;Y=y1};To={X=x2;Y=y2}} -> (x1=x2) || (y1=y2))
    |> createCoordMap
    |> Seq.filter (snd >> (<) 1)
    |> Seq.length
    |> printfn "%i" // 5

    getPuzzleInput "../inputs/Day5.txt"
    |> parseVentLines
    //|> Seq.filter (fun {From={X=x1;Y=y1};To={X=x2;Y=y2}} -> (x1=x2) || (y1=y2))
    |> createCoordMap
    |> Seq.filter (snd >> (<) 1)
    |> Seq.length
    |> printfn "%i" // 6856

    0 // return an integer exit code