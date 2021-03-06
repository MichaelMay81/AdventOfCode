module Test_Day07

open System
open Xunit
open Swensen.Unquote
open AoC2020.Helpers
open AoC2020

let getPuzzleInput = Program.getPuzzleInput

let input1 = ["light red bags contain 1 bright white bag, 2 muted yellow bags."
              "dark orange bags contain 3 bright white bags, 4 muted yellow bags."
              "bright white bags contain 1 shiny gold bag."
              "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags."
              "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags."
              "dark olive bags contain 3 faded blue bags, 4 dotted black bags."
              "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags."
              "faded blue bags contain no other bags."
              "dotted black bags contain no other bags."]

let input2 = ["shiny gold bags contain 2 dark red bags."
              "dark red bags contain 2 dark orange bags."
              "dark orange bags contain 2 dark yellow bags."
              "dark yellow bags contain 2 dark green bags."
              "dark green bags contain 2 dark blue bags."
              "dark blue bags contain 2 dark violet bags."
              "dark violet bags contain no other bags."]

[<Fact>]
let ``Test Day 7/1 Test`` () =
    // xunit:
    Assert.Equal(4, input1 |> (Day7.puzzle1 "shiny gold"))
    
    // unquote:
    // test <@ 4 = (input1 |> (Day7.puzzle1 "shiny gold")) @>
    // 4 =! (input1 |> (Day7.puzzle1 "shiny gold"))
    
[<Fact>]
let ``Test Day 7/1 Final`` () =
    Ok 378 =! (readLines "../inputs/Day7.txt" |> Result.map (Day7.puzzle1 "shiny gold"))
    
[<Fact>]
let ``Test Day 7/2 Test1`` () =
    32 =! (input1 |> (Day7.puzzle2 "shiny gold"))
    
[<Fact>]
let ``Test Day 7/2 Test2`` () =
    126 =! (input2 |> (Day7.puzzle2 "shiny gold"))
    
[<Fact>]
let ``Test Day 7/2 Final`` () =
    Ok 27526 =! (readLines "../inputs/Day7.txt" |> Result.map (Day7.puzzle2 "shiny gold"))