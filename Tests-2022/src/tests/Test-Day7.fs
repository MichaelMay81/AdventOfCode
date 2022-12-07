module Test_Day07

open Expecto
open Expecto.Flip
open AoC2022.Day7
open AoC2022.Helpers

let dayCount = 7
let finalInputPath = "../inputs/day7.txt"
let input = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k"

[<Tests>]
let test1 = test $"Day{dayCount} Part1 Test" {
  input
  |> puzzle1
  |> Expect.equal "" 95437
}
[<Tests>]
let final1 = testAsync $"Day{dayCount} Part1 Final" {
  readAllText finalInputPath
  |> puzzle1
  |> Expect.equal "" 1306611
}
[<Tests>]
let test2 = test $"Day{dayCount} Part2 Test" {
  input
  |> puzzle2
  |> Expect.equal "" 24933642
}
[<Tests>]
let final2 = testAsync $"Day{dayCount} Part2 Final" {
  readAllText finalInputPath
  |> puzzle2
  |> Expect.equal "" 13210366
}