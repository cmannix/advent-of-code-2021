open System.IO

let day1Result =
    File.ReadLines("Day1/input.txt")
    |> Seq.map int
    |> Seq.fold
        Day1.countIncreasedDepths
        { PreviousDepth = None
          IncreasedDepthCount = 0 }

printfn $"Day 1: Count of increasing depths = %i{day1Result.IncreasedDepthCount}"

let day2Part1Result =
    File.ReadLines("Day2/input.txt")
    |> Seq.map Day2.parseCommand
    |> Seq.fold
        Day2.updatePositionPart1
        { HorizontalPosition = 0
          Depth = 0
          Aim = 0 }
    |> fun finalPosition ->
        finalPosition.Depth
        * finalPosition.HorizontalPosition

printfn $"Day 2 (Part 1): Product of final horizontal and vertical positions = %i{day2Part1Result}"

let day2Part2Result =
    File.ReadLines("Day2/input.txt")
    |> Seq.map Day2.parseCommand
    |> Seq.fold
        Day2.updatePositionPart2
        { HorizontalPosition = 0
          Depth = 0
          Aim = 0 }
    |> fun finalPosition ->
        finalPosition.Depth
        * finalPosition.HorizontalPosition

printfn $"Day 2 (Part 2): Product of final horizontal and vertical positions = %i{day2Part2Result}"

let day3Part1Result =
    File.ReadLines("Day3/input.txt")
    |> Seq.fold Day3.getBitCountByPosition (Array.zeroCreate 12)
    |> Day3.toRates
    |> fun result -> result.GammaRate * result.EpsilonRate

printfn $"Day 3 (Part 1): Product of Gamma rate and Epsilon rate = %i{day3Part1Result}"
