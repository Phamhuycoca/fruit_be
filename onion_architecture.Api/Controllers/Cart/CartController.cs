using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onion_architecture.Application.Dto.Cart;
using onion_architecture.Application.Dto.Category;
using onion_architecture.Application.Helper;
using onion_architecture.Application.IService;
using onion_architecture.Application.Service;
using onion_architecture.Infrastructure.Exceptions;
using onion_architecture.Infrastructure.Settings;
using System.Security.Claims;

namespace onion_architecture.Api.Controllers.Cart
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] CommonListQuery query)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (objId == null)
            {
                throw new ApiException(HttpStatusCode.FORBIDDEN, HttpStatusMessages.Forbidden);
            }
            return Ok(_cartService.Items(query,long.Parse(objId)));
        }

        [HttpPost]
        public IActionResult Create(CartDto dto)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (objId == null)
            {
                throw new ApiException(HttpStatusCode.FORBIDDEN, HttpStatusMessages.Forbidden);
            }
            dto.UserId = long.Parse(objId);
            return Ok(_cartService.Create(dto));
        }

        [HttpPatch("{id}")]
        public IActionResult Update(CartDto dto)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (objId == null)
            {
                throw new ApiException(HttpStatusCode.FORBIDDEN, HttpStatusMessages.Forbidden);
            }
            dto.UserId = long.Parse(objId);
            return Ok(_cartService.Update(dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(_cartService?.Delete(id));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_cartService.GetById(id));
        }
    }
}
