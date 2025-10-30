using DotNetCampus.WeChatWork.Robots.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace DotNetCampus.WeChatWork.Robots;

/// <summary>
/// 表示一个企业微信中的普通群聊机器人。
/// 普通群聊机器人指的是任何人都可以在群里创建的机器人。
/// </summary>
public sealed class ChatRobot
{
    private readonly string _webHookUrl;

    /// <summary>
    /// 创建一个企业微信群聊机器人。
    /// </summary>
    /// <param name="webHookUrl">在创建群聊机器人时会提示你 WebHoolUrl，在此传入即可。</param>
    public ChatRobot(string webHookUrl)
    {
        _webHookUrl = webHookUrl ?? throw new ArgumentNullException(nameof(webHookUrl));
    }

    /// <summary>
    /// 发送纯文本消息。
    /// </summary>
    /// <param name="text">要发送的纯文本消息正文。</param>
    /// <param name="mentions">要额外提及这些人。应该使用企业微信 Id 或者手机号，而不是姓名；可混合传入，会自动识别。</param>
    /// <returns>发送消息后的服务器响应。</returns>
    public Task<ResponseModel> SendTextAsync(string text, params string[] mentions)
    {
        var phoneList = mentions.Where(x => x.All(char.IsAsciiDigit)).ToList();
        return SendMessageAsync(new WeChatWorkMessageModel
        {
            MessageType = "text",
            Text = new TextMessageModel
            {
                Content = text,
                MentionedList = mentions,
                MentionedMobileList = phoneList,
            },
        });
    }

    /// <summary>
    /// 发送简化版的 Markdown 消息（企业微信仅支持 Markdown 子集，具体可参见企业微信创建机器人后的详情页）。
    /// </summary>
    /// <param name="markdown">要发送的 Markdown 消息正文。</param>
    /// <returns>发送消息后的服务器响应。</returns>
    public Task<ResponseModel> SendMarkdownAsync(string markdown) => SendMessageAsync(new WeChatWorkMessageModel
    {
        MessageType = "markdown",
        Markdown = new MarkdownMessageModel
        {
            Content = markdown,
        },
    });

    /// <summary>
    /// 发送 Base64 数据格式的图片消息。
    /// </summary>
    /// <param name="base64">Base64 数据正文。</param>
    /// <param name="md5">图片文件的 md5 校验值。</param>
    /// <returns>发送消息后的服务器响应。</returns>
    public Task<ResponseModel> SendImageFromBase64Async(string base64, string md5) => SendMessageAsync(new WeChatWorkMessageModel
    {
        MessageType = "image",
        Image = new ImageMessageModel
        {
            Base64 = base64,
            Md5 = md5,
        },
    });

    /// <summary>
    /// 发送图文消息。
    /// </summary>
    /// <param name="title">消息标题。</param>
    /// <param name="description">消息简介。</param>
    /// <param name="url">消息网址。</param>
    /// <param name="pictureUrl">附图网址。</param>
    /// <returns>发送消息后的服务器响应。</returns>
    public Task<ResponseModel> SendNewsAsync(string title, string description, string url, string pictureUrl) => SendMessageAsync(new WeChatWorkMessageModel
    {
        MessageType = "news",
        News = new NewsMessageModel
        {
            Articles = new List<NewsArticleModel>
            {
                new NewsArticleModel
                {
                    Title = title,
                    Description = description,
                    Url = url,
                    PictureUrl = pictureUrl,
                },
            },
        },
    });

    /// <summary>
    /// 发送通用格式的企业微信消息。
    /// </summary>
    /// <param name="message">要发送的消息体。</param>
    /// <returns>发送消息后的服务器响应。</returns>
    private async Task<ResponseModel> SendMessageAsync(WeChatWorkMessageModel message)
    {
        using var httpClient = new HttpClient();
        var content = JsonContent.Create(message, WeChatWorkRobotJsonContext.Default.WeChatWorkMessageModel);
        var response = await httpClient.PostAsync(_webHookUrl, content).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseObject = JsonSerializer.Deserialize(responseString, WeChatWorkRobotJsonContext.Default.ResponseModel);
            return responseObject ?? new ResponseModel
            {
                ErrorCode = -1,
                ErrorMessage = "无法解析服务器响应内容。",
            };
        }

        return new ResponseModel
        {
            ErrorCode = (int)response.StatusCode,
            ErrorMessage = response.StatusCode.ToString(),
        };
    }
}
