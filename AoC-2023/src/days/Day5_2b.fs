module AoC2023.Day5_2b

open FSharpPlus
open Day5_1

type SeedRange = {
    Start : int64
    Length : int64 }

let private seedRangeToSeeds (seedRange:SeedRange) =
    seq { seedRange.Start .. (seedRange.Start+seedRange.Length-1L) }

let rec generateSeedRanges (output:SeedRange seq) (input:int64 list) =
    match input with
    | start::length::tail ->
        let newSeedRange = { Start=start; Length=length }
        generateSeedRanges (Seq.append output (Seq.singleton newSeedRange)) tail
    | _ -> output

let puzzle (input : string seq) =
    input
    |> Seq.toList
    |> List.filter (System.String.IsNullOrEmpty >> not)
    |> parse
    |> (fun almanac ->
        almanac.Seeds
        |> generateSeedRanges []
        |> Seq.toArray
        |> Array.Parallel.map (
            seedRangeToSeeds
            >> Seq.map (
                analyse almanac.SeedToSoil
                >> analyse almanac.SoilToFertilizer
                >> analyse almanac.FertilizerToWater
                >> analyse almanac.WaterToLight
                >> analyse almanac.LightToTemperature
                >> analyse almanac.TemperatureToHumidity
                >> analyse almanac.HumidityToLocation)
            >> Seq.min))
    |> Seq.min