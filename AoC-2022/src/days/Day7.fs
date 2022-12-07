module AoC2022.Day7

open FParsec

type CmdCd =
| CdIn of string
| CdOut
| CdRoot

type Command =
| Cd of CmdCd
| Ls

type File = {
    Name : string
    Size : int
}

type FsInfo =
| File of File
| Dir of string

type TerminalOutput =
| Command of Command
| FsInfo of FsInfo

let parseFileName = manyChars (letter <|> digit <|> pchar '.')

let parseFile : Parser<File, unit> =
    pint32 .>> skipChar ' ' .>>. parseFileName
    |>> (fun (size, name) -> { Name = name; Size = size})

let parseFsInfo : Parser<FsInfo, unit> =
    choice [
        skipString "dir " >>. parseFileName |>> Dir
        parseFile |>> File
    ]

let parseCmd : Parser<Command, unit> =
    skipString "$ " >>. choice [
        stringReturn "ls" Ls
        stringReturn "cd /" (Cd CdRoot)
        stringReturn "cd .." (Cd CdOut)
        skipString "cd " >>. parseFileName |>> (CdIn >> Cd)
    ]

let parseTerminalOutput =
    choice [
        parseCmd |>> Command
        parseFsInfo |>> FsInfo
    ] |> sepBy <| pchar '\n'

let puzzle1 =
    run parseTerminalOutput
    >> function
    | Success (result, _, _) -> result
    | Failure (msg, _, _) ->
        printfn "%s" msg
        []