using DataLayer.Entities;

namespace DataLayer.Models
{
    public class PagedCategories
    {
        public string SearchTerm { get; set; } = string.Empty;
        public int PageSize { get; set; } = 9;
        public int OrderBy { get; set; } = 0;
        public int CurrentPage { get; set; } = 1;
        public int NumOfPages { get; set; } = 1;
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
