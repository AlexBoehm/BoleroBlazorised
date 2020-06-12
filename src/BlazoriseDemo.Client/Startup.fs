namespace BlazoriseDemo.Client

open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Bolero.Remoting.Client
open Blazorise
open Blazorise.Bootstrap
open Blazorise.Icons.FontAwesome
open Microsoft.Extensions.DependencyInjection
open System.Net.Http
open System

module Program =

    [<EntryPoint>]
    let Main args =
        let builder = WebAssemblyHostBuilder.CreateDefault(args)
        builder.RootComponents.Add<Main.MyApp>("#main")
        builder.Services.AddRemoting(builder.HostEnvironment) |> ignore

        let httpClient = new HttpClient ( BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))            

        builder.Services
            .AddBlazorise(fun options -> 
                options.ChangeTextOnKeyPress <- true
                ()
            )
            .AddBootstrapProviders()
            .AddFontAwesomeIcons()
            .AddSingleton(httpClient)
            |> ignore

        let host = builder.Build()

        host.Services
            .UseBootstrapProviders()
            .UseFontAwesomeIcons()
            |> ignore
        
        host.RunAsync() |> ignore
        0
