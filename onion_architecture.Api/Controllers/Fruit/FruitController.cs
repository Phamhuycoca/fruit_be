using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onion_architecture.Application.Dto.Category;
using onion_architecture.Application.Dto.Fruit;
using onion_architecture.Application.Helper;
using onion_architecture.Application.IService;
using onion_architecture.Application.Service;
using System.Runtime.InteropServices;

namespace onion_architecture.Api.Controllers.Fruit
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitController : ControllerBase
    {
        private readonly IFruitService _fruitService;
        public FruitController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }
        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts([FromQuery] CommonListQueryProducts query) 
        {
            return Ok(_fruitService.Product(query));
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] CommonListQuery query)
        {
            return Ok(_fruitService.Items(query));
        }

        [HttpPost]
        public IActionResult Create([FromForm]FruitCreate dto)
        {
            return Ok(_fruitService.Create(dto));
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromForm] FruitCreate dto)
        {
            return Ok(_fruitService.Update(dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(_fruitService?.Delete(id));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_fruitService.GetById(id));
        }
        [HttpGet("ProductByStore/{id}")]
        public IActionResult ProductByStore([FromQuery] CommonListQueryProducts query,long id)
        {
            return Ok(_fruitService.ProductByStore(query,id));
        }
    }
}
