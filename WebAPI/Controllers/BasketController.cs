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
            Basket? DTO = this._context.Baskets
                .GetAll().Where(x => x.Id == id)
                .Include(x => x.User)
                .Include(x => x.CartLines)
                .Include(x => x.BillingAddress)
                .Include(x => x.ShippingAddress)
                .Include(x => x.PaymentProvider)
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
        
        [HttpPost("/addtocart/{id:int}")]
        public async Task<IActionResult> AddToCart(int id, int productId, int qty = 1)
        {
            Basket? basket = await this._context.Baskets.GetById(id);
            if (basket == null)
            {
                return NotFound();
            }
            Product? product = await this._context.Products.GetById(productId);
            if (product == null)
            {
                return NotFound();
            }
            this._context.Baskets.AddToBasket(basket, product, qty);
            return Ok();
        }
        
        [HttpPost("/updateqty/{id:int}")]
        public async Task<IActionResult> UpdateQty(int id, int basketItemId, int qty = 1)
        {
            Basket? basket = await this._context.Baskets.GetById(id);
            if (basket == null)
            {
                return NotFound();
            }
            BasketItem? basketItem = await this._context.BasketItems.GetById(basketItemId);
            if (basketItem == null)
            {
                return NotFound();
            }
            this._context.Baskets.UpdateQty(basket, basketItem, qty);
            return Ok();
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
