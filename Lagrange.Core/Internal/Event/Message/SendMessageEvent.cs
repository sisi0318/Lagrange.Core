using Lagrange.Core.Message;
using Lagrange.Core.Internal.Packets.Message;

#pragma warning disable CS8618

namespace Lagrange.Core.Internal.Event.Message;

internal class SendMessageEvent : ProtocolEvent
{
    public readonly MessageChain Chain;

    public readonly PushMsgBody? PushMsgBody;

    public readonly MessageBody? MessageBody;

    public readonly MessageResult MsgResult;
    
    protected SendMessageEvent(MessageChain chain) : base(true)
    {
        Chain = chain;
    }
    
    protected SendMessageEvent(MessageChain chain, MessageBody body) : base(true)
    {
        Chain = chain;
        MessageBody = body;
    }
    
    protected SendMessageEvent(MessageChain chain, PushMsgBody pushMsgBody) : base(true)
    {
        Chain = chain;
        PushMsgBody = pushMsgBody;
    }

    protected SendMessageEvent(int resultCode, MessageResult msgResult) : base(resultCode)
    {
        MsgResult = msgResult;
    }
    
    public static SendMessageEvent Create(MessageChain chain) => new(chain);
    
    public static SendMessageEvent Create(MessageChain chain, PushMsgBody pushMsgBody) => new(chain, pushMsgBody);
    
    public static SendMessageEvent Create(MessageChain chain, MessageBody body) => new(chain, body);
    
    public static SendMessageEvent Result(int resultCode, MessageResult msgResult) => new(resultCode, msgResult);
}