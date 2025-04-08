using Lagrange.Core.Common;
using Lagrange.Core.Internal.Event.Action;
using Lagrange.Core.Internal.Packets.Service.Oidb;
using Lagrange.Core.Internal.Packets.Service.Oidb.Request;
using Lagrange.Core.Utility.Extension;

namespace Lagrange.Core.Internal.Service.Action;

[EventSubscribe(typeof(GroupSetBotHd2Event))]
[Service("OidbSvcTrpcTcp.0x908c_1")]
internal class GroupSetBotHd2Service : BaseService<GroupSetBotHd2Event>
{
    protected override bool Build(GroupSetBotHd2Event input, BotKeystore keystore, BotAppInfo appInfo,
        BotDeviceInfo device, out Span<byte> output, out List<Memory<byte>>? extraPackets)
    {
        var packet = new OidbSvcTrpcTcpBase<OidbSvcTrpcTcp0x908C_1>(new OidbSvcTrpcTcp0x908C_1
        {
            AppId = input.AppId,
            ButtonId = input.ButtonId,
            ButtonData = input.ButtonData,
        });
        output = packet.Serialize();
        extraPackets = null;
        return true;
    }
}