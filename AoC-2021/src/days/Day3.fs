module AoC2021.Day3

open System

let getBinaryDigit pos number = number &&& (int(2.0**(float pos)))

let numberOfBinaryDigits = float >> Math.Log2 >> Math.Ceiling >> int

let private binaryDigitsToInt =
    Seq.mapi (fun i x -> x * (int(2.0**i)))
    >> Seq.sum

let private calcMoreZeroesThanOnesPerDigit numbers =
    let numOfDigits = numbers |> Seq.max |> numberOfBinaryDigits

    let countZeroesOnBinaryPosition numbers pos =
        numbers
        |> Seq.map (getBinaryDigit pos)
        |> Seq.filter ((=) 0)
        |> Seq.length
    
    seq { 0 .. (numOfDigits-1) }
    // count zeroes
    |> Seq.map (countZeroesOnBinaryPosition numbers)
    |> Seq.map ((<) ((numbers |> Seq.length)/2))

let calcMostCommonBits (numbers:int seq) =
    numbers
    |> calcMoreZeroesThanOnesPerDigit
    |> Seq.map (function | true -> 0 | false -> 1)
    |> binaryDigitsToInt

let calcLeastCommonBits (numbers:int seq) =
    numbers
    |> calcMoreZeroesThanOnesPerDigit
    // more zeroes than 1s?
    |> Seq.map (function | true -> 1 | false -> 0)
    |> binaryDigitsToInt

let puzzle1 numbers =
    let epsilonRate = calcMostCommonBits numbers
    let gammaRate = calcLeastCommonBits numbers
    let powerConsumption = epsilonRate * gammaRate

    powerConsumption

let puzzle2 numbers =
    let numOfDigits = numbers |> Seq.max |> numberOfBinaryDigits

    let rec filterPos filterFun pos values=
        if pos < 0 then failwith ":("

        let filterValue = filterFun values
        let digit = getBinaryDigit pos filterValue

        let numbersFiltered =
            values
            |> Seq.filter (fun number ->
                    digit = getBinaryDigit pos number
                )
            |> Seq.toList

        match numbersFiltered |> Seq.length with
        | 0 -> failwith "You said this couldn't happen!"
        | 1 -> numbersFiltered |> Seq.head
        | _ -> filterPos filterFun (pos-1) numbersFiltered
        
    let oxygenGeneratorRating = filterPos calcMostCommonBits (numOfDigits-1) numbers
    let co2ScrubberRating = filterPos calcLeastCommonBits (numOfDigits-1) numbers

    oxygenGeneratorRating * co2ScrubberRating