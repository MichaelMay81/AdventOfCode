module AoC2021.Day3

open System

type Bit =
| Zero
| One

let inverseBit = function | Zero -> One | One -> Zero
let bitToInt = function | Zero -> 0 | One -> 1
let bitsToInt =
    Seq.map bitToInt
    >> Seq.mapi (fun i x -> x * (int(2.0**i)))
    >> Seq.sum

let getBit pos number =
    number &&& (int(2.0**(float pos)))
    |> function | 0 -> Zero | _ -> One

let numberOfBinaryDigits = float >> Math.Log2 >> Math.Ceiling >> int

let calcMostCommonBitOnPos numbers pos =
    numbers
    |> Seq.map (getBit pos)
    // count zeros
    |> Seq.filter ((=) Zero)
    |> Seq.length
    // return most common
    |> (<) ((numbers |> Seq.length)/2)
    |> function | true -> Zero | false -> One

let private calcMostCommonBits numbers =
    let numOfDigits = numbers |> Seq.max |> numberOfBinaryDigits

    seq { 0 .. (numOfDigits-1) }
    |> Seq.map (calcMostCommonBitOnPos numbers)

let puzzle1 numbers =
    let mostCommonBits = numbers |> calcMostCommonBits

    let epsilonRate = mostCommonBits |> bitsToInt
    let gammaRate = mostCommonBits |> Seq.map inverseBit |> bitsToInt
    
    // powerConsumption
    epsilonRate * gammaRate

let puzzle2 numbers =
    let rec filterPos filterFun pos values =
        if pos < 0 then failwith "You said this couldn't happen!"

        let mcb = filterFun values pos

        let numbersFiltered =
            values
            |> Seq.filter (fun number ->
                    mcb = getBit pos number)
            |> Seq.toList
        
        match numbersFiltered |> Seq.length with
        | 1 -> numbersFiltered |> Seq.head
        | _ -> filterPos filterFun (pos-1) numbersFiltered

    let numOfDigits = numbers |> Seq.max |> numberOfBinaryDigits

    let calcMCB = calcMostCommonBitOnPos
    let calcLCB = (fun values pos -> calcMostCommonBitOnPos values pos |> inverseBit)
    let oxygenGeneratorRating = filterPos calcMCB (numOfDigits-1) numbers
    let co2ScrubberRating = filterPos calcLCB (numOfDigits-1) numbers

    oxygenGeneratorRating * co2ScrubberRating