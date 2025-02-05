using Lagrange.Core.Internal.Packets.Message.Element;
using Lagrange.Core.Internal.Packets.Message.Element.Implementation;
using ProtoBuf;

namespace Lagrange.Core.Message.Entity;

[MessageElement(typeof(Text))]
public class TextEntity : IMessageEntity
{
    public string Text { get; set; }
    public string? Title { get; set; }
    public string? Desc { get; set; }
    public string? PicUrl { get; set; }

    public TextEntity() => Text = "";

    public TextEntity(string text) => Text = text;

    public TextEntity(string text, string title, string desc, string picurl)
    {
        Text = text;
        Title = title;
        Desc = desc;
        PicUrl = picurl;
    }

    IEnumerable<Elem> IMessageEntity.PackElement()
    {
        if (Title is not null)
        {
            byte[] UrlLink;
              using (var ms = new MemoryStream())
                {
                    // 序列化 Text.UrlLink 对象
                    Serializer.Serialize(ms, new Text.UrlLink
                    {
                        LinkBody = new Text.LinkBody
                        {
                            Title = Title,
                            Desc = Desc,
                            PicUrl = PicUrl
                        }
                    });
                    UrlLink = ms.ToArray();
                }
            return new Elem[] // explicit interface implementation
            {
                new() { Text = new Text {
                    Str = Text,
                    PbReserve = UrlLink
                } }
            };
        }
        else
        {
            return new Elem[] // explicit interface implementation
            {
            new() { Text = new Text { Str = Text, } }
            };
        }

    }

    IMessageEntity? IMessageEntity.UnpackElement(Elem elems)
    {
        return elems.Text is { Str: not null, Attr6Buf: null } or { Str: not null, Attr6Buf.Length: 0 }
            ? new TextEntity(elems.Text.Str)
            : null;
    }

    public string ToPreviewString()
    {
        return $"[Text]: {Text}";
    }

    public string ToPreviewText() => Text;
}