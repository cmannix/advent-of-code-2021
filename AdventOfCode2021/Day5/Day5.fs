module Day5


type Point =
    { X: int
      Y: int }

type Line =
    {
        Start: Point
        End: Point
    }

let isHorizontal line = line.Start.X = line.End.X
let isVertical line = line.Start.Y = line.End.Y

let getHorizontalOrVerticalPointsOnLine line =
    if isHorizontal line then
        [ for i in min line.Start.Y line.End.Y .. max line.Start.Y line.End.Y -> { X = line.End.X; Y = i } ]
    else if isVertical line then
        [ for i in min line.Start.X line.End.X .. max line.Start.X line.End.X -> { X = i; Y = line.End.Y } ]
    else []

let parseLineLines (input: seq<string>) =
    input
    |> Seq.map (fun inputLine -> inputLine.Split(" -> "))
    |> Seq.map (fun lineElements -> lineElements |> (Array.map (fun element -> element.Split(","))) |> Array.map (fun coords -> {X = int coords[0]; Y = int coords[1]}))
    |> Seq.map (fun linePoints -> { Start = linePoints[0]; End = linePoints[1]})

let rec countLinePoints coveredPoints linePoints =
    match linePoints with
    | point :: remainingPoints ->
                countLinePoints
                    (Map.change
                        point
                        (fun point ->
                            match point with
                            | Some count -> Some(count + 1)
                            | None -> Some(1))
                        coveredPoints)
                    remainingPoints
    | [] -> coveredPoints
