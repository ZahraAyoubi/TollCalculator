using Microsoft.AspNetCore.Mvc;
using RuleService.APIProject.DTOs;
using RuleService.APIProject.Repository;

namespace RuleService.APIProject.Controllers
{
    [ApiController]
    [Route("api/cost")]
    public class CostTypeController : Controller
    {
        private ICostTypeRepository _costTypeRepository;

        public CostTypeController(ICostTypeRepository costTypeRepository)
        {
            _costTypeRepository = costTypeRepository;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var list = await _costTypeRepository.Get();
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
                var result = await _costTypeRepository.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<object> Post([FromQuery] CostTypeDto newCost)
        {
            try
            {
                var model = await _costTypeRepository.Add(newCost);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<object> Put([FromQuery] CostTypeDto newCost)
        {
            try
            {
                var model = await _costTypeRepository.Update(newCost);
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
                await _costTypeRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
