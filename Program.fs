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
    
    printfn "day4-1 Test:  %A" (Day4_1.puzzle input)
    printfn "day4-1 Final:  %A" (readLines "Inputs/Day4.txt" |> Result.map Day4_1.puzzle)

    //printfn "day4-2 Test:  %A" (Day4_2.puzzle input)
    printfn "day4-2 Final:  %A" (readLines "Inputs/Day4.txt" |> Result.map Day4_2.puzzle)
    
//    printfn "test %A" (Day4_2.parseYear 1920 2002 "2002")
//    printfn "test %A" (Day4_2.parseYear 1920 2002 "2003")
//    printfn "test %A" (Day4_2.parseYear 1920 2002 "1919")
//    printfn "test %A" (Day4_2.parseYear 1920 2002 "1920")
//    printfn "test %A" (Day4_2.parseYear 1920 2002 "192")
//    printfn "test %A" (Day4_2.parseYear 1920 2002 "19205")
//    for height in ["149cm"; "150cm"; "193cm"; "194cm"; "58in"; "59in"; "76in"; "77in"; "60in"; "190cm"; "190in"; "190"] do
//        printfn "test %A %A" height (Day4_2.parseHeight height)
    
//    for color in ["#123abc"; "#123abz"; "123abc"; "#aef14"; "#1233524"] do
//        printfn "test %A %A" color (Day4_2.parseHairColor color)
        
//    for color in ["brn"; "wat"] do
//        printfn "test %A %A" color (Day4_2.parseEyeColor color)
        
//    for pid in ["000000001"; "0123456789"; "01234567"] do
//        printfn "test %A %A" pid (Day4_2.parsePassportId pid)
//    
//    let invalidInput = ["eyr:1972 cid:100 hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926"
//                        "iyr:2019 hcl:#602927 eyr:1967 hgt:170cm ecl:grn pid:012533040 byr:1946"
//                        "hcl:dab227 iyr:2012 ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277"
//                        "hgt:59cm ecl:zzz eyr:2038 hcl:74454a iyr:2023 pid:3556412378 byr:2007"]
//    for inp in invalidInput do
//        printfn "invalid test %A %A" (Day4_2.puzzle [inp]) inp
//        
//    let validInput = ["pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980 hcl:#623a2f"
//                      "eyr:2029 ecl:blu cid:129 byr:1989 iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm"
//                      "hcl:#888785 hgt:164cm byr:2001 iyr:2015 cid:88 pid:545766238 ecl:hzl eyr:2022"
//                      "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719"]
//    for inp in validInput do
//        printfn "valid test %A %A" (Day4_2.puzzle [inp]) inp
    
    0 // return an integer exit code