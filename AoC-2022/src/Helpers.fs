module AoC2022.Helpers

open System.IO

let readAllText filePath : string =
    Path.Combine(__SOURCE_DIRECTORY__, filePath)
    |> File.ReadAllText

let readAllLines filePath : string array =
    Path.Combine(__SOURCE_DIRECTORY__, filePath)
    |> File.ReadAllLines

let flip f a b = f b a

// set theory: intersect
let intersect a b =
    a |> Seq.filter (flip Seq.contains b)