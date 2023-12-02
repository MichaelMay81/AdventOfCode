module AoC2023.Day2_2

open Day2_1

type CubeCounts = {
    RedCount : int
    GreenCount : int
    BlueCount : int
}

let private findLowest (cubeCounts : CubeCount list list) =
    let rec recFun (cubeCounts : CubeCount list) (counts:CubeCounts) =
        match cubeCounts with
        | [] -> counts
        | head::tail ->
            match head with
            | { Count=count; Color=Red } ->
                match count > counts.RedCount with
                | true -> { counts with RedCount = count }
                | false -> counts
            | { Count=count; Color=Green } ->
                match count > counts.GreenCount with
                | true -> { counts with GreenCount = count }
                | false -> counts
            | { Count=count; Color=Blue } ->
                match count > counts.BlueCount with
                | true -> { counts with BlueCount = count }
                | false -> counts
            |> recFun tail

    cubeCounts
    |> Seq.fold
        (fun state cubeCounts -> recFun cubeCounts state)
        { RedCount = 0; GreenCount = 0; BlueCount = 0 }

let puzzle (games:Game seq) =
    games
    |> Seq.map (fun { GameId=gameId; Subsets=subsets } ->
        gameId,
        subsets |> findLowest)
    |> Seq.map (fun (_, counts) ->
        counts.RedCount * counts.GreenCount * counts.BlueCount)
    |> Seq.sum
    