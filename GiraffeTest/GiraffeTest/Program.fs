open Giraffe
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore
open Microsoft.Extensions.Logging
 
// code for blog post http://putridparrot.com/blog/using-giraffe-as-a-service-pipeline-in-kestrel/

let helloName name = text (sprintf "Hello %s" name)

let webApp =
    choose [
        GET >=>
            choose [
                // case insensitive using anonymous function
                routeCif "/hello/%s" (fun name -> text (sprintf "Hello %s" name))
                route "/" >=> htmlFile "index.html"
                route "/error"  >=> setStatusCode 404
                route "/ping"   >=> text "pong"
                // case sensitive use function
                routef "/hello2/%s" helloName            
            ]
    ]
 
type Startup() =
    member this.ConfigureServices (services : IServiceCollection) =
        services.AddGiraffe() |> ignore
 
    member this.Configure (app : IApplicationBuilder) =
        app.UseGiraffe webApp
 
// log to console
let configureLogging (loggerBuilder : ILoggingBuilder) =
    loggerBuilder//.AddFilter(fun lvl -> lvl.Equals LogLevel.Error)
                 .AddConsole()
                 .AddDebug() |> ignore

[<EntryPoint>]
let main _ =
    WebHost.CreateDefaultBuilder()
        .UseKestrel()
        .UseStartup<Startup>()
        .ConfigureLogging(configureLogging)
        .Build()
        .Run()
    0