using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onion_architecture.Application.Helper;
using onion_architecture.Application.IService;

namespace onion_architecture.Api.Controllers.Bill_Detaill
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bill_DetaillController : ControllerBase
    {
        private readonly IBill_DetailService _bill_detailService;
        public Bill_DetaillController(IBill_DetailService bill_detailService)
        {
            _bill_detailService = bill_detailService;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_bill_detailService.ItemsById(id));
        }
    }
}
