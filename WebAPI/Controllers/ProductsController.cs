using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Models;
using DataLayer.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IDataContext context, ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }


        /// <summary>
        /// List of products and support pagination and search
        /// </summary>
        /// <param name="SearchTerm">Name contains search term</param>
        /// <param name="CategoryIds">Filter on categories</param>
        /// <param name="PageSize">How many products should be returned</param>
        /// <param name="OrderBy">Orderby: 1: None - 2: Name ASC - 3: Name Desc - 4: Price ASC - Price Desc</param>
        /// <param name="CurrentPage">Current page, used with page size</param>
        /// <returns>List of products</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "SearchTerm": "Gorg",
        ///        "Categories": [1,3,4],
        ///        "PageSize": 9,
        ///        "Orderby": 1,
        ///        "CurrentPage": 1,
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns list of products</response>
        [HttpGet]
        public IActionResult Get([FromQuery]string? SearchTerm, [FromQuery]List<int> CategoryIds, [FromQuery] int PageSize, [FromQuery] int OrderBy, [FromQuery]int CurrentPage)
        {
            var query = _context.Products.GetAll();
            if (SearchTerm != null)
            {
                query = query.Where(p => p.Name.Contains(SearchTerm));
            }
            if (CategoryIds != null && CategoryIds.Count() > 0)
            {
                //List<ProductCategory> productCategories = await _context.ProductCategories.GetAll().Where(pc => CategoryIds.Contains(pc.CategoryId)).ToListAsync();
                query = query.Where(p => p.ProductCategories.Any(pc => CategoryIds.Contains(pc.CategoryId)));
            }
            switch (OrderBy)
            {
                case 1:
                    break;
                case 2:
                    query = query.OrderBy(p => p.Name);
                    break;
                case 3:
                    query = query.OrderByDescending(p => p.Name);
                    break;
                case 4:
                    query = query.OrderBy(p => p.Price);
                    break;
                case 5:
                    query = query.OrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }
            List<Product> products = query.Page(CurrentPage, PageSize).Include(p => p.Brand).Include(p => p.Images).Include(p => p.ProductCategories).ToList();
            //List<ProductDTO> products = query.Page(CurrentPage, PageSize).Include(p => p.Brand).Include(p => p.Images).Include(p => p.ProductCategories).ToDTOs().ToList();
            int numOfPages = PageSize != 0 ? ((query.Count() - 1) / PageSize) + 1 : 1;
            PagedProducts pagedProducts = new PagedProducts
            {
                CategoryIds = CategoryIds != null ? CategoryIds : new List<int>(),
                Products = products,
                PageSize = PageSize,
                CurrentPage = CurrentPage,
                OrderBy = OrderBy,
                SearchTerm = SearchTerm != null ? SearchTerm : string.Empty,
                NumOfPages = numOfPages
            };
            return Ok(pagedProducts);
        }
    }
}
