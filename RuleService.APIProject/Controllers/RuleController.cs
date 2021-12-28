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
            try
            {
                var list = await _tollFeeRepository.GetAll();
                _response.Data = list;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id}")]
        public async Task<object> GetById(int id)
        {
            try
            {
                var toDo = await _tollFeeRepository.GetById(id);
                _response.Data = toDo;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] TollFeeDto newFee)
        {
            try
            {
                var model = await _tollFeeRepository.Add(newFee);
                _response.Data = model;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPut]
        public async Task<object> Put([FromBody] TollFeeDto newFee)
        {
            try
            {
                var model = await _tollFeeRepository.Update(newFee);
                if (model != null)
                {
                    _response.Data = model;
                }
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var isSuccess = await _tollFeeRepository.Delete(id);
                _response.Data = isSuccess;

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
