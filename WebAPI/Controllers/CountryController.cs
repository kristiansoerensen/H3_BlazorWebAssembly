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
    public class CountryController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<CountryController> _logger;
        public CountryController(IDataContext context, ILogger<CountryController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            CountryDTO? DTO = this._context.Countries
                .GetAll().Where(x => x.Id == id)
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
            Country? item = await this._context.Countries.GetById(id);
            if (item == null)
            {
                return;
            }
            this._context.Countries.Delete(item);
            await this._context.CommitAsync();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountryDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            Country item = DTO.FromDTO();
            await this._context.Countries.Add(item);
            await this._context.CommitAsync();
            return Ok(item.Id);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CountryDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            Country item = DTO.FromDTO();
            this._context.Countries.Update(item);
            await this._context.CommitAsync();
            return Ok();
        }
    }
}
