open System

let atoiWithError (input : string) : double option =
    match Double.TryParse(input) with
    | true, n -> Some n
    | _ -> printf "[ERROR] Invalid number: `%s`" input
           exit 1

[<EntryPoint>]
let main (args : string[]) =
    printfn "Input the data (numbers only, seperated by a `,`)"
    let data = Console.ReadLine().Split(',') 
             |> Array.map (fun x -> atoiWithError(x).Value)
             |> Array.toList
             |> QuickSort.sort
    
    let table = new Analyze.Table(data)
 
    printfn "-----------------"
    printfn "Sorted array: %A" data
    printfn "-----------------"
    Analyze.tablePrint &table
    printfn "-----------------"
    Analyze.printAnalyzedData &table
    0