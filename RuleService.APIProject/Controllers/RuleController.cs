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
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<object> GetById(int id)
        {
            try
            {
                var result = await _tollFeeRepository.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<object> Post([FromQuery] TollFeeDto newFee)
        {
           try
            {
                var model = await _tollFeeRepository.Add(newFee);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<object> Put([FromQuery] TollFeeDto newFee)
        {
            try
            {
                var model = await _tollFeeRepository.Update(newFee);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                await _tollFeeRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
