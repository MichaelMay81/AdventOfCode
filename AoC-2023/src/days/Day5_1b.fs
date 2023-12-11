module AoC2023.Day5_1b

open FSharpPlus
open Day5_1
open Helpers

let rec generateLocations (dests:int64 seq) (mappings:Mapping list) =
    match mappings with
    | [] -> dests
    | head :: rest ->
        let newDests = seq { head.DestinationRange .. (head.DestinationRange + head.RangeLength - 1L) }
        generateLocations (Seq.append newDests dests) rest

let rec revAnalyse (mappings : Mapping list) (value:int64) =
    match mappings with
    | [] ->
        value
    | head::tail ->
        let destStart = head.DestinationRange
        let destEnd = head.DestinationRange + head.RangeLength - 1L
        match value >=< (destStart,destEnd) with
        | false ->
            revAnalyse tail value
        | true ->
            let result = head.SourceRange + (value - destStart)
            result

let puzzle (input : string seq) =
    let almanac =
        input
        |> Seq.toList
        |> List.filter (System.String.IsNullOrEmpty >> not)
        |> parse

    let highestLocation =
        almanac.HumidityToLocation
        |> Seq.map (fun mapping -> mapping.DestinationRange + mapping.RangeLength - 1L)
        |> Seq.max

    let locations = seq { 0L .. highestLocation }
    
    locations
    |> Seq.map (fun loc ->
        let seed =
            loc
            |> revAnalyse almanac.HumidityToLocation
            |> revAnalyse almanac.TemperatureToHumidity
            |> revAnalyse almanac.LightToTemperature
            |> revAnalyse almanac.WaterToLight
            |> revAnalyse almanac.FertilizerToWater
            |> revAnalyse almanac.SoilToFertilizer
            |> revAnalyse almanac.SeedToSoil
        let exists =
            List.contains seed almanac.Seeds
        loc, seed, exists)
    |> Seq.find (fun (_, _, exists) -> exists)
    |> fun (loc, _, _) -> loc