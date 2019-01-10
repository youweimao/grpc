using Grpc.Core;
using System;
using GrpcService.Protocol;
using GrpcService.Impl;

namespace GrpcService.Hosting
{
    class Program
    {
        static int Port = 5002;

        static void Main(string[] args)
        {
            Server server = new Server()
            {
                Services = { MsgService.BindService(new MsgServiceImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };

            server.Start();

            Console.WriteLine("MsgService server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
