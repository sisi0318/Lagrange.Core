using System.Text.Json.Serialization;
using Lagrange.Core.Message;
using Lagrange.Core.Message.Entity;

namespace Lagrange.OneBot.Message.Entity;

[Serializable]
public partial class TextSegment(string text, string title = "", string desc = "", string picurl = "")
{
    public TextSegment() : this("", "", "", "") { }

    [JsonPropertyName("text")][CQProperty] public string Text { get; set; } = text;

    [JsonPropertyName("title")][CQProperty] public string Title { get; set; } = title;

    [JsonPropertyName("desc")][CQProperty] public string Desc { get; set; } = desc;

    [JsonPropertyName("picurl")][CQProperty] public string PicUrl { get; set; } = picurl;
}

[SegmentSubscriber(typeof(TextEntity), "text")]
public partial class TextSegment : SegmentBase
{
    public override void Build(MessageBuilder builder, SegmentBase segment)
    {
        if (segment is TextSegment textSegment)
        {
            if (!string.IsNullOrEmpty(textSegment.Title))
            {
                builder.Text(textSegment.Text, textSegment.Title, textSegment.Desc, textSegment.PicUrl);
            }
            else
            {
                builder.Text(textSegment.Text);
            }
        }
    }

    public override SegmentBase FromEntity(MessageChain chain, IMessageEntity entity)
    {
        if (entity is not TextEntity textEntity) throw new ArgumentException("Invalid entity type.");

        return new TextSegment(textEntity.Text, "", "", "");
    }
}