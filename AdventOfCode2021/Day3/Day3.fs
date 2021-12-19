module Day3

type Result = { GammaRate: int; EpsilonRate: int }
let inline (++) a b = Seq.map2 (+) a b

let getBitCountByPosition counts (number: string) =
    number
    |> Seq.toList
    |> Seq.map (fun x -> if (x = '1') then 1 else -1)
    |> fun x -> counts ++ x

let toDecimalNumber bits =
    let rec calculateBitValue bits currentTotal =
        match bits with
        | head :: tail when head ->
            calculateBitValue tail currentTotal
            + (pown 2 (List.length tail))
        | _ :: tail -> calculateBitValue tail currentTotal
        | _ -> currentTotal

    calculateBitValue bits 0

let toRates bitCounts =
    bitCounts
    |> Seq.map (fun count -> (count > 0))
    |> Seq.toList
    |> fun popularBits ->
        { GammaRate = toDecimalNumber popularBits
          EpsilonRate = toDecimalNumber (popularBits |> List.map not) }
