open AoC2022
open System.IO
open Helpers

[<EntryPoint>]
let main argv =
    let input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw".Split "\n"

    input |> Day3.puzzle1 |> printfn "%A"
    "../inputs/day3.txt" |> readAllLines |> Day3.puzzle1 |> printfn "%A"
    
    input |> Day3.puzzle2 |> printfn "%A"
    "../inputs/day3.txt" |> readAllLines |> Day3.puzzle2 |> printfn "%A"
    0