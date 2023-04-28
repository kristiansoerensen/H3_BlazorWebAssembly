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
    public class CategoryController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(IDataContext context, ILogger<CategoryController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            CategoryDTO? DTO = this._context.Categories
                .GetAll().Where(x => x.Id == id)
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Product)
                .Include(x => x.Image)
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
            Category? item = await this._context.Categories.GetById(id);
            if (item == null)
            {
                return;
            }
            this._context.Categories.Delete(item);
            await this._context.CommitAsync();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            Category item = DTO.FromDTO();
            await this._context.Categories.Add(item);
            await this._context.CommitAsync();
            return Ok(item.Id);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoryDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            Category item = DTO.FromDTO();
            this._context.Categories.Update(item);
            await this._context.CommitAsync();
            return Ok();
        }
    }
}
