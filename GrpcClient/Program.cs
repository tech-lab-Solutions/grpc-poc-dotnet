using Grpc.Net.Client;
using GrpcServer;

Console.WriteLine("Starting GrpcClient...");

using var channel = GrpcChannel.ForAddress("http://localhost:5109");

var client = new GrpcService.GrpcServiceClient(channel);

var reply = await client.SayHelloAsync(new HelloRequest { Name = "Shivani" });

Console.WriteLine("Greeting: " + reply.Message);
