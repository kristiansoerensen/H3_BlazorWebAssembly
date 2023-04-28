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
    public class ImagesController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<ImagesController> _logger;
        public ImagesController(IDataContext context, ILogger<ImagesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int PageSize, [FromQuery] int CurrentPage)
        {
            var query = _context.Images.GetAll();
            List<ImageDTO> items = query.Page(CurrentPage, PageSize)
                .Include(x => x.Product)
                .Include(x => x.Categories)
                .ToDTOs()
                .ToList();
            return Ok(items);
        }
    }
}
