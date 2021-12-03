open AoC2021
open AoC2021.Helpers
open Day3
open System

[<EntryPoint>]
let main argv =
    let input1 = [
        0b00100 // 4
        0b11110 // 30
        0b10110 // 22
        0b10111 // 23
        0b10101 // 21
        0b01111 // 15
        0b00111 // 7
        0b11100 // 28
        0b10000 // 16
        0b11001 // 25
        0b00010 // 2
        0b01010 // 10
    ]

    let makeItSo number =
        printfn "%A %A %A" number (Day3.numberOfBinaryDigits number) (Math.Log2 (float number))

    // printfn "%A" (input1 |> List.map ((&&&) 0b10000) |> List.filter ((=) 0) |> List.length)
    // makeItSo 0b00001 // 1
    // makeItSo 0b00010 // 2
    // makeItSo 0b00100 // 4
    // makeItSo 0b01000 // 8
    // makeItSo 0b10000 // 16
    // makeItSo 0b00110
    // makeItSo 0b00101
    // makeItSo 0b00111
    // makeItSo 0b01000
    // makeItSo 0b10111

    // printfn "foobar"
    // printfn "%A" (uint 0b101011100101)
    // printfn "%A" (int 0b111111111111)
    // printfn "%A" (int 0b101011100101)
    
    printfn "%A" (input1 |> Day3.puzzle2)
    // printfn "%A" (input1 |> Day3.calcLeastCommonBits)
    // printfn "%A" (input1 |> Day3.puzzle1)
    printfn "%A" (getPuzzleInputAsBinaryInt "../inputs/Day3.txt" |> Day3.puzzle2)

    // printfn "%A" (0b00100 &&& 0b10000)
    // printfn "%A" (0b00100 &&& 0b01000)
    // printfn "%A" (0b00100 &&& 0b00100)
    // printfn "%A" (0b00100 &&& 0b00010)
    // printfn "%A" (0b00100 &&& 0b00001)
    // printfn "%A" (input1 |> Day2_2.puzzle)
    // printfn "%A" (getPuzzleInput "../inputs/Day2.txt" |> Day2.parseCmds |> Day2_2.puzzle)

    //printfn "%A" (input1 |> Day1.puzzle1)
    //printfn "%A" (getPuzzleInputAsInt "../inputs/Day1.txt" |> Day1.puzzle1)
    
    //
    //printfn "%A" (input1 |> Helpers.triplewise2)
    //printfn "%A" (input1 |> Day1.puzzle2)
    //printfn "%A" (getPuzzleInputAsInt "../inputs/Day1.txt" |> Day1.puzzle2)

    0 // return an integer exit code