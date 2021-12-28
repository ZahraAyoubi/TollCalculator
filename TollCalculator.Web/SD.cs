namespace TollCalculator.Web
{
    public static class SD
    {
        public static string RuleAPIListBase { get; set; }
        public static string TollCalculatorAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
