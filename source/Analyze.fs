module Analyze

let listToFreqMap (listToProc : double list) : Map<double, int> =
    let mutable map : Map<double, int> = Map.empty

    listToProc |> List.iter(
        fun value -> if not (map.ContainsKey value) then
            map <- map.Add(value, int (listToProc |> List.filter(fun fil -> fil = value) |> List.length)))

    map

type Table = 
    struct
        val list : double list
        val size : int
        val freq : Map<double, int> (* number - freq *)

        new (inputList) = 
            {list = inputList; size = inputList.Length; freq = listToFreqMap(inputList);}
    end

let tablePrint (table : inref<Table>) =
    let freqarray = table.freq |> Map.keys |> Seq.toArray
    printfn "Value, Frequency, Comparative Frequency"
    for freq in freqarray do
        let value = table.freq.TryFind freq 
        printfn "%g %d %d/%d" freq value.Value value.Value table.size

let printAnalyzedData (table : inref<Table>) =
    let average = table.list |> List.average
    let median  = if table.size % 2 = 0 then
                    ((table.list.[int (float ((table.size + 1) / 2) + 0.5)] + table.list.[int (float ((table.size - 1) / 2) - 0.5)])) / 2.0
                  else
                    table.list.[int (float (table.size / 2) + 0.5)]
    
    let range   = (table.list |> List.max) - (table.list |> List.min)

    printfn "Average: %g" average
    printfn "Median:  %g" median
    printfn "Range:   %g" range 