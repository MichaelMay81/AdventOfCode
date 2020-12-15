module AoC_Mike.Day12_1

open System
open System.Reflection.Metadata
open FSharpPlus.Control

type Orientation =
    | North
    | South
    | East
    | West
type Direction =
    | Left
    | Right
type Steps = int
type Degrees = int

type Move =
    | Orientation of Orientation*Steps
    | Forward of Steps
type NavInstruction =
    | Move of Move
    | Turn of Direction * Degrees
    
type State = {
    LookAt : Orientation
    Long : int // vertical
    Lat : int // horizontal
}

let initState = {
    LookAt = East
    Long = 0
    Lat = 0
}

let turnRight (lookAt:Orientation) (degrees:int) : Orientation =
    let lookAtToInt = function
        | North -> 0
        | East -> 90
        | South -> 180
        | West -> 270
    let intToLookAt =
        (fun v -> v % 360)
        >> function
           | 0 -> North
           | 90 | -270 -> East
           | 180 | -180 -> South
           | 270 | -90 -> West
           | _ -> failwith "this shouldn't happen"
            
    ((lookAt |> lookAtToInt) + degrees) |> intToLookAt
    
let move (state:State) (orientation:Orientation) (steps:int) : State =
    match orientation with
    | North -> {state with Long = state.Long + steps}
    | South -> {state with Long = state.Long - steps}
    | East  -> {state with Lat = state.Lat + steps}
    | West  -> {state with Lat = state.Lat - steps}
    
let processInstruction (state:State) (navInst:NavInstruction) : State =
    match navInst with
    | Move (Orientation (orient, steps)) -> move state orient steps
    | Turn (Left, degrees) -> {state with LookAt = turnRight state.LookAt -degrees}
    | Turn (Right, degrees) -> {state with LookAt = turnRight state.LookAt degrees}
    | Move (Forward steps) -> move state state.LookAt steps
    
let parseNavInst (navIntStr:string) : NavInstruction =
    let value = navIntStr.[1..] |> int
    match navIntStr.[0] with
    | 'N' -> Move (Orientation (North, value))
    | 'S' -> Move (Orientation (South, value))
    | 'E' -> Move (Orientation (East, value))
    | 'W' -> Move (Orientation (West, value))
    | 'L' -> Turn (Left, value)
    | 'R' -> Turn (Right, value)
    | 'F' -> Move (Forward value)
    | _ -> failwith "this shouldn't happen"
    
let manhattanDistance (state:State) : int =
    Math.Abs state.Lat + Math.Abs state.Long