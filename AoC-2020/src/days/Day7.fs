module AoC2020.Day7

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

let parsedBagsToOuterMap (input: (string *((int*string) list option)) seq) : Map<string, Map<string, int> option> =
    input
    |> Seq.map (fun (k1, kvso) -> (k1, kvso
                                       |> Option.map (Seq.map (fun (v, k2) -> (k2, v)) >> Map.ofSeq)))
    |> Map.ofSeq

let parsedBagsToInnerMap (input:Map<string, Map<string,int> option>) : Map<string, string Set>=
    input
    |> Seq.map (fun (KeyValue(o, isO)) -> isO |> Option.map (Seq.map (fun (KeyValue(i, _)) -> (i, o))))
    |> Seq.choose id
    |> Seq.concat
    |> Seq.groupBy fst
    |> Seq.map (fun (s, tups) -> (s, tups |> Seq.map snd |> Set.ofSeq))
    |> Map.ofSeq

let deepSearchInner (innerBag:string) (innerBags:Map<string, string Set>) : string Set =
    let rec loop (bags:string Set) (acc:string Set) =
        let newBags =
            bags
            |> Seq.map (fun key -> innerBags |> Map.tryFind key)
            |> Seq.choose id
            |> Seq.concat
            |> Set.ofSeq
            |> (fun newBags -> acc |> Set.difference newBags)
        
        if newBags |> Set.isEmpty then
            acc
        else loop newBags (acc + newBags)
                   
    loop (set [innerBag]) Set.empty
    
let mergeBagMaps =
    Seq.concat
    >> Seq.groupBy (fun (KeyValue(k, v)) -> k)
    >> Seq.map (fun (key, values) -> (key, values
                                           |> Seq.map (fun (KeyValue(_, values)) -> values)
                                           |> (Seq.fold (+) 0)))
    >> Map.ofSeq
    
let deepSearchOuter (outerBag:string) (outerBags:Map<string, Map<string, int>>) : Map<string, int> =
    let rec loop (bags:Map<string,int>) (acc:Map<string, int>) =
        let newBags =
            bags
            // get next bags
            |> Map.map (fun key mul -> mul, outerBags |> Map.tryFind key)
            // mulitply number of bags needed with count from outer bag
            |> Map.map (fun _ (mul, maps) -> maps |> Option.map (Map.map (fun _ v2 -> mul * v2 )))
            |> Map.chooseValues id
            |> Map.toSeq
            // drop outer bag names
            |> Seq.map snd
            // merge inner bags
            |> mergeBagMaps
        
        if newBags |> Map.isEmpty then
            acc
        else loop newBags (mergeBagMaps [acc; newBags])
                   
    loop (Map [(outerBag, 1)]) Map.empty
    
let puzzle1 (innerBag:string) (rules:string seq) : int =
    rules
    |> Seq.map parseRule
    // create outer bags map
    |> parsedBagsToOuterMap
    // creat inner bags map
    |> parsedBagsToInnerMap
    // search all bags that can contain our bag
    |> deepSearchInner innerBag
    |> Set.count
    
let puzzle2 (innerBag:string) (rules:string seq) : int =
    rules
    |> Seq.map parseRule
    // create outer bags map
    |> parsedBagsToOuterMap
    |> Map.chooseValues id
    // search all bags that can contain our bag
    |> deepSearchOuter innerBag
    //|> Map.map (fun k v -> printfn "%A: %A" k v; v)
    |> Map.fold (fun s _ i -> s + i) 0