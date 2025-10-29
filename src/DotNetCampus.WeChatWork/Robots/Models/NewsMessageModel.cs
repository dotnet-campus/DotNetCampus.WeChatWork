using System.Text.Json.Serialization;

namespace DotNetCampus.WeChatWork.Robots.Models;

/// <summary>
/// 图文消息模型。
/// </summary>
internal record NewsMessageModel : RequestMessageModel
{
    /// <summary>
    /// 图文消息列表。
    /// </summary>
    [JsonPropertyName("articles")]
    public IReadOnlyList<NewsArticleModel>? Articles { get; init; }
}

/// <summary>
/// 图文消息中的单个文章模型。
/// </summary>
internal class NewsArticleModel
{
    /// <summary>
    /// 标题。
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// 描述。
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// 点击后跳转的链接。
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    /// <summary>
    /// 图片链接。
    /// </summary>
    [JsonPropertyName("picurl")]
    public string? PictureUrl { get; init; }
}
