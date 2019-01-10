using System;
using System.Threading;
using Grpc.Core;
using GrpcService.Protocol;


namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("localhost", 5002, ChannelCredentials.Insecure);

            var msgClient = new MsgService.MsgServiceClient(channel);
            var reply = msgClient.GetSumAsync(new GetMsgNumRequest() { Num1 = 1, Num2 = 2 });
            Console.WriteLine(reply.ResponseAsync.Result.Sum);

            channel.ShutdownAsync().Wait();

            Console.ReadKey();
        }
    }
}
