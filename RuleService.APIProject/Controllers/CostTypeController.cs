using Microsoft.AspNetCore.Mvc;
using RuleService.APIProject.DTOs;
using RuleService.APIProject.Models;
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
        public async Task<ActionResult<IEnumerable<CostType>>> Get()
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
        public async Task<ActionResult<CostType>> GetById(int id)
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
        public async Task<ActionResult<CostType>> Post([FromQuery] CostTypeDto newCost)
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
        public async Task<ActionResult<CostType>> Put([FromQuery] CostTypeDto newCost)
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
        public async Task Delete(int id)
        {
            try
            {
                await _costTypeRepository.Delete(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }
    }
}
