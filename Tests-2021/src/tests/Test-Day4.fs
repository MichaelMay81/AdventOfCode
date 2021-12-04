module Test_Day04

open Expecto
open Expecto.Flip
open AoC2021
open AoC2021.Helpers

let drawnNumbers = [7;4;9;5;11;17;23;2;0;14;21;24;10;16;13;6;15;25;12;22;18;20;8;19;3;26;1]
let input1 = [
    [22;13;17;11;0;8;2;23;4;24;21;9;14;16;7;6;10;3;18;5;1;12;20;15;19]
    [3;15;0;2;22;9;18;13;17;5;19;8;7;25;23;20;11;10;24;4;14;21;16;12;6]
    [14;21;17;24;4;10;16;15;9;19;18;8;23;26;20;22;11;13;6;5;2;0;12;3;7]
]

[<Tests>]
let test1 = test "Day4 Part1 Test" {
  Day4.puzzle1 drawnNumbers input1
  |> Expect.equal "" 4512
}

[<Tests>]
let test2 = test "Day4 Part2 Test" {
  Day4.puzzle2 drawnNumbers input1
  |> Expect.equal "" 1924
}

[<Tests>]
let final1 = testAsync "Day4 Part1 Final" {
  getPuzzleInput "../inputs/Day4.txt"
  |> Day4.parsePuzzleInput
  |> (fun (drawn, boards) -> Day4.puzzle1 drawn boards)
  |> Expect.equal "" 29440
}

[<Tests>]
let final2 = testAsync "Day4 Part2 Final" {
  getPuzzleInput "../inputs/Day4.txt"
  |> Day4.parsePuzzleInput
  |> (fun (drawn, boards) -> Day4.puzzle2 drawn boards)
  |> Expect.equal "" 13884
}