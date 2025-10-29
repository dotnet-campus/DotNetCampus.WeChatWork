using System.Text.Json.Serialization;

namespace DotNetCampus.WeChatWork.Robots.Models;

/// <summary>
/// 图像消息模型。
/// </summary>
internal record ImageMessageModel : RequestMessageModel
{
    /// <summary>
    /// 图像消息内容的 Base64 编码。
    /// </summary>
    [JsonPropertyName("base64")]
    public string? Base64 { get; init; }

    /// <summary>
    /// 图像消息内容（Base64 编码后）的 MD5 值。
    /// </summary>
    [JsonPropertyName("md5")]
    public string? Md5 { get; init; }
}
