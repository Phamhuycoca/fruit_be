using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onion_architecture.Application.Dto.Category;
using onion_architecture.Application.Helper;
using onion_architecture.Application.IService;

namespace onion_architecture.Api.Controllers.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] CommonListQuery query)
        {
            return Ok(_categoryService.Items(query));
        }

        [HttpPost]
        public IActionResult Create(CategoryCreate dto)
        {
            return Ok(_categoryService.Create(dto));
        }

        [HttpPatch("{id}")]
        public IActionResult Update(CategoryCreate dto)
        {
            return Ok(_categoryService.Update(dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(_categoryService?.Delete(id));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_categoryService.GetById(id));
        }
    }
}
