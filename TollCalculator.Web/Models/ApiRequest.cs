using static TollCalculator.Web.SD;

namespace TollCalculator.Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }
        public string ApiUrl { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
