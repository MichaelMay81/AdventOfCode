module AoC_Mike.Day4

open FSharpPlus
open FSharpPlus.Data

type PassportFieldTypes =
    | BirthYear
    | IssueYear
    | ExpirationYear
    | Height
    | HairColor
    | EyeColor
    | PassportID
    | CountryID

let splitIntoPassportStringLists input =
    let emptyIds = input
                   |> Seq.mapi (fun i line -> (i, line))
                   |> Seq.filter (snd >> ((=) ""))
                   |> Seq.map fst
    
    (Seq.append [-1] <| Seq.append emptyIds [Seq.length input])
    |> Seq.pairwise
    |> Seq.map (fun (id1, id2) -> (id1+1, id2-id1-1))
    |> Seq.map (fun (sSteps, tSteps) -> input |> Seq.skip sSteps |> Seq.take tSteps)

let splitIntoPassportTuples =
    String.split [" "]
    >> Seq.map (sscanf "%s:%s")

let parseFieldTuple = function
    | "byr", _ -> Ok BirthYear
    | "iyr", _ -> Ok IssueYear
    | "eyr", _ -> Ok ExpirationYear
    | "hgt", _ -> Ok Height
    | "hcl", _ -> Ok HairColor
    | "ecl", _ -> Ok EyeColor
    | "pid", _ -> Ok PassportID
    | "cid", _ -> Ok CountryID
    | field, _ -> Error (sprintf "Cannot parse field '%s'" field)

let stringFieldListsToPassportFieldList : string seq -> PassportFieldTypes seq =
    Seq.map splitIntoPassportTuples
    >> Seq.concat
    >> Seq.map (parseFieldTuple >> Option.ofResult)
    >> Seq.choose id

// at least North Pole Passport
let isValid (input: PassportFieldTypes seq) : bool =
    [BirthYear; IssueYear; ExpirationYear; Height; HairColor; EyeColor; PassportID]
    |> Seq.map (fun field -> input |> Seq.contains field)
    |> Seq.fold (&&) true 
//    input |> Seq.contains BirthYear &&
//    input |> Seq.contains IssueYear &&
//    input |> Seq.contains ExpirationYear &&
//    input |> Seq.contains Height &&
//    input |> Seq.contains HairColor &&
//    input |> Seq.contains EyeColor &&
//    input |> Seq.contains PassportID
    
let puzzle1 (input: string seq) =
    splitIntoPassportStringLists input
    |> (Seq.map <| stringFieldListsToPassportFieldList)
    |> Seq.map isValid
    |> Seq.filter id
    |> Seq.length