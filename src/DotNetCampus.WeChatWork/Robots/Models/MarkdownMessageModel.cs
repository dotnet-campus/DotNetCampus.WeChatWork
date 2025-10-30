using System.Text.Json.Serialization;

namespace DotNetCampus.WeChatWork.Robots.Models;

/// <summary>
/// Markdown 消息模型。
/// </summary>
internal record MarkdownMessageModel : RequestMessageModel
{
    /// <summary>
    /// Markdown 消息内容。
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; init; }
}
