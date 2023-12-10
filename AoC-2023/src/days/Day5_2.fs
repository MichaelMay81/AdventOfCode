module AoC2023.Day5_2

open FSharpPlus
open Day5_1

let rec private generateSeeds (output:int64 seq) (input:int64 list) =
    match input with
    | start::length::tail ->
        let newSeeds = seq { start .. (start+length-1L) }
        generateSeeds (Seq.append output newSeeds) tail
    | _ -> output

let puzzle (input : string seq) =
    input
    |> Seq.toList
    |> List.filter (System.String.IsNullOrEmpty >> not)
    |> parse
    |> (fun almanac ->
        almanac.Seeds
        |> generateSeeds []
        // |> Seq.length)
        |> Seq.map (fun seed ->
            seed
            |> analyse almanac.SeedToSoil
            |> analyse almanac.SoilToFertilizer
            |> analyse almanac.FertilizerToWater
            |> analyse almanac.WaterToLight
            |> analyse almanac.LightToTemperature
            |> analyse almanac.TemperatureToHumidity
            |> analyse almanac.HumidityToLocation))
    |> Seq.min