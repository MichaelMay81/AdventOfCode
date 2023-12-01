module AoC2023.Day1

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

let rec private tryCastStringToInt (output:int option list) (s:char list) =
    match s with
    | 'o'::'n'::'e'::tail ->
        tryCastStringToInt ((Some 1)::output) (s |> List.skip 1)
    | 't'::'w'::'o'::tail ->
        tryCastStringToInt ((Some 2)::output) (s |> List.skip 1)
    | 't'::'h'::'r'::'e'::'e'::tail ->
        tryCastStringToInt ((Some 3)::output) (s |> List.skip 1)
    | 'f'::'o'::'u'::'r'::tail ->
        tryCastStringToInt ((Some 4)::output) (s |> List.skip 1)
    | 'f'::'i'::'v'::'e'::tail ->
        tryCastStringToInt ((Some 5)::output) (s |> List.skip 1)
    | 's'::'i'::'x'::tail ->
        tryCastStringToInt ((Some 6)::output) (s |> List.skip 1)
    | 's'::'e'::'v'::'e'::'n'::tail ->
        tryCastStringToInt ((Some 7)::output) (s |> List.skip 1)
    | 'e'::'i'::'g'::'h'::'t'::tail ->
        tryCastStringToInt ((Some 8)::output) (s |> List.skip 1)
    | 'n'::'i'::'n'::'e'::tail ->
        tryCastStringToInt ((Some 9)::output) (s |> List.skip 1)
    | c :: tail -> 
        tryCastStringToInt ((tryCastCharToInt c)::output) tail
    | [] ->
        output |> List.rev

let puzzle2 (input : string seq) =
    input
    |> Seq.map
        (Seq.toList
        >> tryCastStringToInt List.empty
        >> List.choose id)
    |> Seq.map (fun ints ->
        ints |> Seq.head,
        ints |> Seq.rev |> Seq.head)
    |> Seq.map (fun (decade, unit) ->
        decade * 10 + unit)
    |> Seq.sum