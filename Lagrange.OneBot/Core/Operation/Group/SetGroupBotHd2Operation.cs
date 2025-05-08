using System.Text.Json;
using System.Text.Json.Nodes;
using Lagrange.Core;
using Lagrange.Core.Common.Interface.Api;
using Lagrange.OneBot.Core.Entity.Action;
using Lagrange.OneBot.Core.Operation.Converters;

namespace Lagrange.OneBot.Core.Operation.Group;

[Operation("send_group_bot_callback1")]
public class SetGroupBotHd2Operation : IOperation
{
    public async Task<OneBotResult> HandleOperation(BotContext context, JsonNode? payload)
    {
        var message = payload.Deserialize<OneBotSetGroupBotHd2>(SerializerOptions.DefaultOptions);

        if (message is {Data1: not null, Data2: not null})
        {
            bool _ = await context.SetGroupBotHd2(message.BotId, message.Data1, message.Data2);

            return new OneBotResult(message.BotId, 0, "ok");
        }

        throw new Exception();
    }
}
