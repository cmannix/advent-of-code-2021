open System.IO

let day1Result =
 File.ReadLines("Day1/input.txt")
 |> Seq.map int
 |> Seq.fold Day1.countIncreasedDepths { PreviousDepth = None; IncreasedDepthCount = 0 }
printfn $"Day 1: Count of increasing depths = %i{day1Result.IncreasedDepthCount}"
