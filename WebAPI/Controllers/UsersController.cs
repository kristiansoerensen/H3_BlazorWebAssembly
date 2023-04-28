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
    public class UsersController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IDataContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int PageSize, [FromQuery] int CurrentPage)
        {
            var query = _context.Users.GetAll();
            List<UserDTO> items = query.Page(CurrentPage, PageSize)
                .Include(x => x.BillingAddress)
                .ToDTOs()
                .ToList();
            return Ok(items);
        }
    }
}
