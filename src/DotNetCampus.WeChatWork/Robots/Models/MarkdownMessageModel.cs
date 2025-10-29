using System.Runtime.Serialization;

namespace DotNetCampus.WeChatWork.Robots.Models
{
    [DataContract]
    public class MarkdownMessageModel : RequestMessageModel
    {
        [DataMember(Name = "content")]
        public string Content { get; set; }
    }
}
