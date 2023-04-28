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
    public class BrandController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<BrandController> _logger;
        public BrandController(IDataContext context, ILogger<BrandController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            BrandDTO? DTO = this._context.Brands
                .GetAll().Where(x => x.Id == id)
                .Include(x => x.Products)
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
            Brand? item = await this._context.Brands.GetById(id);
            if (item == null)
            {
                return;
            }
            this._context.Brands.Delete(item);
            await this._context.CommitAsync();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BrandDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            Brand item = DTO.FromDTO();
            await this._context.Brands.Add(item);
            await this._context.CommitAsync();
            return Ok(item.Id);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BrandDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            Brand item = DTO.FromDTO();
            this._context.Brands.Update(item);
            await this._context.CommitAsync();
            return Ok();
        }
    }
}
