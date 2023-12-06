// Inspired by https://github.com/KaNaDaAT/AOC2023/blob/master/AdventOfCoding/Days/Day01/Day01B.cs

module AoC2023.Day1_2d

// one - eight
// two - one
// three - eight
// four
// five - eight
// six
// seven - nine
// eight - two, three
// nine - eight

let private nts = [
    "one", "o1e"
    "two", "t2o"
    "three", "t3e"
    "four", "4"
    "five", "5e"
    "six", "6"
    "seven", "7n"
    "eight", "e8t"
    "nine", "n9e"]

// let replace (oldValue:string) (newValue:string) (input:string) =
//     input.Replace (oldValue, newValue)

let replace (input:string) ((oldValue, newValue):string*string)  =
    input.Replace (oldValue, newValue)

let puzzle2 (input : string seq) =
    input
    |> Seq.map (fun line -> Seq.fold replace line nts)
    |> Seq.map (fun ints ->
        $"{Day1_1b.firstDigit ints}{Day1_1b.lastDigit ints}")
    |> Seq.map int
    |> Seq.sum