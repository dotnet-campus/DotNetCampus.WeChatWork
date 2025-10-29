using System.Text.Json.Serialization;
using DotNetCampus.WeChatWork.Robots.Models;

namespace DotNetCampus.WeChatWork.Robots;

[JsonSerializable(typeof(WeChatWorkMessageModel))]
[JsonSerializable(typeof(ResponseModel))]
internal partial class WeChatWorkRobotJsonContext : JsonSerializerContext;
