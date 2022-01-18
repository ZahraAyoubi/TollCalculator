using Microsoft.AspNetCore.Mvc;
using RuleService.APIProject.DTOs;
using RuleService.APIProject.Models;
using RuleService.APIProject.Repository;

namespace RuleService.APIProject.Controllers
{
    [ApiController]
    [Route("api/fee")]
    public class TollFeeController : ControllerBase
    {
        private ITollFeeRepository _tollFeeRepository;

        public TollFeeController(ITollFeeRepository tollFeeRepository)
        {
            _tollFeeRepository = tollFeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TollFee>>> Get()
        {
            try
            {
                var list = await _tollFeeRepository.Get();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TollFee>> GetById(int id)
        {
            try
            {
                var result = await _tollFeeRepository.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TollFee>> Post([FromQuery] TollFeeDto newFee)
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
        public async Task<ActionResult<TollFee>> Put([FromQuery] TollFeeDto newFee)
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
        public async Task Delete(int id)
        {
            try
            {
                await _tollFeeRepository.Delete(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }
    }
}
