namespace TollCalculator.Web.Services.IServices
{
    public interface ITollCalculateService : IBaseService
    {
        Task<T> Get<T>(string vehicle, DateTime[] dates);
    }
}
