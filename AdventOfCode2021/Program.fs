open System.IO

File.ReadLines("Day1/input.txt")
|> Seq.map int
|> Seq.fold
    Day1.countIncreasedDepths
    { PreviousDepth = None
      IncreasedDepthCount = 0 }
|> fun result -> printfn $"Day 1: Count of increasing depths = %i{result.IncreasedDepthCount}"




File.ReadLines("Day2/input.txt")
|> Seq.map Day2.parseCommand
|> Seq.fold
    Day2.updatePositionPart1
    { HorizontalPosition = 0
      Depth = 0
      Aim = 0 }
|> fun finalPosition ->
    printfn
        $"Day 2 (Part 1): Product of final horizontal and vertical positions = %i{finalPosition.Depth
                                                                                  * finalPosition.HorizontalPosition}"


File.ReadLines("Day2/input.txt")
|> Seq.map Day2.parseCommand
|> Seq.fold
    Day2.updatePositionPart2
    { HorizontalPosition = 0
      Depth = 0
      Aim = 0 }
|> fun finalPosition ->
    printfn
        $"Day 2 (Part 2): Product of final horizontal and vertical positions = %i{finalPosition.Depth
                                                                                  * finalPosition.HorizontalPosition}"
File.ReadLines("Day3/input.txt")
|> Seq.map Day3.parseBitValues
|> Seq.map Seq.toArray
|> Seq.toArray
|> Day3.calculateRates
|> fun rates ->
    printfn $"Day 3 (Part 1): Product of Gamma rate and Epsilon rate = %i{rates.GammaRate * rates.EpsilonRate}"
    printfn $"Day 3 (Part 2): Product of Oxygen rate and CO2 rate = %i{rates.OxygenRate * rates.Co2Rate}"



File.ReadLines("Day4/input.txt")
|> Day4.parseInput
|> fun (numbers, boards) -> Day4.callNumbers Day4.firstWinner numbers boards
|> fun (lastNumber, winningScore) ->
    printfn
        $"Day 4 (Part 1): Product of first winning board score and last number called = %i{lastNumber * winningScore}"

File.ReadLines("Day4/input.txt")
|> Day4.parseInput
|> fun (numbers, boards) -> Day4.callNumbers Day4.lastWinner numbers boards
|> fun (lastNumber, winningScore) ->
    printfn
        $"Day 4 (Part 2): Product of last winning board score and last number called = %i{lastNumber * winningScore}"

File.ReadLines("Day5/input.txt")
|> Day5.parseLineLines
|> Seq.map Day5.getHorizontalOrVerticalPointsOnLine
|> Seq.fold Day5.countLinePoints Map.empty
|> Map.filter (fun _ count -> count >= 2)
|> Map.count
|> fun count -> printfn $"Day 5 (Part 1): Count of points covered by at least two horizontal or vertical lines = %i{count}"
