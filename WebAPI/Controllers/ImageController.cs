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
    public class ImageController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<ImageController> _logger;
        public ImageController(IDataContext context, ILogger<ImageController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ImageDTO? DTO = this._context.Images
                .GetAll().Where(x => x.Id == id)
                .Include(x => x.Product)
                .Include(x => x.Categories)
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
            Image? item = await this._context.Images.GetById(id);
            if (item == null)
            {
                return;
            }
            this._context.Images.Delete(item);
            await this._context.CommitAsync();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ImageDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            Image item = DTO.FromDTO();
            await this._context.Images.Add(item);
            await this._context.CommitAsync();
            return Ok(item.Id);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ImageDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            Image item = DTO.FromDTO();
            this._context.Images.Update(item);
            await this._context.CommitAsync();
            return Ok();
        }
    }
}
