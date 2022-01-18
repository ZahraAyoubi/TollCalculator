using RuleService.APIProject.DTOs;

namespace RuleService.APIProject.Repository
{
    public interface ICostTypeRepository
    {
        Task<IEnumerable<CostTypeDto>> Get();
        Task<CostTypeDto> Get(int id);
        Task<CostTypeDto> Add(CostTypeDto model);
        Task<CostTypeDto> Update(CostTypeDto model);
        Task<bool> Delete(int id);
    }
}
