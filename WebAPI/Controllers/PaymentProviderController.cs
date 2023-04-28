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
    public class PaymentProviderController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<PaymentProviderController> _logger;
        public PaymentProviderController(IDataContext context, ILogger<PaymentProviderController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PaymentProviderDTO? DTO = this._context.PaymentProviders
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
            PaymentProvider? item = await this._context.PaymentProviders.GetById(id);
            if (item == null)
            {
                return;
            }
            this._context.PaymentProviders.Delete(item);
            await this._context.CommitAsync();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentProviderDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            PaymentProvider item = DTO.FromDTO();
            await this._context.PaymentProviders.Add(item);
            await this._context.CommitAsync();
            return Ok(item.Id);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PaymentProviderDTO? DTO)
        {
            if (DTO == null)
            {
                return NoContent();
            }
            PaymentProvider item = DTO.FromDTO();
            this._context.PaymentProviders.Update(item);
            await this._context.CommitAsync();
            return Ok();
        }
    }
}
