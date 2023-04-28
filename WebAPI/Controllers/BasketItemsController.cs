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
    public class BasketItemsController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<BasketItemsController> _logger;
        public BasketItemsController(IDataContext context, ILogger<BasketItemsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int PageSize, [FromQuery] int CurrentPage)
        {
            var query = _context.BasketItems.GetAll();
            List<BasketItemDTO> items = query.Page(CurrentPage, PageSize)
                .Include(x => x.Basket)
                .Include(x => x.Product)
                .ToDTOs()
                .ToList();
            return Ok(items);
        }
    }
}
