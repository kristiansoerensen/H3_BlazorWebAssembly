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
    public class UserController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<UserController> _logger;
        public UserController(IDataContext context, ILogger<UserController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            UserDTO? DTO = this._context.Users
                .GetAll().Where(x => x.Id == id)
                .Include(x => x.BillingAddress)
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
        public async Task Delete(string id)
        {
            User? item = await this._context.Users.GetAll().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (item == null)
            {
                return;
            }
            this._context.Users.Delete(item);
            await this._context.CommitAsync();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            User item = DTO.FromDTO();
            await this._context.Users.Add(item);
            await this._context.CommitAsync();
            return Ok(item.Id);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            User item = DTO.FromDTO();
            this._context.Users.Update(item);
            await this._context.CommitAsync();
            return Ok();
        }
    }
}
