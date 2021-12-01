open AoC2021
open AoC2021.Helpers

[<EntryPoint>]
let main argv =
    let input1 = [199; 200; 208; 210; 200; 207; 240; 269; 260; 263]
    
    //printfn "%A" (input1 |> Day1.puzzle1)
    //printfn "%A" (getPuzzleInputAsInt "../inputs/Day1.txt" |> Day1.puzzle1)
    
    //printfn "%A" (input1 |> Helpers.triplewise)
    //printfn "%A" (input1 |> Helpers.triplewise2)
    //printfn "%A" (input1 |> Day1.puzzle2)
    printfn "%A" (getPuzzleInputAsInt "../inputs/Day1.txt" |> Day1.puzzle2)

    0 // return an integer exit code