module AoC2021.Day2_2

open Day2

type Position = {
    HorizontalPosition: int
    Depth: int
    Aim: int
}

let initPos = {
    HorizontalPosition = 0
    Depth = 0
    Aim = 0
}

let processCmd pos = function
    | Down x -> { pos with Aim = pos.Aim + x }
    | Up x -> { pos with Aim = pos.Aim - x }
    | Forward x -> {
        pos with
            HorizontalPosition = pos.HorizontalPosition + x
            Depth = pos.Depth + (pos.Aim * x)
    }
    
let puzzle cmds =
    let {HorizontalPosition = hp; Depth = depth} =
        Seq.fold processCmd initPos cmds
    hp * depth