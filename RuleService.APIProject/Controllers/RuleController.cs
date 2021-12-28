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
        public async Task<object> Get()
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
        public async Task<object> GetById(int id)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                var toDo = await _tollFeeRepository.GetById(id);
                response.Data = toDo;
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
        public async Task<object> Post([FromBody] TollFeeDto newFee)
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
        public async Task<object> Put([FromBody] TollFeeDto newFee)
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
        public async Task<object> Delete(int id)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                var isSuccess = await _tollFeeRepository.Delete(id);
                response.Data = isSuccess;

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
