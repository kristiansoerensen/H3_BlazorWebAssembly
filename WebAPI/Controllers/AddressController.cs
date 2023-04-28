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
    public class AddressController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<AddressController> _logger;
        public AddressController(IDataContext context, ILogger<AddressController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            AddressDTO? DTO = this._context.Addresses
                .GetAll().Where(x => x.Id == id)
                .Include(x => x.Country)
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
            Address? item = await this._context.Addresses.GetById(id);
            if (item == null)
            {
                return;
            }
            this._context.Addresses.Delete(item);
            await this._context.CommitAsync();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddressDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            Address item = DTO.FromDTO();
            await this._context.Addresses.Add(item);
            await this._context.CommitAsync();
            return Ok(item.Id);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AddressDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            Address item = DTO.FromDTO();
            this._context.Addresses.Update(item);
            await this._context.CommitAsync();
            return Ok();
        }
    }
}
