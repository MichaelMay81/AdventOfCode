module AoC2022.Day7

open FParsec
open AoC2022.Day7_Parsing

type FsState = {
    Directories : Map<string, int>
    Cwd : string list
} with static member Empty = {
        Directories = Map.empty
        Cwd = ["/"]}

let toPath (cwd:string seq) =
    cwd
    |> Seq.rev
    |> Seq.skip 1
    |> String.concat "/"
    |> (+) "/"

let toAllPaths (cwd:string list) =
    let rec toAllPaths (cwd:string list) (out:string list) =
        match cwd with
        | [] ->
            out
        | _::tail ->
            toAllPaths tail ((toPath cwd) :: out)
    toAllPaths cwd []

let updateFsState (state:FsState) (input:TerminalOutput) : FsState=
    match input with
    | Command (Cd (CdIn subPath)) ->
        { state with Cwd=subPath::state.Cwd }
    | Command (Cd CdOut) ->
        { state with Cwd=state.Cwd.Tail }
    | Command (Cd CdRoot) ->
        { state with Cwd=["/"]}
    | FsInfo (File {Name=_; Size=size}) ->
        let newDirs =
            state.Cwd
            |> toAllPaths
            |> Seq.fold (fun dirs path ->
                let value =
                    dirs
                    |> Map.tryFind path
                    |> Option.defaultValue 0
                
                dirs
                |> Map.add path (value+size)) state.Directories
        { state with Directories = newDirs }
    | _ ->
        state

let puzzle1 =
    run parseTerminalOutput
    >> function
    | Success (result, _, _) ->
        (result
        |> Seq.fold updateFsState FsState.Empty)
            .Directories
            |> Map.values
            |> Seq.filter ((>) 100000)
            |> Seq.sum
         
    | Failure (msg, _, _) ->
        printfn "%s" msg
        -1

let puzzle2 =
    run parseTerminalOutput
    >> function
    | Success (result, _, _) ->
        let dirs =
            (result
            |> Seq.fold updateFsState FsState.Empty)
                .Directories

        let needed = 30000000 - (70000000 - dirs.["/"])
        
        dirs
        |> Map.values
        |> Seq.filter ((<) needed)
        |> Seq.min
         
    | Failure (msg, _, _) ->
        printfn "%s" msg
        -1