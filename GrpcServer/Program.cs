using GrpcServer.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5109, o => o.Protocols = HttpProtocols.Http2);

    options.ListenLocalhost(7055, o =>
    {
        o.Protocols = HttpProtocols.Http2;
        o.UseHttps();
    });
});

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<GrpcServiceImpl>();
app.MapGet("/", () => "Use gRPC client to talk to me!");

app.Run();
