module AoC_Mike.Day6

open AoC_Mike.Day4_1

let puzzle1 (input:string seq) =
    input
    |> splitIntoPassportStringLists
    |> Seq.map (Seq.concat >> Seq.distinct)
    |> Seq.map Seq.length
    |> Seq.sum
    
let puzzle2 (input: string seq) =
    input
    |> splitIntoPassportStringLists
    |> Seq.map (Seq.map Set.ofSeq >> Set.intersectMany)
    |> Seq.map Seq.length
    |> Seq.sum