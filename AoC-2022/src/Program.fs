open AoC2022
open Helpers

[<EntryPoint>]
let main _ =
    let input1 = "mjqjpqmgbljsphdztnvjfqwrcgsmlb"
    let input2 = "bvwbjplbgvbhsrlpgdmjqwftvncz"
    let input3 = "nppdvjthqldpwncqszvftbrmjlhg"
    let input4 = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg"
    let input5 = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw"

    input1 |> Day6.puzzle1 |> printfn "%i ? %A" 7
    input2 |> Day6.puzzle1 |> printfn "%i ? %A" 5
    input3 |> Day6.puzzle1 |> printfn "%i ? %A" 6
    input4 |> Day6.puzzle1 |> printfn "%i ? %A" 10
    input5 |> Day6.puzzle1 |> printfn "%i ? %A" 11
    "../inputs/day6.txt" |> readAllText |> Day6.puzzle1 |> printfn "%A"
    
    input1 |> Day6.puzzle2 |> printfn "19 ? %A"
    input2 |> Day6.puzzle2 |> printfn "23 ? %A"
    input3 |> Day6.puzzle2 |> printfn "23 ? %A"
    input4 |> Day6.puzzle2 |> printfn "29 ? %A"
    input5 |> Day6.puzzle2 |> printfn "26 ? %A"
    "../inputs/day6.txt" |> readAllText |> Day6.puzzle2 |> printfn "%A"
    0