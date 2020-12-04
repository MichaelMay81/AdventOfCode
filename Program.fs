open AoC_Mike
open Helpers
open FSharpPlus

let getPuzzleInput filePath =
    readLines filePath |> outputErrorAndDefault Seq.empty

let testAll () =
    let input = [ 1721; 979; 366; 299; 675; 1456 ]
    
    printfn "day1-1 Test:  %A" (Day1.puzzle1 input) 
    printfn "day1-1 Final: %A" (getPuzzleInput "Inputs/Day1.txt" |> Seq.toList |> List.map int |> Day1.puzzle1)

    printfn "day1-2 Test:  %A" (Day1.puzzle2 input)
    printfn "day1-2 Final: %A" (getPuzzleInput "Inputs/Day1.txt" |> Seq.toList |> List.map int |> Day1.puzzle2)
    
    let input = ["1-3 a: abcde"; "foobar"; "1-3 b: cdefg"; "2-9 c: ccccccccc"] |> List.toSeq
    printfn "day2-1 Test:  %A" (Day2.puzzle1 input)
    printfn "day2-1 Final: %A" (getPuzzleInput "Inputs/Day2.txt" |> Day2.puzzle1)
    
    printfn "day2-2 Test:  %A" (Day2.puzzle2 input)
    printfn "day2-2 Final: %A" (getPuzzleInput "Inputs/Day2.txt" |> Day2.puzzle2)
    
//    printfn "foobar %A" (["1-3 a: abcde" |> Day2.parse] |> filter |> Seq.map Day2.isPassCorrect2)
//    printfn "foobar %A" (["1-3 b: cdefg" |> Day2.parse] |> filter |> Seq.map Day2.isPassCorrect2)
//    printfn "foobar %A" (["2-9 c: ccccccccc" |> Day2.parse] |> filter |> Seq.map Day2.isPassCorrect2)

    let input = [|"..##......."
                  "#...#...#.."
                  ".#....#..#."
                  "..#.#...#.#"
                  ".#...##..#."
                  "..#.##....."
                  ".#.#.#....#"
                  ".#........#"
                  "#.##...#..."
                  "#...##....#"
                  ".#..#...#.#"|]
    
    printfn "day3-1 Test:  %A" (Day3.puzzle1 input)
    printfn "day3-1 Final:  %A" (getPuzzleInput "Inputs/Day3.txt" |> Seq.toArray |> Day3.puzzle1)
    
    printfn "day3-2 Test:  %A" (Day3.puzzle2 input)
    printfn "day3-2 Final:  %A" (readLines "Inputs/Day3.txt" |> Result.map ( Seq.toArray >> Day3.puzzle2))

[<EntryPoint>]
let main argv =
    let input = [|"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd"
                  "byr:1937 iyr:2017 cid:147 hgt:183cm"
                  ""
                  "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884"
                  "hcl:#cfa07d byr:1929"
                  ""
                  "hcl:#ae17e1 iyr:2013"
                  "eyr:2024"
                  "ecl:brn pid:760753108 byr:1931"
                  "hgt:179cm"
                  ""
                  "hcl:#cfa07d eyr:2025 pid:166559648"
                  "iyr:2011 ecl:brn hgt:59in"|]
    
    printfn "day4-1 Test:  %A" (Day4.puzzle1 input)
    printfn "day4-2 Final:  %A" (readLines "Inputs/Day4.txt" |> Result.map Day4.puzzle1)

    0 // return an integer exit code