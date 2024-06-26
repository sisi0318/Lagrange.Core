namespace Lagrange.Core.Internal.Event.Action;

internal class GroupSetBotEvent : ProtocolEvent
{
    public uint Uin { get; set; }
    
    public bool On { get; set; } = "";
    
    public uint GroupUin { get; set; }

    private GroupSetBotEvent(uint Uin, uint On, uint GroupUin) : base(0)
    {
        Uin = groupUin;
        On = On;
        GroupUin = GroupUin;
    }

    private GroupSetBotEvent(int resultCode) : base(resultCode) { }
    
    public static GroupSetBotEvent Create(uint Uin, bool On, uint GroupUin) => new(Uin, On, GroupUin);

    public static GroupSetBotEvent Result(int resultCode) => new(resultCode);
}