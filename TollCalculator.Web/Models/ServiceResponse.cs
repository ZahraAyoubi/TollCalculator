namespace TollCalculator.Web.Models
{
    public class ServiceResponse
    {
        public object Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
        public List<string> ErrorMesseges { get; set; }
    }
}
