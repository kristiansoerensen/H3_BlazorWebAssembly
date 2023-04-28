using DataLayer.Data;
using DataLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<AddressesController> _logger;
        public AddressesController(IDataContext context, ILogger<AddressesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int PageSize, [FromQuery] int CurrentPage)
        {
            var query = _context.Addresses.GetAll();
            List<AddressDTO> items = query.Page(CurrentPage, PageSize)
                .Include(x => x.Country)
                .ToDTOs()
                .ToList();
            return Ok(items);
        }
    }
}
