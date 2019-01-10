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
            Thread.Sleep(3000);

            Channel channel = new Channel("localhost", 5002, ChannelCredentials.Insecure);

            var msgClient = new MsgService.MsgServiceClient(channel);
            var reply = msgClient.GetSumAsync(new GetMsgNumRequest() { Num1 = 1, Num2 = 2 });
            Console.WriteLine(reply.ResponseAsync.Result.Sum);

            try
            {
                var reply2 = msgClient.TestExceptionAsync(new GetMsgNumRequest() { Num1 = 1, Num2 = 2 });
                Console.WriteLine(reply2.ResponseAsync.Result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            channel.ShutdownAsync().Wait(); 

            Console.ReadKey();
        }
    }
}
