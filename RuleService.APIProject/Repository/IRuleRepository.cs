using RuleService.APIProject.DTOs;

namespace RuleService.APIProject.Repository
{
    public interface IRuleRepository
    {
        Task<IEnumerable<TollFeeDto>> GetAll();
        Task<TollFeeDto> GetById(int id);
        Task<TollFeeDto> Add(TollFeeDto newFee);
        Task<TollFeeDto> Update(TollFeeDto newFee);
        Task<bool> Delete(int id);
    }
}
