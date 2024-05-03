using System.Text.Json.Nodes;
using Lagrange.Core;
using Lagrange.Core.Common.Interface.Api;
using Lagrange.OneBot.Core.Entity.Action;

namespace Lagrange.OneBot.Core.Operation.Generic;

[Operation("get_clientkey")]
public class GetClientKey : IOperation
{
    public async Task<OneBotResult> HandleOperation(BotContext context, JsonNode? payload)
    {
            string clientkey = await context.GetClientKey();
            return new OneBotResult(new JsonObject { { "clientkey", clientkey } }, 0, "ok");
    }
}
