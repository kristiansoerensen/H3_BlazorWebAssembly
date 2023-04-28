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
    public class BasketController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<BasketController> _logger;
        public BasketController(IDataContext context, ILogger<BasketController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            BasketDTO? DTO = this._context.Baskets
                .GetAll().Where(x => x.Id == id)
                .Include(x => x.User)
                .Include(x => x.CartLines)
                .Include(x => x.BillingAddress)
                .Include(x => x.ShippingAddress)
                .Include(x => x.PaymentProvider)
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
            Basket? item = await this._context.Baskets.GetById(id);
            if (item == null)
            {
                return;
            }
            this._context.Baskets.Delete(item);
            await this._context.CommitAsync();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BasketDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            Basket item = DTO.FromDTO();
            await this._context.Baskets.Add(item);
            await this._context.CommitAsync();
            return Ok(item.Id);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BasketDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            Basket item = DTO.FromDTO();
            this._context.Baskets.Update(item);
            await this._context.CommitAsync();
            return Ok();
        }
    }
}
