module AoC_Mike.Day4_2

open System
open System.ComponentModel
open System.Reflection.Metadata
open FSharpPlus
open FSharpPlus.Data

type PassportFieldType =
    | BirthYearFT
    | IssueYearFT
    | ExpirationYearFT
    | HeightFT
    | HairColorFT
    | EyeColorFT
    | PassportIdFT
    | CountryIdFT

type Height =
    | Centimeter of int
    | Inch of int

type EyeColor =
    | Amber
    | Blue
    | Brown
    | Grey
    | Green
    | Hazel
    | Other
    
type PassportField =
    | BirthYear of int
    | IssueYear of int
    | ExpirationYear of int
    | Height of Height
    | HairColor of string
    | EyeColor of EyeColor
    | PassportID of string
    | CountryID of string

let getFieldType = function
    | BirthYear _ -> BirthYearFT
    | IssueYear _ -> IssueYearFT
    | ExpirationYear _ -> ExpirationYearFT
    | Height _ -> HeightFT
    | HairColor _ -> HairColorFT
    | EyeColor _ -> EyeColorFT
    | PassportID _ -> PassportIdFT
    | CountryID _ -> CountryIdFT

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

let parseYear (minYear:int) (maxYear:int) (str:string) : Result<int, string> =
    if str |> String.length <> 4 then
        Error (sprintf "'%s' is not of length 4" str)
    else
        trySscanf "%i" str
        |> Option.filter (fun y -> y >= minYear && y <= maxYear)
        |> Option.toResultWith (sprintf "%s is smaller than %i or bigger than %i" str minYear maxYear)

let parseHeight str =
    match trySscanf "%icm" str with
    | Some height ->
        if height < 150 || height > 193 then
            Error (sprintf "'%s' is smaller than 150 or larger than 193" str)
        else Ok (Centimeter height)
    | None ->
        match trySscanf "%iin" str with
        | Some height ->
            if height < 59 || height > 76 then
                Error (sprintf "'%s' is smaller than 59 or larger than 76" str)
            else Ok (Inch height)
        | None -> Error (sprintf "%s has no in/cm at the end" str)
        
let parseHairColor str : Result<string, string> =
    str
    |> String.tryHead
    |> Option.bind ((=) '#' >> function true -> Some '#' | false -> None)
    |> Option.toResultWith (sprintf "%s should start with a #" str)
    |> Result.bind (fun _ -> 
        str
        |> String.skip 1
        |> String.forall (fun v -> "123456789abcdef" |> String.toList |> List.contains v)
        |> function
            | true -> Ok str
            | false -> Error (sprintf "%s is not a hex value" str))

let parseEyeColor str : Result<EyeColor, string> =
    match str with
    | "amb" -> Ok Amber
    | "blu" -> Ok Blue
    | "brn" -> Ok Brown
    | "gry" -> Ok Grey
    | "grn" -> Ok Green
    | "hzl" -> Ok Hazel
    | "oth" -> Ok Other
    | _ -> Error (sprintf "%s is an unknown eye color type" str)
            
let parsePassportId str : Result<string, string> =
    if str |> String.length <> 9 then
        Error (sprintf "'%s' is not of length 9" str)
    elif ((str |> trySscanf "%i") = None) then
        Error (sprintf "'%s' is not a number" str )
    else Ok str
         

let parseFieldTuple = function
    | "byr", v -> v |> parseYear 1920 2002 |> Result.map BirthYear
    | "iyr", v -> v |> parseYear 2010 2020 |> Result.map IssueYear
    | "eyr", v -> v |> parseYear 2020 2030 |> Result.map  ExpirationYear
    | "hgt", v -> v |> parseHeight |> Result.map Height
    | "hcl", v -> v |> parseHairColor |> Result.map HairColor
    | "ecl", v -> v |> parseEyeColor |> Result.map EyeColor
    | "pid", v -> v |> parsePassportId |> Result.map PassportID
    | "cid", v -> Ok (CountryID v)
    | field, _ -> Error (sprintf "Cannot parse field '%s'" field)

let stringFieldListsToPassportFieldList : string seq -> PassportField seq =
    Seq.map splitIntoPassportTuples
    >> Seq.concat
    >> Seq.map (parseFieldTuple >> Option.ofResult)
    >> Seq.choose id

// at least North Pole Passport
let isValid (input: PassportField seq) : bool =
    [BirthYearFT; IssueYearFT; ExpirationYearFT; HeightFT; HairColorFT; EyeColorFT; PassportIdFT]
    |> Seq.map (fun field -> input |> Seq.map getFieldType |> Seq.contains field)
    |> Seq.fold (&&) true 
//    input |> Seq.contains BirthYear &&
//    input |> Seq.contains IssueYear &&
//    input |> Seq.contains ExpirationYear &&
//    input |> Seq.contains Height &&
//    input |> Seq.contains HairColor &&
//    input |> Seq.contains EyeColor &&
//    input |> Seq.contains PassportID
    
let puzzle (input: string seq) =
//    let foobar = splitIntoPassportStringLists input
//                    |> (Seq.map <| stringFieldListsToPassportFieldList)
//                    |> Seq.map (fun v -> not (isValid v), v)
//                    |> Seq.filter (fun (b, _) -> b)
//    for fb in foobar do
//        printfn "%A" fb
//    
//    
    splitIntoPassportStringLists input
    |> (Seq.map <| stringFieldListsToPassportFieldList)
    |> Seq.map isValid
    |> Seq.filter id
    |> Seq.length