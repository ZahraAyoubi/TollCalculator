using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RuleService.APIProject.DbContexts;
using RuleService.APIProject.DTOs;
using RuleService.APIProject.Models;

namespace RuleService.APIProject.Repository
{
    public class CostTypeRepository : ICostTypeRepository
    {
        private ApplicationDbContext _dbContext;
        private IMapper _mapper;
        private CostType costType;
        public CostTypeRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            costType = new CostType();
        }
        public async Task<CostTypeDto> Add(CostTypeDto model)
        {
            costType = _mapper.Map<CostTypeDto,CostType>(model);
            _dbContext.CostTypes.Add(costType);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CostType,CostTypeDto>(costType);
        }

        public async Task Delete(int id)
        {
            costType = await _dbContext.CostTypes.FirstAsync(x => x.Id == id);
            _dbContext.CostTypes.Remove(costType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CostTypeDto>> Get()
        {
            List<CostType> costTypes = await _dbContext.CostTypes.ToListAsync();
            return _mapper.Map<List<CostTypeDto>>(costTypes);
        }

        public async Task<CostTypeDto> Get(int id)
        {
            costType = await _dbContext.CostTypes.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CostTypeDto>(costType);
        }

        public async Task<CostTypeDto> Update(CostTypeDto model)
        {
            costType = await _dbContext.CostTypes.FirstOrDefaultAsync(x => x.Id == model.Id);
            try
            {
                costType.Cost = model.Cost;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
            }
            return _mapper.Map<CostType, CostTypeDto>(costType);
        }
    }
}
