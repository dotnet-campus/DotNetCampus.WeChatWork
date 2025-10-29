using System.Runtime.Serialization;

namespace DotNetCampus.WeChatWork.Robots.Models
{
    [DataContract]
    public class ResponseModel
    {
        [DataMember(Name = "errcode")]
        public int ErrorCode { get; set; }

        [DataMember(Name = "errmsg")]
        public string ErrorMessage { get; set; }
    }
}
