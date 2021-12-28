namespace TollCalculatorService.APIPrpject.Models
{
    public class ServiceResponse
    {
        public object Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } 
        public List<string> ErrorMesseges { get; set; }
    }
}
