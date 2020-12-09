module AoC_Mike.Day8_2

open System.Runtime.CompilerServices
open FSharpPlus
open Helpers
open Day8_1

let fixIt (instruction:Instruction list) : Result<Program, Program*string> =
    let setup instrStart instrRest instr =
        let foobar = List.append (instrStart |> List.rev) (instr :: instrRest)
//        printfn "%A %A %A %A" instrStart instr instrRest foobar
        foobar
        
    let rec loop instrStart instrRest =
        match instrRest with
        | [] -> instrStart |> execProgram
        | head :: instrRest ->
            match head with
            | Jmp a -> setup instrStart instrRest (Nop a) |> execProgram
            | Nop a -> setup instrStart instrRest (Jmp a) |> execProgram
            | Acc a -> Error (newProgram instruction, "")
            |> function
               | Ok prog -> Ok prog
               | Error _ -> loop (head :: instrStart) instrRest
               
    loop [] instruction

let puzzle (input:string seq): Result<int, int> =
    input
    |> Seq.map (parseInstruction >> Option.ofResult)
    |> Seq.choose id
    |> Seq.toList
    |> fixIt
    |> function
       | Ok value -> Ok value.Accumulator
       | Error (value, _) -> Error value.Accumulator