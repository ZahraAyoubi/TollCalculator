using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TollCalculator.Web.DTOs;
using TollCalculator.Web.Models;
using TollCalculator.Web.Services.IServices;

namespace TollCalculator.Web.Controllers
{
    public class RuleController : Controller
    {
        private readonly IRuleService _ruleService;

        public RuleController(IRuleService ruleService)
        {
          _ruleService = ruleService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
