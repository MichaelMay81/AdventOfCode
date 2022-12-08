module AoC2022.Day8_2

// open FSharpPlus
#nowarn "25"

let treesSeenOnLine (trees:int list) =
    let rec numberOfTreesSeen (tree:int) (trees:int list) (dist:int): int =
        match trees with
        | [] -> dist
        | head::tail ->
            match head >= tree with
            | true -> dist + 1
            | false -> numberOfTreesSeen tree tail (dist+1)

    let rec treesSeenOnLineRec (treesSeen:int list) (trees) =
        match trees with
        | [_] -> 0::treesSeen
        | head::tail ->
            let currTreesSeen = numberOfTreesSeen head tail 0
            // printfn "%i %A -> %i" head tail currTreesSeen
            treesSeenOnLineRec (currTreesSeen::treesSeen) tail
    
    treesSeenOnLineRec [] trees
    |> List.rev

let treesSeenHorLeft2Right (trees: int list list) =
    trees
    |> Seq.map treesSeenOnLine
    |> Seq.toList

let treesSeenHorRight2Left (trees: int list list) =
    trees
    |> Seq.map (List.rev >> treesSeenOnLine >> List.rev)
    |> Seq.toList

let rotate (first::trees: 'T list list) : 'T list list =
    first
    |> List.mapi (fun i el ->
        el :: (trees |> List.map (Seq.item i))
    )

let treesSeenVerUp2Down (trees: int list list) =
    trees
    |> rotate
    |> treesSeenHorLeft2Right
    |> rotate

let treesSeenVerDown2Up (trees: int list list) =
    trees
    |> rotate
    |> treesSeenHorRight2Left
    |> rotate

let treesSeen (trees: int list list) =
    Helpers.zip4
        (treesSeenHorLeft2Right trees)
        (treesSeenHorRight2Left trees)
        (treesSeenVerUp2Down trees)
        (treesSeenVerDown2Up trees)
    |> Seq.map (fun (listA, listB, listC, listD) ->
        Helpers.zip4 listA listB listC listD
        |> Seq.map (fun (a,b,c,d) -> a * b * c * d)
        |> Seq.toList
    )
    |> Seq.toList

let puzzle2 =
    Day8_1.parse
    >> treesSeen
    >> Seq.concat
    >> Seq.max