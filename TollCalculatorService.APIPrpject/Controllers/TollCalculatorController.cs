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
        public ServiceResponse GetTollFee([FromQuery] Vehicles vehicle, [FromQuery] DateTime[] dates)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                var result = _tollCalculator.GetTollFee(new VehicleType { Name = vehicle.ToString() }, dates);
                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMesseges
                     = new List<string>() { ex.ToString() };
            }
            return response;
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
