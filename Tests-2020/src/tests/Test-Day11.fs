module Test_Day11

open Xunit
open Swensen.Unquote
open AoC_Mike.Helpers
open AoC_Mike

let getPuzzleInput = Program.getPuzzleInput

let input = ["L.LL.LL.LL"
             "LLLLLLL.LL"
             "L.L.L..L.."
             "LLLL.LL.LL"
             "L.LL.LL.LL"
             "L.LLLLL.LL"
             "..L.L....."
             "LLLLLLLLLL"
             "L.LLLLLL.L"
             "L.LLLLL.LL"]

[<Fact>]
let ``Test Day 11/1 Test1`` () =
    
    let result1 = "
#.##.##.##
#######.##
#.#.#..#..
####.##.##
#.##.##.##
#.#####.##
..#.#.....
##########
#.######.#
#.#####.##"
    result1 =! (input
               |> Day11.stringsToPositions
               |> Day11.analysePositions
               |> Day11.positionsToString)
    
[<Fact>]
let ``Test Day 11/1 Test2`` () =
    
    let result2 = "
#.LL.L#.##
#LLLLLL.L#
L.L.L..L..
#LLL.LL.L#
#.LL.LL.LL
#.LLLL#.##
..L.L.....
#LLLLLLLL#
#.LLLLLL.L
#.#LLLL.##"
    result2 =! (input
               |> Day11.stringsToPositions
               |> Day11.analysePositions
               |> Day11.analysePositions
               |> Day11.positionsToString)
    
[<Fact>]
let ``Test Day 11/1 Test3`` () =
    
    let result3 = "
#.##.L#.##
#L###LL.L#
L.#.#..#..
#L##.##.L#
#.##.LL.LL
#.###L#.##
..#.#.....
#L######L#
#.LL###L.L
#.#L###.##"
    result3 =! (input
               |> Day11.stringsToPositions
               |> Day11.analysePositions
               |> Day11.analysePositions
               |> Day11.analysePositions
               |> Day11.positionsToString)
    
[<Fact>]
let ``Test Day 11/1 Test4`` () =
    
    let result4 = "
#.#L.L#.##
#LLL#LL.L#
L.L.L..#..
#LLL.##.L#
#.LL.LL.LL
#.LL#L#.##
..L.L.....
#L#LLLL#L#
#.LLLLLL.L
#.#L#L#.##"
    result4 =! (input
               |> Day11.stringsToPositions
               |> Day11.analysePositions
               |> Day11.analysePositions
               |> Day11.analysePositions
               |> Day11.analysePositions
               |> Day11.positionsToString)

[<Fact>]
let ``Test Day 11/1 Test5`` () =
    
    let result5 = "
#.#L.L#.##
#LLL#LL.L#
L.#.L..#..
#L##.##.L#
#.#L.LL.LL
#.#L#L#.##
..L.L.....
#L#L##L#L#
#.LLLLLL.L
#.#L#L#.##"
    result5 =! (input
               |> Day11.stringsToPositions
               |> Day11.analysePositions
               |> Day11.analysePositions
               |> Day11.analysePositions
               |> Day11.analysePositions
               |> Day11.analysePositions
               |> Day11.positionsToString)
    
[<Fact>]
let ``Test Day 11/1 Test6`` () =
    37 =! (input |> Day11.puzzle1)
    
[<Fact>]
let ``Test Day 11/1 Final`` () =
    Ok 2211 =! (readLines "../inputs/Day11.txt"
                |> Result.map Day11.puzzle1)