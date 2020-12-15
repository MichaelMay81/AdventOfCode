module AoC_Mike.Day15

type State = {
    Turn : int
    Numbers : Map<int, int>
    LastNumber : int
}

let nextTurn (state:State) : State =
    match state.Numbers |> Map.tryFind state.LastNumber with
    | None -> { state with
                 Turn = state.Turn + 1
                 Numbers = state.Numbers |> Map.add state.LastNumber state.Turn
                 LastNumber = 0 }
    | Some lastTurn -> { state with
                          Turn = state.Turn + 1
                          Numbers = state.Numbers |> Map.add state.LastNumber state.Turn
                          LastNumber = state.Turn - lastTurn }
    
let puzzle1 (maxTurns:int) (input:int seq) : int =
    let rec loop state =
        if state.Turn = maxTurns
        then state
        else nextTurn state |> loop
        
    (loop {
        Turn = input |> Seq.length
        Numbers = input |> Seq.rev |> Seq.skip 1 |> Seq.rev |> Seq.mapi (fun i v -> v, (i+1)) |> Map.ofSeq
        LastNumber = input |> Seq.rev |> Seq.head
    }).LastNumber