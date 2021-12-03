open AoC2021
open AoC2021.Helpers
open Day2
open Day2_1

[<EntryPoint>]
let main argv =
    let input1 = [
        Forward 5
        Down 5
        Forward 8
        Up 3
        Down 8
        Forward 2
    ]
    
    printfn "%A" (input1 |> Day2_2.puzzle)
    printfn "%A" (getPuzzleInput "../inputs/Day2.txt" |> Day2.parseCmds |> Day2_2.puzzle)

    //printfn "%A" (input1 |> Day1.puzzle1)
    //printfn "%A" (getPuzzleInputAsInt "../inputs/Day1.txt" |> Day1.puzzle1)
    
    //
    //printfn "%A" (input1 |> Helpers.triplewise2)
    //printfn "%A" (input1 |> Day1.puzzle2)
    //printfn "%A" (getPuzzleInputAsInt "../inputs/Day1.txt" |> Day1.puzzle2)

    0 // return an integer exit code