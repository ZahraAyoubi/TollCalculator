using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using TollCalculatorService.APIPrpject.Models;
using TollCalculatorService.APIPrpject.Repository;

namespace TollCalculatorService.APIPrpject.Controllers
{
    [ApiController]
    [Route("api/tollcalculator")]
    public class TollCalculatorController : ControllerBase
    {
        private ITollCalculatorRepository _tollCalculator;

        public TollCalculatorController(ITollCalculatorRepository tollCalculator)
        {
            _tollCalculator = tollCalculator;
        }
        [HttpGet]
        public object GetTollFee([FromQuery] Vehicles vehicle, [FromQuery] DateTime[] dates)
        {
            try
            {
                var result = _tollCalculator.GetTollFee(new VehicleType { Name = vehicle.ToString() }, dates);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Vehicles
        {
            car,
            motorbike ,
            tractor ,
            emergency ,
            diplomat ,
            foreign ,
            military 
        }
    }
}
