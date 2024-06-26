using ProtoBuf;

namespace Lagrange.Core.Internal.Packets.Service.Oidb.Request;

// ReSharper disable InconsistentNaming
#pragma warning disable CS8618

[ProtoContract]
[OidbSvcTrpcTcp(0x907D, 1)]
internal class OidbSvcTrpcTcp0x907D_1
{
    [ProtoMember(1)] public uint Uin { get; set; }
    
    [ProtoMember(2)] public int type { get; set; } = 2;
    
    [ProtoMember(3)] public bool On { get; set; }

    [ProtoMember(4)] public uint GroupUin { get; set; }
}