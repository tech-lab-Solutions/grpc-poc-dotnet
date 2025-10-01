using Grpc.Core;

namespace GrpcServer.Services;

public class GrpcServiceImpl : GrpcService.GrpcServiceBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {

        Console.WriteLine($"[Server] Request Object: Name = {request.Name}");

        return Task.FromResult(new HelloReply
        {
            Message = $"Hello {request.Name}, from GrpcService!"
        });
    }
}
