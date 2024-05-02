using System.Text.Json.Nodes;
using Lagrange.Core;
using Lagrange.OneBot.Core.Notify;
using Lagrange.OneBot.Core.Entity.Action;

namespace Lagrange.OneBot.Core.Operation.Generic;

[Operation("get_skey")]
public class GetSkey : IOperation
{
    var cookies = await context.FetchCookies([domain]);
    return new OneBotResult(new JsonObject { { "skey", cookies] } }, 0, "ok");

}
