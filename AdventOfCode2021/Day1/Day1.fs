module Day1

type DepthState =
    { PreviousDepth: Option<int>
      IncreasedDepthCount: int }

let countIncreasedDepths state depth =
    match state.PreviousDepth with
    | Some previousDepth when depth > previousDepth ->
        { state with
              IncreasedDepthCount = state.IncreasedDepthCount + 1
              PreviousDepth = Some depth }
    | _ ->
        { state with
              PreviousDepth = Some depth }