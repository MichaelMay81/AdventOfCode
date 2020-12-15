module AoC_Mike.Day13

open Microsoft.VisualBasic.CompilerServices

let puzzle1 (input:string seq) : int =
    let leaveTime = input |> Seq.head |> int
    let foobar = 
        input
        |> Seq.skip 1
        |> Seq.map (fun str -> str.Split ",")
        |> Seq.concat
        |> Seq.filter ((<>) "x")
        |> Seq.map int
        |> Seq.map (fun x -> x, x - (leaveTime % x))
        |> Seq.toList
        
    foobar
    |> Seq.fold (fun state value -> if (snd state) < (snd value) then state else value) (-1, System.Int32.MaxValue)
    |> (fun tup -> fst tup * snd tup)