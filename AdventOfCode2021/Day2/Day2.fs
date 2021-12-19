module Day2

type Position = { HorizontalPosition: int; Depth: int; Aim: int }

type Command =
    | Forward of Amount: int
    | Up of Amount: int
    | Down of Amount: int
    
let private (|Prefix|_|) (p:string) (s:string) =
    if s.StartsWith(p) then
        Some(s.Substring(p.Length))
    else
        None
    
exception CommandParseError of string
let parseCommand (command: string) =
    match command with
    | Prefix "forward " amount -> amount |> int |> Forward
    | Prefix "up " amount -> amount |> int |> Up
    | Prefix "down " amount -> amount |> int |> Down
    | other -> raise (CommandParseError($"Unsupported command {other}"))

let updatePositionPart1 position command =
    match command with
    | Forward amount ->
        { position with
              HorizontalPosition = position.HorizontalPosition + amount }
    | Up amount ->
        { position with
              Depth = position.Depth - amount }
    | Down amount ->
        { position with
              Depth = position.Depth + amount }

let updatePositionPart2 position command =
    match command with
    | Forward amount ->
        { position with
              HorizontalPosition = position.HorizontalPosition + amount
              Depth = position.Depth + position.Aim * amount }
    | Up amount ->
        { position with
              Aim = position.Aim - amount }
    | Down amount ->
        { position with
              Aim = position.Aim + amount }
