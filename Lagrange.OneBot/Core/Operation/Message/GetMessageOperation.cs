using System.Text.Json;
using System.Text.Json.Nodes;
using Lagrange.Core;
using Lagrange.Core.Common.Interface.Api;
using Lagrange.Core.Message;
using Lagrange.OneBot.Core.Entity.Action;
using Lagrange.OneBot.Core.Entity.Action.Response;
using Lagrange.OneBot.Core.Entity.Message;
using Lagrange.OneBot.Core.Operation.Converters;
using Lagrange.OneBot.Database;
using Lagrange.OneBot.Message;
using Lagrange.OneBot.Utility;

namespace Lagrange.OneBot.Core.Operation.Message;

[Operation("get_msg")]
public class GetMessageOperation(RealmHelper realm, MessageService service) : IOperation
{
    public async Task<OneBotResult> HandleOperation(BotContext context, JsonNode? payload)
    {
        if (payload.Deserialize<OneBotGetMessage>(SerializerOptions.DefaultOptions) is { } getMsg)
        {
            // 在一个 Realm 事务中完成所有操作，避免"closed realm"异常
            var chain = realm.Do<MessageChain?>(realm => {
                var record = realm.All<MessageRecord>().FirstOrDefault(record => record.Id == getMsg.MessageId);
                if (record == null) return null;
                return (MessageChain)record;
            });
            
            if (chain == null)
            {
                return new OneBotResult(null, 1, $"消息ID {getMsg.MessageId} 未找到");
            }

            OneBotSender sender = chain.Type switch
            {
                MessageChain.MessageType.Group =>
                    new(
                        chain.FriendUin,
                        (await context.FetchMembers((uint)chain.GroupUin!))
                            .FirstOrDefault(member => member.Uin == chain.FriendUin)?.MemberName ?? string.Empty
                    ),
                MessageChain.MessageType.Temp => new(chain.FriendUin, string.Empty),
                MessageChain.MessageType.Friend =>
                    new(
                        chain.FriendUin,
                        (await context.FetchFriends())
                            .FirstOrDefault(friend => friend.Uin == chain.FriendUin)?.Nickname ?? string.Empty
                    ),
                _ => throw new NotImplementedException(),
            };

            var elements = service.Convert(chain);
            var response = new OneBotGetMessageResponse(
                chain.Time,
                chain.Type == MessageChain.MessageType.Group ? "group" : "private",
                MessageRecord.CalcMessageHash(chain.MessageId, chain.Sequence),
                sender,
                elements,
                chain.Sequence,
                chain.Appid
            );

            return new OneBotResult(response, 0, "ok");
        }

        throw new Exception();
    }
}
