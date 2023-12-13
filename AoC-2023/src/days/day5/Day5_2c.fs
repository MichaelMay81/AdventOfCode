module AoC2023.Day5_2c

open FSharpPlus
open Day5_1
open Day5_1b
open Day5_2b
open Helpers

let rec seedRangesConsists (seedRange:SeedRange list) (value:int64) =
    match seedRange with
    | [] -> false
    | seedRange::tail ->
        match value >=< (seedRange.Start, seedRange.Start + seedRange.Length - 1L) with
        | true -> true
        | false -> seedRangesConsists tail value

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

    let seedRanges =
        almanac.Seeds
        |> generateSeedRanges []
        |> Seq.toList

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
            seedRangesConsists seedRanges seed
        loc, seed, exists)
    |> Seq.find (fun (_, _, exists) -> exists)