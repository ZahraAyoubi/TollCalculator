using TollCalculator.Web.Models;

namespace TollCalculator.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ServiceResponse ResponseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest request);
    }
}
