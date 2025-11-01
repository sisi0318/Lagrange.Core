using Lagrange.Core.Message;
using Lagrange.Core.Internal.Packets.Message;

namespace Lagrange.Core.Internal.Event.Message;

internal class GetGroupMessageEvent : ProtocolEvent
{
    public uint GroupUin { get; }

    public ulong StartSequence { get; }

    public ulong EndSequence { get; }

    public List<MessageChain> Chains { get; } = new();

    public List<PushMsgBody> PushMsgBodies { get; } = new();

    private GetGroupMessageEvent(uint groupUin, ulong startSequence, ulong endSequence) : base(true)
    {
        GroupUin = groupUin;
        StartSequence = startSequence;
        EndSequence = endSequence;
    }

    private GetGroupMessageEvent(int resultCode, List<MessageChain> chains, List<PushMsgBody> bodies) : base(resultCode)
    {
        Chains = chains;
        PushMsgBodies = bodies;
    }
    private GetGroupMessageEvent(int resultCode, List<MessageChain> chains) : base(resultCode)
    {
        Chains = chains;
    }

    public static GetGroupMessageEvent Create(uint groupUin, ulong startSequence, ulong endSequence)
        => new(groupUin, startSequence, endSequence);

    public static GetGroupMessageEvent Result(int resultCode, List<MessageChain> chains, List<PushMsgBody> bodies)
        => new(resultCode, chains, bodies);

    public static GetGroupMessageEvent Result(int resultCode, List<MessageChain> chains)
        => new(resultCode, chains);
}