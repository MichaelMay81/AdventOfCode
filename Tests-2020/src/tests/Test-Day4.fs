module Test_Day04

open System
open Xunit
open Swensen.Unquote
open AoC2020.Helpers
open AoC2020

let getPuzzleInput = Program.getPuzzleInput

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

[<Fact>]
let ``Puzzle 1, Test`` () =
    2 =! (Day4_1.puzzle input)
    
[<Fact>]
let ``Puzzle 1, Final`` () =
    Ok 222 =! (readLines "../inputs/Day4.txt" |> Result.map Day4_1.puzzle)

[<Fact>]
let ``Puzzle 2, Test`` () =
    2 =! (Day4_2.puzzle input)
    
[<Fact>]
let ``Puzzle 2, Final`` () =
    Ok 140 =! (readLines "../inputs/Day4.txt" |> Result.map Day4_2.puzzle)
    
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