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
    public class BrandsController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<BrandsController> _logger;
        public BrandsController(IDataContext context, ILogger<BrandsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int PageSize, [FromQuery] int CurrentPage)
        {
            var query = _context.Brands.GetAll();
            List<BrandDTO> items = query.Page(CurrentPage, PageSize)
                .Include(x => x.Products)
                .ToDTOs()
                .ToList();
            return Ok(items);
        }
    }
}
