module AoC2020.Day6

open AoC2020.Day4_1

let puzzle1 (input:string seq) =
    input
    |> splitIntoPassportStringLists
    |> Seq.sumBy (Seq.concat >> Seq.distinct >> Seq.length)
    
let puzzle2 (input: string seq) =
    input
    |> splitIntoPassportStringLists
    |> Seq.sumBy (Seq.map Set.ofSeq >> Set.intersectMany >> Seq.length)