/*
Author: Scott Grizzell
Date: 4/6/2026
Desc: Main UI for ODIN application allowing users to query and update data on the countys
various justice involved individuals.
 */

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web;
using Web.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<JwtAuthorizationHandler>();

builder.Services.AddHttpClient("GatewayClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7152"); 
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddScoped(sp =>
    {
        var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
        var client = httpClientFactory.CreateClient("GatewayClient");
        return new Offenders(client);
    });

await builder.Build().RunAsync();
