using System.Text.Json.Serialization;

namespace DotNetCampus.WeChatWork.Robots.Models;

/// <summary>
/// 响应模型。
/// </summary>
public record ResponseModel
{
    /// <summary>
    /// 错误码。
    /// </summary>
    [JsonPropertyName("errcode")]
    public int ErrorCode { get; init; }

    /// <summary>
    /// 错误信息。
    /// </summary>
    [JsonPropertyName("errmsg")]
    public string? ErrorMessage { get; init; }
}
