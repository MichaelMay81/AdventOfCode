open AoC2022
open Helpers
open FSharpPlus
open FParsec

[<EntryPoint>]
let main _ =
    let input = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k"

    input |> Day7.puzzle1 |> printfn "%A"
    "../inputs/day7.txt" |> readAllText |> Day7.puzzle1 |> printfn "%A"

    input |> Day7.puzzle2 |> printfn "%A"
    "../inputs/day7.txt" |> readAllText |> Day7.puzzle2 |> printfn "%A"

    0