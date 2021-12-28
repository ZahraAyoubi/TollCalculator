using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TollCalculator.Web.DTOs;
using TollCalculator.Web.Models;
using TollCalculator.Web.Services.IServices;

namespace TollCalculator.Web.Controllers
{
    public class TollCalculatorController : Controller
    {
        //private readonly IRuleService _ruleService;

        //public TollCalculatorController(IRuleService ruleService)
        //{
        //    _ruleService = ruleService;
        //}
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TollCalculator()
        {
            //List<TollFeeDto> tollFees = new List<TollFeeDto>();
            //var response = await _ruleService.GetAllAsync<ServiceResponse>();
            //if (response != null && response.Success)
            //{
            //    tollFees = JsonConvert.DeserializeObject<List<TollFeeDto>>(Convert.ToString(response.Data));
            //}

            //return View(tollFees);
            return View();
        }

        //public async Task<List<VehicleTypeDto>> GetVehicle()
        //{
        //    List<VehicleTypeDto> vehicles = new List<VehicleTypeDto>();
        //    var response = await _ruleService.GetAllAsync<ServiceResponse>();
        //    if (response != null && response.Success)
        //    {
        //        vehicles = JsonConvert.DeserializeObject<List<VehicleTypeDto>>(Convert.ToString(response.Data));
        //    }

        //    return vehicles;
        //}


    }
}
