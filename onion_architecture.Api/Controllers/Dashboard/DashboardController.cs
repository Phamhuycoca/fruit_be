using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onion_architecture.Application.IService;

namespace onion_architecture.Api.Controllers.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        [HttpGet("Store_Dashboard")]
        public IActionResult GetAction()
        {
            return Ok(_dashboardService.StoreDashboard());
        }
        [HttpGet("Bill_Dashboard")]
        public IActionResult Bill_Dashboard()
        {
            return Ok(_dashboardService.BillDashboard());
        }
    }
}
