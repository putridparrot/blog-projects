open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
 
[<EntryPoint>]
let main argv = 
 
    let app =
        choose
            // http://localhost:8080/hello
            [ GET >=> choose
                [ path "/hello" >=> OK "Hello GET"
                  path "/goodbye" >=> OK "Good bye GET" ]
              POST >=> choose
                [ path "/hello" >=> OK "Hello POST"
                  path "/goodbye" >=> OK "Good bye POST" ] ]
 
    startWebServer defaultConfig app
 
    0 // return an integer exit code