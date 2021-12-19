open System.IO

let day1Result =
 File.ReadLines("Day1/input.txt")
 |> Seq.map int
 |> Seq.fold Day1.countIncreasedDepths { PreviousDepth = None; IncreasedDepthCount = 0 }
printfn $"Day 1: Count of increasing depths = %i{day1Result.IncreasedDepthCount}"

let finalPosition =
 File.ReadLines("Day2/input.txt")
 |> Seq.map Day2.parseCommand
 |> Seq.fold Day2.updatePosition { HorizontalPosition = 0; Depth = 0 }
printfn $"Day 2: Product of final horizontal and vertical positions = %i{finalPosition.Depth * finalPosition.HorizontalPosition}"
