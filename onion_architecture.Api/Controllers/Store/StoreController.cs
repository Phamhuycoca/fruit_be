using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onion_architecture.Application.Dto.Category;
using onion_architecture.Application.Dto.Store;
using onion_architecture.Application.Helper;
using onion_architecture.Application.IService;
using onion_architecture.Application.Service;

namespace onion_architecture.Api.Controllers.Store
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] CommonListQuery query)
        {
            return Ok(_storeService.Items(query));
        }

        [HttpPost]
        public IActionResult Create(StoreDto dto)
        {
            return Ok(_storeService.Create(dto));
        }

        [HttpPatch("{id}")]
        public IActionResult Update(StoreDto dto)
        {
            return Ok(_storeService.Update(dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok(_storeService?.Delete(id));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_storeService.GetById(id));
        }
    }
}
