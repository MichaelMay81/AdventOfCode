module AoC2021.Day1

let puzzle1 (input : int list) =
    input
    |> List.pairwise
    |> List.sumBy (fun (v1, v2) -> if v1 < v2 then 1 else 0)

let puzzle2 (input : int list) =
    input
    |> Helpers.triplewise
    |> List.map (fun (v1, v2, v3) -> v1 + v2 + v3)
    |> puzzle1
    