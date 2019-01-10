using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcService.Protocol;

namespace GrpcService.Impl
{
    public class MsgServiceImpl : GrpcService.Protocol.MsgService.MsgServiceBase
    {
        public override Task<GetMsgSumReply> GetSum(GetMsgNumRequest request, ServerCallContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                return new GetMsgSumReply() { Sum = 100 };
            });
        }
    }
}
