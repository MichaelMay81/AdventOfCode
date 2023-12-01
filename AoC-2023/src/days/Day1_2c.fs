module AoC2023.Day1_2c

let rec private FindFirst (s:char list) =
    match s with
    | 'o'::'n'::'e'::_ -> Some 1
    | 't'::'w'::'o'::_ -> Some 2
    | 't'::'h'::'r'::'e'::'e'::_ -> Some 3
    | 'f'::'o'::'u'::'r'::_ -> Some 4
    | 'f'::'i'::'v'::'e'::_ -> Some 5
    | 's'::'i'::'x'::_ -> Some 6
    | 's'::'e'::'v'::'e'::'n'::_ -> Some 7
    | 'e'::'i'::'g'::'h'::'t'::_ -> Some 8
    | 'n'::'i'::'n'::'e'::_ -> Some 9
    | c :: tail ->
        match Day1_1.tryCastCharToInt c with
        | Some i -> Some i
        | None -> FindFirst tail
    | [] -> None

let rec private FindLast (s:char list) =
    match s with
    | 'e'::'n'::'o'::_ -> Some 1
    | 'o'::'w'::'t'::_ -> Some 2
    | 'e'::'e'::'r'::'h'::'t'::_ -> Some 3
    | 'r'::'u'::'o'::'f'::_ -> Some 4
    | 'e'::'v'::'i'::'f'::_ -> Some 5
    | 'x'::'i'::'s'::_ -> Some 6
    | 'n'::'e'::'v'::'e'::'s'::_ -> Some 7
    | 't'::'h'::'g'::'i'::'e'::_ -> Some 8
    | 'e'::'n'::'i'::'n'::_ -> Some 9
    | c :: tail ->
        match Day1_1.tryCastCharToInt c with
        | Some i -> Some i
        | None -> FindLast tail
    | [] -> None

let puzzle2 (input : string seq) =
    input
    |> Seq.map Seq.toList
    |> Seq.map (fun chars ->
        FindFirst chars |> Option.defaultValue -1,
        FindLast (chars |> List.rev) |> Option.defaultValue -2)
    |> Seq.map (fun (decade, unit) ->
        decade * 10 + unit)
    |> Seq.sum