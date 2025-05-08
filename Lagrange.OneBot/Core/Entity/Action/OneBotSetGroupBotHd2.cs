using System.Text.Json.Serialization;

namespace Lagrange.OneBot.Core.Entity.Action;

[Serializable]
public class OneBotSetGroupBotHd2
{
    
    [JsonPropertyName("bot_id")] public uint BotId { get; set; }

    [JsonPropertyName("data1")] public string? Data1 { get; set; }

    [JsonPropertyName("data2")] public string? Data2 { get; set; }
    
}