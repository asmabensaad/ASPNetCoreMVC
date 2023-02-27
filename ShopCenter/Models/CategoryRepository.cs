namespace ShopCenter.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDbContext _shopDbContext;
        public CategoryRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public IEnumerable<Category> AllCategories =>
            _shopDbContext.Categories.OrderBy(p => p.CategoryName);

        
    }
}
