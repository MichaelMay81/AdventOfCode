module AoC2021.Day2

type Commands =
    | Forward of int
    | Down of int
    | Up of int

let parseCmd (cmdString:string) =
    cmdString.Split ' ' |> function
    | [|cmd; x|] ->
        match cmd with
        | "forward" -> Some (Forward (int x))
        | "down" -> Some (Down (int x))
        | "up" -> Some (Up (int x))
        | _ -> None
    | _ -> None

let parseCmds cmds =
    cmds
    |> Seq.map parseCmd
    |> Seq.choose id