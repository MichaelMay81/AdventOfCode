module AoC_Mike.Day7

open FSharpPlus

let parseInnerBag = trySscanf "%i %s bag%s" >> Option.map (fun (v1, v2, _) -> (v1, v2)) 
let parseInnerBags = function
    | "no other bags." -> None
    | str -> str
             |> String.split [", "]
             |> Seq.map parseInnerBag
             |> Seq.choose id
             |> Some
let parseRule str =
    let (outerColor, innerString) = str |> sscanf "%s bags contain %s"
    let innerBags = innerString |> parseInnerBags |> Option.map Seq.toList
    (outerColor, innerBags)

let parseBagsToMap (input:Map<string, ((int*string) list option)>) : Map<string, string list>=
    input
    |> Seq.map (fun (KeyValue(o, isO)) -> isO |> Option.map (Seq.map (fun (_, i) -> (i, o))))
    |> Seq.choose id
    |> Seq.concat
    |> Seq.groupBy fst
    |> Seq.map (fun (s, tups) -> (s, tups |> Seq.map snd |> Seq.toList))
    |> Map.ofSeq

let deepSearchInner (innerBag:string) (innerBags:Map<string, string list>) : string list =
    let rec loop (bags:string list) (acc:string list) =
        let newBags =
            bags
            |> Seq.map (fun key -> innerBags |> Map.tryFind key)
            |> Seq.choose id
            |> Seq.concat
            |> Seq.distinct
            |> Seq.filter (fun value -> acc |> Seq.contains value |> not)
            |> Seq.toList
        
        if newBags |> List.isEmpty then
            acc
        else loop newBags (acc @ newBags)
                   
    loop [innerBag] []
    
let puzzle1 (innerBag:string) (rules:string seq) : int =
    rules
    // create outer bags map
    |> Seq.map parseRule
    |> Map.ofSeq
    // creat inner bags map
    |> parseBagsToMap
    // search all bags that can contain our bag
    |> deepSearchInner innerBag
    |> List.length