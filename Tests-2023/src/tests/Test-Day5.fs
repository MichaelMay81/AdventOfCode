module Test_Day05

open Expecto
open Expecto.Flip
open AoC2023
open AoC2023.Helpers

let input = """seeds: 79 14 55 13

seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4"""

[<Tests>]
let test1 = test "Day5 Part1 Test" {
    input
    |> Day1_1.parse
    |> Day5_1.puzzle
    |> Expect.equal "" 35L
}

[<Tests>]
let final1 = testAsync "Day5 Part1 Final" {
    readAllLines "../inputs/day5.txt"
    |> Day5_1.puzzle
    |> Expect.equal "" 173706076L
}

[<Tests>]
let test1b = test "Day5 Part1b Test" {
    input
    |> Day1_1.parse
    |> Day5_1b.puzzle
    |> Expect.equal "" 35L
}

// [<Tests>]
// let final1b = testAsync "Day5 Part1b Final" {
//     readAllLines "../inputs/day5.txt"
//     |> Day5_1b.puzzle
//     |> Expect.equal "" 173706076L
// }