module AoC2023.Helpers

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

let zip4 source1 source2 source3 source4 =
        Seq.map2 (fun a (b, c, d) -> a, b, c, d) source1 (Seq.zip3 source2 source3 source4)

let inline (>=<) a (b,c) = b<=a && a<=c