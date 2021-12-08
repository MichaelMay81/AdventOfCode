module Test_Day08

open Expecto
open Expecto.Flip
open AoC2021
open AoC2021.Helpers
open FSharpPlus

let input1 = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf"
let input2 = [
    "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe"
    "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc"
    "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg"
    "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb"
    "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea"
    "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb"
    "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe"
    "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef"
    "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb"
    "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
    ]

[<Tests>]
let test1 = test "Day8 Part1 Test1" {
    [input1]
    |> map Day8.parse7sEntry
    |> Day8.puzzle1
    |> Expect.equal "" 0
}

[<Tests>]
let test2 = test "Day8 Part1 Test2" {
    input2
    |> map Day8.parse7sEntry
    |> Day8.puzzle1
    |> Expect.equal "" 26
}

[<Tests>]
let final1 = testAsync "Day8 Part1 Final" {
    getPuzzleInput "../inputs/Day8.txt"
    |> map Day8.parse7sEntry
    |> Day8.puzzle1
    |> Expect.equal "" 239
}

[<Tests>]
let test3 = test "Day8 Part2 Test1" {
    input1
    |> Day8.parse7sEntry
    |> (fun (patterns, output) -> Day8.decode (patterns |> Seq.map Set) (output |> Seq.map Set))
    |> Seq.toList
    |> Expect.equal "" [5; 3; 5; 3]
}    

[<Tests>]
let test4 = test "Day8 Part2 Test2" {
    [input1
    |> Day8.parse7sEntry]
    |> Day8.puzzle2
    |> Expect.equal "" 5353
}   
    
[<Tests>]
let test5 = test "Day8 Part2 Test3" {
    input2
    |> map Day8.parse7sEntry
    |> Day8.puzzle2
    |> Expect.equal "" 61229
}

[<Tests>]
let final2 = testAsync "Day8 Part2 Final" {
    getPuzzleInput "../inputs/Day8.txt"
    |> map Day8.parse7sEntry
    |> Day8.puzzle2
    |> Expect.equal "" 946346
}