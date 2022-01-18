using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RuleService.APIProject.DbContexts;
using RuleService.APIProject.DTOs;
using RuleService.APIProject.Models;

namespace RuleService.APIProject.Repository
{
    public class TollFeeRepository : ITollFeeRepository
    {
        private ApplicationDbContext _dbContext;
        private IMapper _mapper;

        public TollFeeRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<TollFeeDto> Add(TollFeeDto newFee)
        {
            TollFee fee = _mapper.Map<TollFeeDto, TollFee>(newFee);

            _dbContext.TollFees.Add(fee);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TollFee, TollFeeDto>(fee);
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var fee = await _dbContext.TollFees.FirstAsync(x => x.Id == id);

                if (fee == null)
                {
                    return false;
                }
                _dbContext.TollFees.Remove(fee);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<IEnumerable<TollFeeDto>> Get()
        {
            List<TollFee> fees = await _dbContext.TollFees.ToListAsync();
            return _mapper.Map<List<TollFeeDto>>(fees);
        }
        public async Task<TollFeeDto> Get(int id)
        {
            TollFee fee = await _dbContext.TollFees.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<TollFeeDto>(fee);
        }
        public async Task<TollFeeDto> Update(TollFeeDto newFee)
        {
            TollFee fee = await _dbContext.TollFees.FirstOrDefaultAsync(x => x.Id == newFee.Id);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
            }
            return _mapper.Map<TollFee, TollFeeDto>(fee);
        }
    }
}
