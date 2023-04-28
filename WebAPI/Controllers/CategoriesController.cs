using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<CategoriesController> _logger;
        public CategoriesController(IDataContext context, ILogger<CategoriesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? SearchTerm, [FromQuery] int PageSize, [FromQuery] int CurrentPage)
        {
            var query = _context.Categories.GetAll();
            if (SearchTerm != null)
            {
                query = query.Where(p => p.Name.Contains(SearchTerm));
            }
            List<Category> Categries = query.ToList(); ;
            int numOfPages = PageSize != 0 ? ((query.Count() - 1) / PageSize) + 1 : 1;
            PagedCategories pagedProducts = new PagedCategories
            {
                Categories = Categries,
                PageSize = PageSize,
                CurrentPage = CurrentPage,
                SearchTerm = SearchTerm != null ? SearchTerm : string.Empty,
                NumOfPages = numOfPages
            };
            return Ok(pagedProducts);
        }
    }
}
