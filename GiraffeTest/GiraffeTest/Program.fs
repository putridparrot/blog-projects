open Giraffe
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore
 
// code for blog post http://putridparrot.com/blog/using-giraffe-as-a-service-pipeline-in-kestrel/

let webApp =
    choose [
        GET >=>
            choose [
                routeCif "/hello/%s" (fun name -> text (sprintf "Hello %s" name))
            ]
    ]
 
type Startup() =
    member this.ConfigureServices (services : IServiceCollection) =
        services.AddGiraffe() |> ignore
 
    member this.Configure (app : IApplicationBuilder) =
        app.UseGiraffe webApp
 
[<EntryPoint>]
let main _ =
    WebHost.CreateDefaultBuilder()
        .UseKestrel()
        .UseStartup<Startup>()
        .Build()
        .Run()
    0