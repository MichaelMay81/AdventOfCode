module AoC2023.Day1_1

let parse (str:string) : string array =
    str.Split("\n")

let tryCastCharToInt (c:char) : int option =
    let charCode = int c
    match charCode < 48 || charCode > 57 with
    | true -> None
    | false -> Some (charCode - 48)

let puzzle1 (input : string seq) =
    input
    |> Seq.map (
        Seq.map tryCastCharToInt
        >> Seq.choose id)
    |> Seq.map (fun ints ->
        ints |> Seq.head,
        ints |> Seq.rev |> Seq.head)
    |> Seq.map (fun (decade, unit) ->
        decade * 10 + unit)
    |> Seq.sum