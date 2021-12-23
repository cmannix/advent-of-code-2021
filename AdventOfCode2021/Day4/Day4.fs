module Day4

open System

type Board =
    { RowsAndColumns: array<Set<int>>
      HasWon: bool }

let applyNumber number board =
    let newRowsAndColumns =
        board.RowsAndColumns
        |> Array.map (Set.remove number)

    let hasWon =
        Array.exists Set.isEmpty newRowsAndColumns

    { board with
          HasWon = hasWon
          RowsAndColumns = newRowsAndColumns }

let parseBingoNumbers (input: string) =
    input.Split [| ',' |]
    |> Array.map int
    |> List.ofArray

let parseBoard (input: seq<string>) =
    let boardNumbers =
        input
        |> Seq.map (fun line -> line.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries))
        |> Seq.map (Array.map int)

    let rows = boardNumbers |> Seq.map Set.ofArray

    let cols =
        Seq.transpose boardNumbers |> Seq.map Set.ofSeq

    { RowsAndColumns = Array.ofSeq (Seq.append rows cols)
      HasWon = false }

let parseInput input =
    let numbers = parseBingoNumbers (Seq.head input)

    let remaining =
        Seq.skip 2 input
        |> Seq.filter (fun x -> not (String.IsNullOrWhiteSpace x))
        |> Seq.toList

    let rec accumulateBoards boardInput boards =
        match boardInput with
        | _ when not (List.isEmpty boardInput) ->
            accumulateBoards (List.skip 5 boardInput) (parseBoard (List.take 5 boardInput) :: boards)
        | [] -> boards
        | _ -> raise (invalidArg (nameof boardInput) "Unexpected input")

    let boards = accumulateBoards remaining List.Empty

    (numbers, boards)

let getScore board =
    board.RowsAndColumns
    |> Array.map Set.toArray
    |> Array.reduce Array.append
    |> Array.distinct
    |> Array.sum

type BoardState =
    { WinningBoard: option<Board>
      RemainingBoards: list<Board> }

let lastWinner boards =
    { WinningBoard =
          match boards with
          | [ lastBoard ] when lastBoard.HasWon -> Some(lastBoard)
          | _ -> None
      RemainingBoards = List.filter (fun b -> not b.HasWon) boards }

let firstWinner boards =
    { WinningBoard = List.tryFind (fun b -> b.HasWon) boards
      RemainingBoards = boards }

let rec callNumbers determineWinner numbers boards =
    match numbers with
    | calledNumber :: remainingNumbers ->
        match determineWinner (boards |> List.map (applyNumber calledNumber)) with
        | { WinningBoard = Some winningBoard } -> (calledNumber, getScore winningBoard)
        | { WinningBoard = None
            RemainingBoards = remainingBoards } -> callNumbers determineWinner remainingNumbers remainingBoards
    | [] -> raise (invalidOp "No winners!")
