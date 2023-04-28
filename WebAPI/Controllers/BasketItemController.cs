using DataLayer.Data;
using DataLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer.ExtensionMethods;
using DataLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketItemController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<BasketItemController> _logger;
        public BasketItemController(IDataContext context, ILogger<BasketItemController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            BasketItemDTO? DTO = this._context.BasketItems
                .GetAll().Where(x => x.Id == id)
                .Include(x => x.Basket)
                .Include(x => x.Product)
                .ToDTOs()
                .FirstOrDefault();
            if (DTO == null)
            {
                return NotFound();
            }
            return Ok(DTO);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            BasketItem? item = await this._context.BasketItems.GetById(id);
            if (item == null)
            {
                return;
            }
            this._context.BasketItems.Delete(item);
            await this._context.CommitAsync();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BasketItemDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            BasketItem item = DTO.FromDTO();
            await this._context.BasketItems.Add(item);
            await this._context.CommitAsync();
            return Ok(item.Id);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BasketItemDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            BasketItem item = DTO.FromDTO();
            this._context.BasketItems.Update(item);
            await this._context.CommitAsync();
            return Ok();
        }
    }
}
