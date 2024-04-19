using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onion_architecture.Application.Dto.Category;
using onion_architecture.Application.Dto.Fruit;
using onion_architecture.Application.Helper;
using onion_architecture.Application.IService;
using onion_architecture.Application.Service;

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
    }
}
