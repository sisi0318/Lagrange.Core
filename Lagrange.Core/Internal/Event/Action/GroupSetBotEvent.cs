namespace Lagrange.Core.Internal.Event.Action;

internal class GroupSetBotEvent : ProtocolEvent
{
    public uint BotId { get; set; }
    
    public uint On { get; set; }
    
    public uint GroupUin { get; set; }

    private GroupSetBotEvent(uint BotId, uint On, uint GroupUin) : base(0)
    {
        BotId = BotId;
        On = On;
        GroupUin = GroupUin;
    }

    private GroupSetBotEvent(int resultCode) : base(resultCode) { }
    
    public static GroupSetBotEvent Create(uint BotId, uint On, uint GroupUin) => new(BotId, On, GroupUin);

    public static GroupSetBotEvent Result(int resultCode) => new(resultCode);
}