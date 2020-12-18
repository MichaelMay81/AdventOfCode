module AoC2020.Day16_2

open FSharpPlus

type Range = { Min:int; Max:int }
type Rule = Range*Range
type State = {
    Rules: Map<string, Rule>
    YourTicket: int list
    NearbyTickets: int list list
}
let initState = {Rules=Map.empty; YourTicket=List.empty; NearbyTickets=List.empty}

type TicketState = Yours | Nearby
type ParseResult =
    | Rule of string*Rule
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
            Some (Rule (name, ({Min=min1; Max=max1}, {Min=min2; Max=max2})))
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
            | Some (Rule (name, rule)) -> loop tail tState {state with Rules = state.Rules |> Map.add name rule}
            | Some (Ticket ticket) ->
                match tState with
                | Yours -> loop tail tState {state with YourTicket = ticket}
                | Nearby -> loop tail tState {state with NearbyTickets = ticket :: state.NearbyTickets}
        
    loop (input |> Seq.toList) Yours initState

let ruleApplies (field:int) (rule:Rule) =
    let foobar = (field >= (fst rule).Min
                && field <= (fst rule).Max)
                || (field >= (snd rule).Min
                    && field <= (snd rule).Max)
    foobar
    
let isFieldValid (rules:Rule seq) (field:int) =
    rules
    |> Seq.forall (ruleApplies field >> not)
    |> not
    
let isTicketValid (rules:Rule seq) (fs:int seq) =
    fs
    |> Seq.forall (isFieldValid rules)

let getValidRulesPerField (field:int) (rules:(string*Rule) seq) =
    rules
    |> Seq.filter (fun (_, rule) -> ruleApplies field rule )

let getValidRulesPerTicket (rulesPerField:(string*Rule) seq seq) (ticket:int seq) =
    Seq.zip ticket rulesPerField
    |> Seq.map (fun (f, r) -> getValidRulesPerField f r)

let getValidRules (tickets:int seq seq) (rulesPerField:(string*Rule) seq seq) =
    tickets
    |> Seq.fold getValidRulesPerTicket rulesPerField

let filterRules (rulesPerField:Set<string> seq) =
    let filter (rulesPerField:Set<string> seq) (fixatedRules:Set<string>) =
        rulesPerField
        |> Seq.map (fun rules -> if rules |> Set.count = 1
                                 then rules
                                 else Set.difference rules fixatedRules )
        
    let rec loop (rulesPerField:Set<string> seq) =
        let allSingles = rulesPerField |> Seq.filter (fun rules -> rules |> Set.count = 1) |> Seq.concat |> Set.ofSeq
        if (allSingles |> Set.count) = (rulesPerField |> Seq.length)
        then rulesPerField
        else loop (filter rulesPerField allSingles)
        
    loop rulesPerField

let test1 (input:string seq) : State*(string seq) =
    let state = input |> parse
    
    let numOfFields = state.YourTicket |> Seq.length
    let ruleKeys = state.Rules |> Map.toSeq
    let rulesPerField = Seq.init numOfFields (fun _ -> ruleKeys)
    
    let validTickets =
        state.NearbyTickets
        |> Seq.filter (isTicketValid (state.Rules |> Map.values))
        |> Seq.map List.toSeq
    
    let validRules = getValidRules validTickets rulesPerField
                     |> Seq.map (Seq.map fst >> Set.ofSeq)
                     |> filterRules
                     |> Seq.map (Set.toSeq >> Seq.head)
                     
    (state, validRules)
    
let final (input:string seq) : int64 =
    let state, ruleNames = test1 input
    
    Seq.zip ruleNames state.YourTicket 
    |> Seq.filter (fun (name, _) -> name |> String.startsWith "departure")
    |> Seq.map (snd >> int64)
    |> Seq.fold (*) 1L