module AoC_Mike.Day8_2

open System.Runtime.CompilerServices
open FSharpPlus
open Helpers

type Instruction =
    | Acc of int
    | Jmp of int
    | Nop
    
type InstrutionType =
    | AccT
    | JmpT
    | NopT
    
type Program = {
    Instructions : Instruction list
    Instr_pointer : int
    Instr_counter : int Set
    Accumulator : int
}

let newProgram (instructions : Instruction list)= {
    Instructions = instructions
    Instr_pointer = 0
    Instr_counter = Set.empty
    Accumulator = 0
}

let getInstructionType = function
    | Acc _ -> AccT
    | Jmp _ -> JmpT
    | Nop -> NopT

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

let execProgram (instruction:Instruction list) : Result<Program, (string*Program)> =
    let rec loop (program: Program) : Result<Program, (string*Program)> =
        if program.Instr_pointer - 1 = (program.Instructions |> List.length) then
            Ok program
        elif program.Instr_pointer < 0 then
            Error ("Instruction pointer can't be below Zero!", program)
        elif program.Instr_pointer > (program.Instructions |> List.length) then
            Error ("Instruction pointer can't be higher then size of Instructions!", program)
        elif program.Instr_counter |> Set.contains program.Instr_pointer then
            Error ("Infinite Loop detected!" , program)
        else
            let program = { program with Instr_counter = program.Instr_counter.Add program.Instr_pointer }
            match program.Instructions.[program.Instr_pointer] with
            | Acc value -> loop { program with
                                    Accumulator = program.Accumulator + value
                                    Instr_pointer = program.Instr_pointer + 1 }
            | Jmp value -> loop { program with Instr_pointer = program.Instr_pointer + value }
            | Nop -> loop { program with Instr_pointer = program.Instr_pointer + 1 }
    
    loop (newProgram instruction)

let puzzle (input:string seq) : Result<int, (string*Program)> =
     let instructions =
        input
        |> Seq.map (parseInstruction >> Option.ofResult)
        |> Seq.choose id
        |> Seq.toList
        
     let counts = instructions |> List.map getInstructionType |> List.countBy id
     let numOf
     printfn "%A" instructions
     
     //|> execProgram
     //|> Result.map (fun p -> p.Accumulator)
     Ok 0