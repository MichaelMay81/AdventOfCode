open AoC2021
open AoC2021.Helpers
open FSharp.Collections

open FSharpPlus

[<EntryPoint>]
let main argv =
    let input1 = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf"
    let input2 = [
        "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe"
        "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc"
        "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg"
        "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb"
        "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea"
        "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb"
        "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe"
        "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef"
        "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb"
        "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
    ]

    input2
    |> map Day8.parse7sEntry
    |> Day8.puzzle1
    |> printfn "%A" // 26

    getPuzzleInput "../inputs/Day8.txt"
    |> map Day8.parse7sEntry
    |> Day8.puzzle1
    |> printfn "%A" // 239

    input1
    |> Day8.parse7sEntry
    |> fst
    |> Seq.map Set
    |> Day8.solve
    |> printfn "solve: %A"

    input1
    |> Day8.parse7sEntry
    |> (fun (patterns, output) -> Day8.decode (patterns |> Seq.map Set) (output |> Seq.map Set))
    |> printfn "decode: %A"

    [input1
    |> Day8.parse7sEntry]
    |> Day8.puzzle2
    |> printfn "puzzle2: %A"

    input2
    |> map Day8.parse7sEntry
    |> Day8.puzzle2
    |> printfn "puzzle2: %A"

    getPuzzleInput "../inputs/Day8.txt"
    |> map Day8.parse7sEntry
    |> Day8.puzzle2
    |> printfn "puzzle2: %A"

    0 // return an integer exit code