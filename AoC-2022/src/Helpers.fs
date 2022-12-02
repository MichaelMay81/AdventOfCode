module AoC2022.Helpers

open System.IO

let readAllText filePath : string =
    Path.Combine(__SOURCE_DIRECTORY__, filePath)
    |> File.ReadAllText