module QuickSort

let rec sort = function
    | [] ->  []
    | pivot::rest -> 
             rest |> List.partition(fun i -> i < pivot)
                 ||> fun left right ->  (sort left) @ [pivot] @ sort right