using Microsoft.AspNetCore.Mvc;
using RuleService.APIProject.DTOs;
using RuleService.APIProject.Models;
using RuleService.APIProject.Repository;

namespace RuleService.APIProject.Controllers
{
    [ApiController]
    [Route("api/rule")]
    public class RuleController : ControllerBase
    {
        private IRuleRepository _tollFeeRepository;

        public RuleController(IRuleRepository tollFeeRepository)
        {
            _tollFeeRepository = tollFeeRepository;
        }

        [HttpGet]
        public async Task<ServiceResponse> Get()
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                var list = await _tollFeeRepository.GetAll();
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse> GetById(int id)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                response.Data = await _tollFeeRepository.GetById(id);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return response;
        }

        [HttpPost]
        public async Task<ServiceResponse> Post([FromQuery] TollFeeDto newFee)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                var model = await _tollFeeRepository.Add(newFee);
                response.Data = model;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return response;

        }

        [HttpPut]
        public async Task<ServiceResponse> Put([FromQuery] TollFeeDto newFee)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                var model = await _tollFeeRepository.Update(newFee);
                if (model != null)
                {
                    response.Data = model;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse> Delete(int id)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                response.Success = await _tollFeeRepository.Delete(id);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return response;
        }
    }
}
