using AutoMapper;
using RuleService.APIProject.DTOs;
using RuleService.APIProject.Models;

namespace RuleService.APIProject
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TollFee, TollFeeDto>();
            CreateMap<TollFeeDto, TollFee>();
            CreateMap<CostType, CostTypeDto>();
            CreateMap<CostTypeDto, CostTypeDto>();
        }
    }
}
