using System.Text.Json.Serialization;

namespace DotNetCampus.WeChatWork.Robots.Models;

/// <summary>
/// 文本消息模型。
/// </summary>
internal record TextMessageModel : RequestMessageModel
{
    /// <summary>
    /// 文本消息内容。
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }

    /// <summary>
    /// 被提及的成员列表。
    /// </summary>
    [JsonPropertyName("mentioned_list")]
    public IReadOnlyList<string>? MentionedList { get; init; }

    /// <summary>
    /// 被提及的手机号列表。
    /// </summary>
    [JsonPropertyName("mentioned_mobile_list")]
    public IReadOnlyList<string>? MentionedMobileList { get; init; }
}
