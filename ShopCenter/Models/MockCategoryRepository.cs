namespace ShopCenter.Models
{
    public class MockCategoryRepository : ICategoryRepository
    { 
        public IEnumerable<Category> AllCategories =>
        new List<Category>
        { new Category{CategoryId=1,CategoryName="Fruit pies", Description="All fruit pies" },
          new Category{CategoryId=2,CategoryName="Cheese cacke", Description="Cheesy" },
          new Category{CategoryId=3,CategoryName="Saisonal pies", Description="All fruit pies" }

         };
    }
}
