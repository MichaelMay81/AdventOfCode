module AoC2023.Day5_1

open FSharpPlus
open Helpers

type Mapping = {
    DestinationRange : int64
    SourceRange : int64
    RangeLength : int64
}

type Almanac = {
    Seeds : int64 list
    SeedToSoil : Mapping list
    SoilToFertilizer : Mapping list
    FertilizerToWater : Mapping list
    WaterToLight : Mapping list
    LightToTemperature : Mapping list
    TemperatureToHumidity : Mapping list
    HumidityToLocation : Mapping list
} with static member Empty = {
        Seeds = []
        SeedToSoil = []
        SoilToFertilizer = []
        FertilizerToWater = []
        WaterToLight = []
        LightToTemperature  = []
        TemperatureToHumidity = []
        HumidityToLocation = []
    }

let rec private parseMappings (mappings:Mapping list) (input : string list) =
    match input with
    | head::tail ->
        head
        |> trySscanf "%i %i %i"
        |> function
        | Some (a, b, c) ->
            let mapping = {
                DestinationRange = a
                SourceRange = b
                RangeLength = c }
            parseMappings (mapping::mappings) tail
        | None ->
            mappings, input
    | _ ->
        mappings, input

let parse (input : string list) =
    let rec func (almanac:Almanac) (input:string list) =
        match input with
        | [] -> almanac
        | head::tail ->
            head
            |> trySscanf "seeds: %s"
            |> function
            | Some seeds ->
                let int64s =
                    seeds
                    |> String.split [" "]
                    |> Seq.map int64
                    |> Seq.toList
                func { almanac with Seeds = int64s} tail
            | None ->
                match head with
                | "seed-to-soil map:" ->
                    let mappings, rest = parseMappings [] tail
                    func { almanac with SeedToSoil = mappings} rest
                | "soil-to-fertilizer map:" ->
                    let mappings, rest = parseMappings [] tail
                    func { almanac with SoilToFertilizer = mappings} rest
                | "fertilizer-to-water map:" ->
                    let mappings, rest = parseMappings [] tail
                    func { almanac with FertilizerToWater = mappings} rest
                | "water-to-light map:" ->
                    let mappings, rest = parseMappings [] tail
                    func { almanac with WaterToLight = mappings} rest
                | "light-to-temperature map:" ->
                    let mappings, rest = parseMappings [] tail
                    func { almanac with LightToTemperature = mappings} rest
                | "temperature-to-humidity map:" ->
                    let mappings, rest = parseMappings [] tail
                    func { almanac with TemperatureToHumidity = mappings} rest
                | "humidity-to-location map:" ->
                    let mappings, rest = parseMappings [] tail
                    func { almanac with HumidityToLocation = mappings} rest
                | _ ->
                    almanac
    func Almanac.Empty input

let rec analyse (mappings : Mapping list) (value:int64) =
    match mappings with
    | [] -> value
    | head::tail ->
        let sourceStart = head.SourceRange
        let sourceEnd = head.SourceRange + head.RangeLength - 1L
        match value >=< (sourceStart,sourceEnd) with
        | false ->
            analyse tail value
        | true ->
            head.DestinationRange + (value - sourceStart)

let puzzle (input : string seq) =
    input
    |> Seq.toList
    |> List.filter (System.String.IsNullOrEmpty >> not)
    |> parse
    |> (fun almanac ->
        almanac.Seeds
        |> Seq.map (
            analyse almanac.SeedToSoil
            >> analyse almanac.SoilToFertilizer
            >> analyse almanac.FertilizerToWater
            >> analyse almanac.WaterToLight
            >> analyse almanac.LightToTemperature
            >> analyse almanac.TemperatureToHumidity
            >> analyse almanac.HumidityToLocation))
    |> Seq.min