using DataLayer.Entities;

namespace DataLayer.Models
{
    public class PagedProducts
    {
        public string SearchTerm { get; set; } = string.Empty;
        public List<int> CategoryIds { get; set; } = new List<int>();
        public int PageSize { get; set; } = 9;
        public int OrderBy { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int NumOfPages { get; set; } = 1;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
