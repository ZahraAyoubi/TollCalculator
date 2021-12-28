namespace TollCalculator.Web.Services.IServices
{
    public interface IRuleService : IBaseService
    {
        Task<T> GetAllAsync<T>();
    }
}
