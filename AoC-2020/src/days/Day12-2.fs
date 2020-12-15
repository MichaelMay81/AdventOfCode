module AoC2020.Day12_2

open System

type Position = {
    Lat : int // horizontal
    Long : int // vertical
}

type State = {
    Ship : Position
    Waypoint : Position
}

let initState = {
    Ship = { Lat = 0; Long = 0 }
    Waypoint = { Lat = 10; Long = 1 }
}

let turnLeft (state:State) (degrees:int) : State =
    let toRadians = float >> (*) (Math.PI / 180.)
    let sin = degrees |> toRadians |> Math.Sin |> int
    let cos = degrees |> toRadians |> Math.Cos |> int
    
    {state with Waypoint = {
            Lat  = state.Waypoint.Lat * cos - state.Waypoint.Long * sin
            Long = state.Waypoint.Lat * sin + state.Waypoint.Long * cos
    }}
    
let moveWaypoint (state:State) (orientation:Day12_1.Orientation) (steps:int) : State =
    match orientation with
    | Day12_1.North -> {state with Waypoint = { state.Waypoint with Long = state.Waypoint.Long + steps}}
    | Day12_1.South -> {state with Waypoint = { state.Waypoint with Long = state.Waypoint.Long - steps}}
    | Day12_1.East  -> {state with Waypoint = { state.Waypoint with Lat = state.Waypoint.Lat + steps}}
    | Day12_1.West  -> {state with Waypoint = { state.Waypoint with Lat = state.Waypoint.Lat - steps}}
    
let moveForward (state:State) (steps:int) : State =
    {state with Ship = {
            Lat = state.Ship.Lat + steps * state.Waypoint.Lat
            Long = state.Ship.Long + steps * state.Waypoint.Long
    }}
    
let processInstruction (state:State) (navInst:Day12_1.NavInstruction) : State =
    match navInst with
    | Day12_1.Move (Day12_1.Orientation (orient, steps)) -> moveWaypoint state orient steps
    | Day12_1.Turn (Day12_1.Left, degrees) -> turnLeft state degrees
    | Day12_1.Turn (Day12_1.Right, degrees) -> turnLeft state -degrees
    | Day12_1.Move (Day12_1.Forward steps) -> moveForward state steps
    
let manhattanDistance (pos:Position) : int =
    Math.Abs pos.Lat + Math.Abs pos.Long