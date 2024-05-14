using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onion_architecture.Application.Dto;
using onion_architecture.Application.Helper;
using onion_architecture.Application.IService;

namespace onion_architecture.Api.Controllers.Payments
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentsService;
        public PaymentsController(IPaymentsService paymentsService)
        {
            _paymentsService = paymentsService;
        }
        [HttpGet]
        public IActionResult Payments([FromQuery] CommonListQuery query)
        {
            return Ok(_paymentsService.Items(query));
        }
        [HttpPost("AddToPayment")]
        public IActionResult AddToPayment([FromBody] PaymentsItem payments)
        {
            return Ok(_paymentsService.Payments(payments));
        }
        [HttpDelete("DeleteToPayment/{id}")]
        public IActionResult DeleteToPayment(long id)
        {
            return Ok(_paymentsService.Remove(id));
        }
    }
}
