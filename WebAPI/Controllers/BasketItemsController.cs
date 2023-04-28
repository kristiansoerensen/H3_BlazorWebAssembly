using DataLayer.Data;
using DataLayer.Entities;
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
        public IActionResult Get([FromQuery] int? basketId)
        {
            
            var query = _context.BasketItems.GetAll();
            if (basketId != null)
            {
                query = query.Where(x => x.BasketId == basketId);
            }
            List<BasketItem> items = query
                .Include(x => x.Basket)
                .Include(x => x.Product)
                .ThenInclude(x => x.Images)
                .ToList();
            return Ok(items);
        }
    }
}
