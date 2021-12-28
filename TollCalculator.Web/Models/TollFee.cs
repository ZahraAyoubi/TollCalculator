namespace TollCalculator.Web.Models
{
    public class TollFee
    {
        public int Id { get; set; }
        public string City { get; set; }
        public TimeSpan EventStart { get; set; }
        public TimeSpan EventEnd { get; set; }
        public int CostTypeId { get; set; }
    }
}
