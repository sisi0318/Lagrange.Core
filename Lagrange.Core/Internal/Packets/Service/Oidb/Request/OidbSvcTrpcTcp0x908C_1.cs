using ProtoBuf;

namespace Lagrange.Core.Internal.Packets.Service.Oidb.Request;

// ReSharper disable InconsistentNaming
#pragma warning disable CS8618

[ProtoContract]
[OidbSvcTrpcTcp(0x908C, 1)]
internal class OidbSvcTrpcTcp0x908C_1
{
    [ProtoMember(3)] public uint AppId { get; set; }

    [ProtoMember(5)] public string ButtonId { get; set; }

    [ProtoMember(6)] public string ButtonData { get; set; }
    
    [ProtoMember(10)] public uint Field10 { get; set; } = 5;
}