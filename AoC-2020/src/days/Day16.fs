module AoC2020.Day16

open FSharpPlus

type Range = { Min:int; Max:int }
type Rule = string*Range*Range
type State = {
    Rules: Rule list
    YourTicket: int list
    NearbyTickets: int list list
}
let initState = {Rules=List.empty; YourTicket=List.empty; NearbyTickets=List.empty}

type TicketState = Yours | Nearby
type ParseResult =
    | Rule of Rule
    | NearbyTickets
    | Ticket of int list
    
let parseLine (input: string) : ParseResult option =
    if input = "your ticket:" || input = ""
    then None
    elif input = "nearby tickets:"
    then Some NearbyTickets
    else
        match input |> (trySscanf "%s: %i-%i or %i-%i") with
        | Some (name, min1, max1, min2, max2) ->
                Some (Rule (name, {Min=min1; Max=max1}, {Min=min2; Max=max2}))
        | None ->
            Some (Ticket (input |> String.split [","] |> Seq.map int |> Seq.toList)) 

let parse (input:string seq) : State =
    let rec loop (lines:string list) (tState:TicketState) (state:State) : State =
        match lines with
        | [] -> state
        | head :: tail ->
            match parseLine head with
            | None -> loop tail tState state
            | Some NearbyTickets -> loop tail Nearby state
            | Some (Rule rule) -> loop tail tState {state with Rules = rule :: state.Rules}
            | Some (Ticket ticket) ->
                match tState with
                | Yours -> loop tail tState {state with YourTicket = ticket}
                | Nearby -> loop tail tState {state with NearbyTickets = ticket :: state.NearbyTickets}
        
    loop (input |> Seq.toList) Yours initState

let ruleApplies (field:int) (rule:Rule) =
    let _, rule1, rule2 = rule
    (field >= rule1.Min
    && field <= rule1.Max)
    || (field >= rule2.Min
        && field <= rule2.Max)
    
let puzzle1 (input:string seq) : int =
    let state = input |> parse
    
    let foobar = state.NearbyTickets
                    |> Seq.concat
                    |> Seq.filter (fun f -> state.Rules |> Seq.forall (ruleApplies f >> not))
                    |> Seq.toList
    foobar |> Seq.sum