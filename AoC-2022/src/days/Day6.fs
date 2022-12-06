module AoC2022.Day6

let rec findFirstUnique (nouc:int) (count:int) (buffer:char list) (datastream:char list) : Result<int, string> =
    match datastream, buffer |> Seq.length with
    | _, bufferSize when bufferSize = nouc -> Ok count
    | [], _ ->
        Error "Not enough chars in buffer"
    | head::tail, bufferSize ->
        buffer
        |> List.tryFindIndex ((=) head)
        |> Option.map ((-) bufferSize)
        |> function
        | None ->
            findFirstUnique nouc (count+1) (head::buffer) tail
        | Some pos ->
            findFirstUnique
                nouc
                (count + 1)
                (buffer |> List.rev |> List.skip pos |> List.rev |> List.append [head])
                tail

let puzzle1 : string -> Result<int, string> =
    Seq.toList
    >> findFirstUnique 4 0 []

let puzzle2 : string -> Result<int, string> =
    Seq.toList
    >> findFirstUnique 14 0 []