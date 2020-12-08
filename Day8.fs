module AoC_Mike.Day8

open FSharpPlus
open Helpers

type Instruction =
    | Acc of int
    | Jmp of int
    | Nop
    
type Program = {
    Instructions : Instruction list
    Instr_pointer : int
    Instr_counter : int Set
    Accumulator : int
    Error : string
}

let newProgram (instructions : Instruction list)= {
    Instructions = instructions
    Instr_pointer = 0
    Instr_counter = Set.empty
    Accumulator = 0
    Error = ""
}

let parseInstruction (cmd:string) : Result<Instruction, string> =
    cmd
    |> (trySscanf "%s %i")
    |> function
        | Some (op, ar) ->
            match op with
            | "acc" -> Ok (Acc ar)
            | "jmp" -> Ok (Jmp ar)
            | "nop" -> Ok Nop
            | _ -> Error (sprintf "unknown operator: %s" op)
        | None -> Error (sprintf "unknown instruction: %s" cmd)

let execProgram (instruction:Instruction list) : Program =
    let rec loop (program: Program) : Program =
        if program.Instr_pointer < 0 then
            { program with Error = "Instruction pointer can't be below Zero!" }
        elif program.Instr_pointer > (program.Instructions |> List.length) then
            { program with Error = "Instruction pointer can't be higher then size of Instructions!" }
        elif program.Instr_counter |> Set.contains program.Instr_pointer then
            { program with Error = "Infinite Loop detected!" }
        else
            let program = { program with Instr_counter = program.Instr_counter.Add program.Instr_pointer }
            match program.Instructions.[program.Instr_pointer] with
            | Acc value -> loop { program with
                                    Accumulator = program.Accumulator + value
                                    Instr_pointer = program.Instr_pointer + 1 }
            | Jmp value -> loop { program with Instr_pointer = program.Instr_pointer + value }
            | Nop -> loop { program with Instr_pointer = program.Instr_pointer + 1 }
    loop (newProgram instruction)

let puzzle1 (input:string seq): int =
    (input
     |> Seq.map (parseInstruction >> Option.ofResult)
     |> Seq.choose id
     |> Seq.toList
     |> execProgram).Accumulator