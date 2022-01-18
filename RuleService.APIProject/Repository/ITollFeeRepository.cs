using RuleService.APIProject.DTOs;

namespace RuleService.APIProject.Repository
{
    public interface ITollFeeRepository
    {
        Task<IEnumerable<TollFeeDto>> Get();
        Task<TollFeeDto> Get(int id);
        Task<TollFeeDto> Add(TollFeeDto newFee);
        Task<TollFeeDto> Update(TollFeeDto newFee);
        Task<bool> Delete(int id);
    }
}
