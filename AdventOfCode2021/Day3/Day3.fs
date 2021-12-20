module Day3

type Result =
    { GammaRate: int
      EpsilonRate: int
      OxygenRate: int
      Co2Rate: int }

let private toDecimalNumber bits =
    let rec calculateBitValue bits currentTotal =
        match bits with
        | head :: tail when head ->
            calculateBitValue tail currentTotal
            + (pown 2 (List.length tail))
        | _ :: tail -> calculateBitValue tail currentTotal
        | _ -> currentTotal

    calculateBitValue bits 0

let private getValueMatchingCriteria getBitValues input =
    let rec findByCriteriaAtPosition bitPosition getBitValues (input: bool [] []) =
        if Array.length input = 1 then
            input[0]
        else
            let bitValues: bool [] = getBitValues input
            let currentBitValue = bitValues[bitPosition]

            let matching =
                input
                |> Array.filter (fun x -> x[bitPosition] = currentBitValue)

            findByCriteriaAtPosition (bitPosition + 1) getBitValues matching

    findByCriteriaAtPosition 0 getBitValues input

let private mostCommon input =
    let count = input |> Array.filter id |> Array.length
    float32 count >= (float32 input.Length) / 2f

let private leastCommon input =
    let count = input |> Array.filter id |> Array.length
    float32 count < (float32 input.Length) / 2f

let private getBitsByCountCriteria criteria input =
    Array.transpose input |> Array.map criteria

let private mostCommonBits = getBitsByCountCriteria mostCommon

let private leastCommonBits = getBitsByCountCriteria leastCommon

let parseBitValues input =
    input
    |> Seq.toList
    |> Seq.map
        (fun x ->
            match x with
            | '0' -> false
            | '1' -> true
            | other -> invalidArg (nameof input) $"Unsupported character in input {other}")

let calculateRates input =
    { GammaRate =
          input
          |> mostCommonBits
          |> Array.toList
          |> toDecimalNumber
      EpsilonRate =
          input
          |> leastCommonBits
          |> Array.toList
          |> toDecimalNumber
      OxygenRate =
          input
          |> getValueMatchingCriteria mostCommonBits
          |> Array.toList
          |> toDecimalNumber
      Co2Rate =
          input
          |> getValueMatchingCriteria leastCommonBits
          |> Array.toList
          |> toDecimalNumber }
