module AoC2022.Day1

let parse (str:string) : int list list =
    str.Split("\n\n")
    |> Seq.map (fun str ->
        str.Split("\n")
        |> Seq.map(int))
    |> Seq.map Seq.toList
    |> Seq.toList

let puzzle1 (input : int list list) =
    input
    |> Seq.map (Seq.fold (+) 0)
    |> Seq.max

let puzzle2 (input : int list list) : int =
    input
    |> Seq.map (Seq.fold (+) 0)
    |> Seq.sortDescending
    |> Seq.take 3
    |> Seq.sum