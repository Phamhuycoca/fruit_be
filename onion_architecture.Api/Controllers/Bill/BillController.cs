using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onion_architecture.Application.Common.ZaloPay;
using onion_architecture.Application.Dto.Bill;
using onion_architecture.Application.Dto.Bill_Detail;
using onion_architecture.Application.Helper;
using onion_architecture.Application.IService;
using onion_architecture.Domain.Entity;
using onion_architecture.Domain.Repositories;
using onion_architecture.Infrastructure.Exceptions;
using onion_architecture.Infrastructure.Migrations;
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
        private readonly IPaymentsService _paymentsService;
        private readonly IBill_DetailRepository _bill_DetailRepository;
        private readonly IBill_DetailService _bill_DetailService;
        private readonly ICartRepository _cartRepository;
        private readonly IFruitRepository _fruitRepository;
        public BillController(IBillService billService, IVnPayService vnPayService, IPaymentsService paymentsService, IBill_DetailRepository bill_DetailRepository, IBill_DetailService bill_DetailService, ICartRepository cartRepository, IFruitRepository fruitRepository)
        {
            _billService = billService;
            _vpnPayService = vnPayService;
            _paymentsService = paymentsService;
            _bill_DetailRepository = bill_DetailRepository;
            _bill_DetailService = bill_DetailService;
            _cartRepository = cartRepository;
            _fruitRepository = fruitRepository;
        }
        [HttpPost("Pay")]
        public IActionResult Pay([FromBody] BillDto dto)
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
                var rq = _vpnPayService.CreatePaymentUrl(HttpContext, vnPayModel);
                dto.Bill_Status = 1;
                var bill = _billService.Create(dto);
                foreach (var item in _paymentsService.CartItems())
                {
                        var bill_detail = new Bill_DetailDto()
                        {
                            BillId = bill.Data.BillId,
                            FruitId = item.FruitId,
                            Quantity = item.Quantity,
                            StoreId=_fruitRepository.GetById(item.FruitId).StoreId,
                        };
                        _bill_DetailService.Create(bill_detail);
                    _cartRepository.Delete(item.CartId);
                }
                _paymentsService.RemoveAll();
                return Ok(new { data = rq, success = true, message = "Vui lòng quét mã" });

            }
            else
            {
                dto.Bill_Status = 0;
                var bill = _billService.Create(dto);
                foreach (var item in _paymentsService.CartItems())
                {
                    var bill_detail = new Bill_DetailDto()
                    {
                        BillId = bill.Data.BillId,
                        FruitId = item.FruitId,
                        Quantity = item.Quantity,
                        StoreId = _fruitRepository.GetById(item.FruitId).StoreId,
                    };
                    _bill_DetailService.Create(bill_detail);
                    _cartRepository.Delete(item.CartId);
                }
                _paymentsService.RemoveAll();
                return Ok(bill);
            }
        }
        [HttpGet]
        public IActionResult GetCart([FromQuery] CommonListQuery query)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (objId == null)
            {
                throw new ApiException(HttpStatusCode.FORBIDDEN, HttpStatusMessages.Forbidden);
            }
            return Ok(_billService.Items(query, long.Parse(objId)));
        }
        [HttpGet("ItemsStatus0")]
        public IActionResult ItemsStatus0([FromQuery] CommonListQuery query)
        {
            return Ok(_billService.ItemsStatus0(query));
        }

    }
}