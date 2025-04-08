namespace Lagrange.Core.Internal.Event.Action;

internal class GroupSetBotHd2Event : ProtocolEvent
{
    public uint AppId { get; set; }

    public string ButtonId { get; set; } = "";

    public string ButtonData { get; set; } = "";
    
    private GroupSetBotHd2Event(uint appId, string buttonId, string buttonData) : base(0)
    {
        AppId = appId;
        ButtonId = buttonId;
        ButtonData = buttonData;
    }

    private GroupSetBotHd2Event(int resultCode) : base(resultCode) { }
    
    public static GroupSetBotHd2Event Create(uint appId, string buttonId, string buttonData) => new(appId, buttonId, buttonData);
    
    public static GroupSetBotHd2Event Result(int resultCode) => new(resultCode);
}