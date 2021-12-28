using Microsoft.AspNetCore.Mvc;
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
        public ServiceResponse GetTollFee(string vehicle, [FromQuery] DateTime[] dates)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                var result = _tollCalculator.GetTollFee(new VehicleType { Name = vehicle }, dates);
                response.Data = result;
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
