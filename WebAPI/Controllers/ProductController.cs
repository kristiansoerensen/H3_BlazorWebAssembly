using DataLayer.Data;
using DataLayer.DTOs;
using DataLayer.Entities;
using DataLayer.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IDataContext context, ILogger<ProductController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product? DTO = this._context.Products
                .GetAll().Where(x => x.Id == id)
                .Include(p => p.ProductCategories)
                .Include(p => p.Images)
                .FirstOrDefault();
            if (DTO == null)
            {
                return NotFound();
            }
            return Ok(DTO);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO? DTO)
        {
            if ( DTO == null )
            {
                return NoContent();
            }
            Product item = DTO.FromDTO();
            await this._context.Products.Add(item);
            await this._context.CommitAsync();
            return Ok(item.Id);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDTO? productDTO)
        {
            if (productDTO == null)
            {
                return NoContent();
            }
            Product product = productDTO.FromDTO();
            this._context.Products.Update(product);
            await this._context.CommitAsync();
            return Ok();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            Product? product = await this._context.Products.GetById(id);
            if ( product == null )
            {
                return;
            }
            this._context.Products.Delete(product);
            await this._context.CommitAsync();
        }
    }
}
