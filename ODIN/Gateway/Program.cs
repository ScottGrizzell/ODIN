/*
Author: Scott Grizzell
Date: 4/6/2026
Desc: Reverse proxy for routing API requests from the frontend ODIN application
to different assosicated microservices. Hopefully in the future this will be used
for talking to mock third party APIs like Enterprise One or the DOR
 */

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7241")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("FrontendPolicy");
app.MapReverseProxy();

app.Run();
