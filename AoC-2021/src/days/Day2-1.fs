module AoC2021.Day2_1

open Day2

type Position = {
    HorizontalPosition: int
    Depth: int
}

let initPos = {
    HorizontalPosition = 0
    Depth = 0
}

let processCmd pos = function
    | Forward x -> { pos with HorizontalPosition = pos.HorizontalPosition + x }
    | Down x -> { pos with Depth = pos.Depth + x }
    | Up x -> { pos with Depth = pos.Depth - x }

let puzzle cmds =
    let {HorizontalPosition = hp; Depth = depth } =
        Seq.fold processCmd initPos cmds
    hp * depth