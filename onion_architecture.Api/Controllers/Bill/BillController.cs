using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onion_architecture.Application.Common.ZaloPay;
using onion_architecture.Application.Dto.Bill;
using onion_architecture.Application.IService;
using onion_architecture.Infrastructure.Exceptions;
using onion_architecture.Infrastructure.Settings;
using System.Security.Claims;

namespace onion_architecture.Api.Controllers.Bill
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        private readonly IVnPayService _vpnPayService;
        public BillController(IBillService billService, IVnPayService vnPayService)
        {
            _billService = billService;
            _vpnPayService = vnPayService;
        }
        [HttpPost("Pay")]
        public IActionResult Pay([FromBody]BillDto dto)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (objId == null)
            {
                throw new ApiException(HttpStatusCode.FORBIDDEN, HttpStatusMessages.Forbidden);
            }
            dto.Bill_Status = 0;
            dto.UserId = long.Parse(objId);
            if (dto.Payments == "Thanh toán bằng VNPay")
            {
                var vnPayModel = new VnPaymentRequestModel
                {
                    Amount = dto.Total_amount,
                    CreatedDate = DateTime.Now,
                    Description = $"{dto.FullName} {dto.Phone}",
                    FullName = dto.FullName,
                    OrderId = new Random().Next(1000, 100000)
                };
                var rq=_vpnPayService.CreatePaymentUrl(HttpContext, vnPayModel);
                _billService.Create(dto);
                return Ok(new {data=rq,success=true,message="Vui lòng quét mã"});

            }
            else
            {
                return Ok(_billService.Create(dto));
            }
        }
    }
}
