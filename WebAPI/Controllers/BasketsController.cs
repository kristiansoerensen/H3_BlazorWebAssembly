using DataLayer.Data;
using DataLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer.ExtensionMethods;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<BasketsController> _logger;
        public BasketsController(IDataContext context, ILogger<BasketsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int basketId)
        {
            var query = _context.Baskets.GetAll();
            List<BasketDTO> items = query
                .Include(x => x.User)
                .Include(x => x.CartLines)
                .Include(x => x.BillingAddress)
                .Include(x => x.ShippingAddress)
                .Include(x => x.PaymentProvider)
                .ToDTOs()
                .ToList();
            return Ok(items);
        }
    }
}
