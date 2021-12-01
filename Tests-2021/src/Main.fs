module Tests_2021
open Expecto

[<EntryPoint>]
let main argv =
    let ignoreFinalArg = "--ignoreFinal"
    let findFinalFun = fun z -> (defaultConfig.joinWith.format z).EndsWith "Final" 

    match Impl.testFromThisAssembly() with
    | None -> 0
    | Some tests ->
        if argv |> Array.contains ignoreFinalArg then
            testList "All" [
                tests |> Test.filter defaultConfig.joinWith.asString findFinalFun
                ptestList "Final" [ 
                    tests |> Test.filter defaultConfig.joinWith.asString (findFinalFun >> not)
                ]
            ]
        else tests
        |> runTestsWithCLIArgs [] (argv |> Array.except [ignoreFinalArg])