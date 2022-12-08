module AoC2022.Day8_1

open FSharpPlus
#nowarn "25"

let parse =
    String.split ["\n"]
    >> Seq.map (Seq.map (fun c -> int c - int '0') >> Seq.toList)
    >> Seq.toList

let isLineVisible (first::trees : int list) =
    let rec isLineVisibleRec (visibility:bool list) (lastHighest:int) (trees:int list) =
        match trees with
        | [last] -> true::visibility |> List.rev
        | head::tail ->
            match head > lastHighest with
            | true ->
                // printfn "%i > %i %b" head lastHighest true
                isLineVisibleRec (true::visibility) head tail
            | false ->
                // printfn "%i > %i %b" head lastHighest false
                isLineVisibleRec (false::visibility) lastHighest tail
    isLineVisibleRec [true] first trees

let isVisibleHorLeft2Right (trees: int list list) =
    trees
    |> Seq.map isLineVisible
    |> Seq.toList

let isVisibleHorRight2Left (trees: int list list) =
    trees
    |> Seq.map (List.rev >> isLineVisible >> List.rev)
    |> Seq.toList

let rotate (first::trees: 'T list list) : 'T list list =
    first
    |> List.mapi (fun i el ->
        el :: (trees |> List.map (Seq.item i))
    )

let isVisibleVerUp2Down (trees: int list list) =
    trees
    |> rotate
    |> isVisibleHorLeft2Right
    |> rotate

let isVisibleVerDown2Up (trees: int list list) =
    trees
    |> rotate
    |> isVisibleHorRight2Left
    |> rotate

let isVisible (trees: int list list) =
    Helpers.zip4
        (isVisibleHorLeft2Right trees)
        (isVisibleHorRight2Left trees)
        (isVisibleVerUp2Down trees)
        (isVisibleVerDown2Up trees)
    |> Seq.map (fun (listA, listB, listC, listD) ->
        Helpers.zip4 listA listB listC listD
        |> Seq.map (fun (a,b,c,d) -> a || b || c || d)
        |> Seq.toList
    )
    |> Seq.toList

let puzzle1 =
    parse
    >> isVisible
    >> Seq.concat
    >> Seq.filter id
    >> Seq.length