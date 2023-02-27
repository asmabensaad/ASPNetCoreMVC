namespace ShopCenter.Models
{
    public class MockPieRepository : IPieRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Pie> AllPies => new List<Pie>
        {
            new Pie
            {
                PieId = 1,
                Name = "Strawberry",
                Price = 15.3M,
                ShortDescription = "",
                LongDescription = "",
                Category = _categoryRepository.AllCategories.ToList()[0],
                ImageUrl = "https://www.gettyimages.fr/photos/cooking",
                InStock = true,
                IsPieOfTheWeek = false,
                ImageThumbnailUrl = ""
            },
            new Pie
            {
                PieId = 2,
                Name = "Strawberry",
                Price = 15.3M,
                ShortDescription = "",
                LongDescription = "",
                Category = _categoryRepository.AllCategories.ToList()[0],
                ImageUrl = "https://www.gettyimages.fr/photos/cooking",
                InStock = true,
                IsPieOfTheWeek = false,
                ImageThumbnailUrl = ""
            },

        };
        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return AllPies.Where(p => p.IsPieOfTheWeek);

            }

        }
        public Pie? GetPieById(int pieId) => AllPies.FirstOrDefault(p => p.PieId == pieId);
        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            throw new NotImplementedException();
        }

    }
}