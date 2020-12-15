module AoC2020.Day8_1

open FSharpPlus
open Helpers

type Instruction =
    | Acc of int
    | Jmp of int
    | Nop of int
    
type Program = {
    Instructions : Instruction list
    InstrPointer : int
    InstrCounter : int Set
    Accumulator : int
}

let newProgram (instructions : Instruction list)= {
    Instructions = instructions
    InstrPointer = 0
    InstrCounter = Set.empty
    Accumulator = 0
}

let parseInstruction (cmd:string) : Result<Instruction, string> =
    cmd
    |> (trySscanf "%s %i")
    |> function
        | Some (op, ar) ->
            match op with
            | "acc" -> Ok (Acc ar)
            | "jmp" -> Ok (Jmp ar)
            | "nop" -> Ok (Nop ar)
            | _ -> Error (sprintf "unknown operator: %s" op)
        | None -> Error (sprintf "unknown instruction: %s" cmd)

let execProgram (instruction:Instruction list) : Result<Program, Program*string> =
    let rec loop (program: Program) : Result<Program, Program*string> =
        if program.InstrPointer = (program.Instructions |> List.length) then
            Ok program
        elif program.InstrPointer < 0 then
            Error (program, "Instruction pointer can't be below Zero!")
        elif program.InstrPointer > (program.Instructions |> List.length) then
            Error (program, "Instruction pointer can't be higher then size of Instructions!")
        elif program.InstrCounter |> Set.contains program.InstrPointer then
            Error (program, "Infinite Loop detected!")
        else
            let program = { program with InstrCounter = program.InstrCounter.Add program.InstrPointer }
            match program.Instructions.[program.InstrPointer] with
            | Acc value -> loop { program with
                                    Accumulator = program.Accumulator + value
                                    InstrPointer = program.InstrPointer + 1 }
            | Jmp value -> loop { program with InstrPointer = program.InstrPointer + value }
            | Nop _ -> loop { program with InstrPointer = program.InstrPointer + 1 }
    loop (newProgram instruction)

let puzzle (input:string seq): Result<int, int> =
    input
    |> Seq.map (parseInstruction >> Option.ofResult)
    |> Seq.choose id
    |> Seq.toList
    |> execProgram
    |> function
       | Ok value -> Ok value.Accumulator
       | Error (value, _) -> Error value.Accumulator