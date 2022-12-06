module Test_Day06

open Expecto
open Expecto.Flip
open AoC2022.Day6
open AoC2022.Helpers

let dayCount = 6
let finalInputPath = "../inputs/day6.txt"
let input1 = "mjqjpqmgbljsphdztnvjfqwrcgsmlb"
let input2 = "bvwbjplbgvbhsrlpgdmjqwftvncz"
let input3 = "nppdvjthqldpwncqszvftbrmjlhg"
let input4 = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg"
let input5 = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw"

[<Tests>]
let test11 = test $"Day{dayCount} Part1 Test1" {
  input1
  |> puzzle1
  |> Expect.equal "" (Ok 7)
}
[<Tests>]
let test12 = test $"Day{dayCount} Part1 Test2" {
  input2
  |> puzzle1
  |> Expect.equal "" (Ok 5)
}
[<Tests>]
let test13 = test $"Day{dayCount} Part1 Test3" {
  input3
  |> puzzle1
  |> Expect.equal "" (Ok 6)
}
[<Tests>]
let test14 = test $"Day{dayCount} Part1 Test4" {
  input4
  |> puzzle1
  |> Expect.equal "" (Ok 10)
}
[<Tests>]
let test15 = test $"Day{dayCount} Part1 Test5" {
  input5
  |> puzzle1
  |> Expect.equal "" (Ok 11)
}

[<Tests>]
let final1 = testAsync $"Day{dayCount} Part1 Final" {
  readAllText finalInputPath
  |> puzzle1
  |> Expect.equal "" (Ok 1929)
}

[<Tests>]
let test21 = test $"Day{dayCount} Part2 Test1" {
  input1
  |> puzzle2
  |> Expect.equal "" (Ok 19)
}
[<Tests>]
let test22 = test $"Day{dayCount} Part2 Test2" {
  input2
  |> puzzle2
  |> Expect.equal "" (Ok 23)
}
[<Tests>]
let test23 = test $"Day{dayCount} Part2 Test3" {
  input3
  |> puzzle2
  |> Expect.equal "" (Ok 23)
}
[<Tests>]
let test24 = test $"Day{dayCount} Part2 Test4" {
  input4
  |> puzzle2
  |> Expect.equal "" (Ok 29)
}
[<Tests>]
let test25 = test $"Day{dayCount} Part2 Test5" {
  input5
  |> puzzle2
  |> Expect.equal "" (Ok 26)
}

[<Tests>]
let final2 = testAsync $"Day{dayCount} Part2 Final" {
  readAllText finalInputPath
  |> puzzle2
  |> Expect.equal "" (Ok 3298)
}