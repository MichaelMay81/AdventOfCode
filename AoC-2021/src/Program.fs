open AoC2021
open AoC2021.Helpers
open FSharp.Collections

open FSharpPlus

[<EntryPoint>]
let main argv =
    let input1 = [
        "[({(<(())[]>[[{[]{<()<>>"
        "[(()[<>])]({[<{<<[]>>("
        "{([(<{}[<>[]}>{[]{[(<()>"
        "(((({<>}<{<{<>}{[]{[]{}"
        "[[<[([]))<([[{}[[()]]]"
        "[{[{({}]{}}([{[{{{}}([]"
        "{<[[]]>}<{[{[{[]{()[[[]"
        "[<(<(<(<{}))><([]([]()"
        "<{([([[(<>()){}]>(<<{{"
        "<{([{{}}[<[[[<>{}]]]>[]]"
    ]

    input1
    |> Day10.puzzle1
    |> printfn "%A" // 26397

    getPuzzleInput "../inputs/Day10.txt"
    |> Day10.puzzle1
    |> printfn "%A" // 343863

    input1
    |> Day10.puzzle2
    |> printfn "%A" // 288957

    getPuzzleInput "../inputs/Day10.txt"
    |> Day10.puzzle2
    |> printfn "%A" // 2924734236

    0 // return an integer exit code