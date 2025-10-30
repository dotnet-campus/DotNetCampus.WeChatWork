using System.Text.Json.Serialization;

namespace DotNetCampus.WeChatWork.Robots.Models;

/// <summary>
/// 企业微信消息模型基类。
/// </summary>
internal record WeChatWorkMessageModel
{
    /// <summary>
    /// 消息类型。
    /// </summary>
    [JsonPropertyName("msgtype")]
    public required string MessageType { get; init; }

    /// <summary>
    /// 当 <see cref="MessageType"/> 为 image 时使用此属性。
    /// </summary>
    [JsonPropertyName("image")]
    public ImageMessageModel? Image { get; init; }

    /// <summary>
    /// 当 <see cref="MessageType"/> 为 markdown 时使用此属性。
    /// </summary>
    [JsonPropertyName("markdown")]
    public MarkdownMessageModel? Markdown { get; init; }

    /// <summary>
    /// 当 <see cref="MessageType"/> 为 news 时使用此属性。
    /// </summary>
    [JsonPropertyName("news")]
    public NewsMessageModel? News { get; init; }

    /// <summary>
    /// 当 <see cref="MessageType"/> 为 text 时使用此属性。
    /// </summary>
    [JsonPropertyName("text")]
    public TextMessageModel? Text { get; init; }
}
