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
    public class PaymentProvidersController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<PaymentProvidersController> _logger;
        public PaymentProvidersController(IDataContext context, ILogger<PaymentProvidersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int PageSize, [FromQuery] int CurrentPage)
        {
            var query = _context.PaymentProviders.GetAll();
            List<PaymentProviderDTO> items = query.Page(CurrentPage, PageSize)
                .ToDTOs()
                .ToList();
            return Ok(items);
        }
    }
}
