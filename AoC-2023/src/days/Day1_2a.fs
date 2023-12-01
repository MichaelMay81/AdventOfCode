module AoC2023.Day1_2a

let rec private tryCastStringToInt (output:int option list) (s:char list) =
    match s with
    | 'o'::'n'::'e'::_ ->
        tryCastStringToInt ((Some 1)::output) (s |> List.skip 1)
    | 't'::'w'::'o'::_ ->
        tryCastStringToInt ((Some 2)::output) (s |> List.skip 1)
    | 't'::'h'::'r'::'e'::'e'::_ ->
        tryCastStringToInt ((Some 3)::output) (s |> List.skip 1)
    | 'f'::'o'::'u'::'r'::_ ->
        tryCastStringToInt ((Some 4)::output) (s |> List.skip 1)
    | 'f'::'i'::'v'::'e'::_ ->
        tryCastStringToInt ((Some 5)::output) (s |> List.skip 1)
    | 's'::'i'::'x'::_ ->
        tryCastStringToInt ((Some 6)::output) (s |> List.skip 1)
    | 's'::'e'::'v'::'e'::'n'::_ ->
        tryCastStringToInt ((Some 7)::output) (s |> List.skip 1)
    | 'e'::'i'::'g'::'h'::'t'::_ ->
        tryCastStringToInt ((Some 8)::output) (s |> List.skip 1)
    | 'n'::'i'::'n'::'e'::_ ->
        tryCastStringToInt ((Some 9)::output) (s |> List.skip 1)
    | c :: tail ->
        tryCastStringToInt ((Day1_1.tryCastCharToInt c)::output) tail
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