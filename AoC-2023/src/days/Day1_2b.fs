module AoC2023.Day1_2b

let rec private tryCastStringToInt (output:int option list) (s:char list) =
    // one - eight
    // two - one
    // three - eight
    // four
    // five - eight
    // six
    // seven - nine
    // eight - two, three
    // nine - eight

    match s with
    | 'o'::'n'::'e'::_ ->
        tryCastStringToInt ((Some 1)::output) (s |> List.skip 2)
    | 't'::'w'::'o'::_ ->
        tryCastStringToInt ((Some 2)::output) (s |> List.skip 2)
    | 't'::'h'::'r'::'e'::'e'::_ ->
        tryCastStringToInt ((Some 3)::output) (s |> List.skip 4)
    | 'f'::'o'::'u'::'r'::tail ->
        tryCastStringToInt ((Some 4)::output) tail
    | 'f'::'i'::'v'::'e'::_ ->
        tryCastStringToInt ((Some 5)::output) (s |> List.skip 3)
    | 's'::'i'::'x'::tail ->
        tryCastStringToInt ((Some 6)::output) tail
    | 's'::'e'::'v'::'e'::'n'::_ ->
        tryCastStringToInt ((Some 7)::output) (s |> List.skip 4)
    | 'e'::'i'::'g'::'h'::'t'::_ ->
        tryCastStringToInt ((Some 8)::output) (s |> List.skip 4)
    | 'n'::'i'::'n'::'e'::_ ->
        tryCastStringToInt ((Some 9)::output) (s |> List.skip 3)
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