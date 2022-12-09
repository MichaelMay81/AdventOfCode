open AoC2022
open Helpers
open FSharpPlus
// open FParsec

[<EntryPoint>]
let main _ =
    let input = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2"

    // input |> Day9_1.puzzle1 |> printfn "%i"
    // "../inputs/day9.txt" |> readAllText |> Day9_1.puzzle1 |> printfn "%i"

    let input2 = @"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20"

    // Day9_2.moveRope [ {X=1; Y=2}; {X=0; Y=1}; {X=0; Y=0}; {X=0; Y=0}; ] 'R'
    // |> Day9_2.draw { X=6; Y=5 }
    // |> printfn "%A"

    // input2
    // |> Day9_1.parse
    // |> Day9_2.play
    // |> fun (_, visited) ->
    //     visited
    //     |> Day9_1.drawResult {X=26;Y=21}
    //     |> printfn "%s"

    input2 |> Day9_2.puzzle2 |> printfn "%i"
    "../inputs/day9.txt" |> readAllText |> Day9_2.puzzle2 |> printfn "%i"
    0