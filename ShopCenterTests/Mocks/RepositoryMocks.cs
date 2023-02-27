using Moq;
using ShopCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenterTests.Mocks
{
    public  class RepositoryMocks
    {
        public static Mock<IPieRepository> GetPieRepository()
        {
            var pies = new List<Pie>
            {
             new Pie
             {
                 Name = "Apple Pie",
                 Price = 12.95M,
                 ShortDescription = "Our famous apple pies!",
                 LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",

                 ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg",
                 InStock = true,
                 IsPieOfTheWeek = true,
                 ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg",
                 AllergyInformation = ""
             }
            };
            var mockPieRepository = new Mock<IPieRepository>();
            mockPieRepository.Setup(repo => repo.AllPies).Returns(pies);    
            mockPieRepository.Setup(repo => repo.PiesOfTheWeek).Returns(pies.Where(p=>p.IsPieOfTheWeek));
            mockPieRepository.Setup(repo => repo.GetPieById(It.IsAny<int>())).Returns(pies[0]);
            return mockPieRepository;

            
        }
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category ()
                {
                    CategoryId= 1,
                    CategoryName = "Fruit pies",
                Description="Lorem ipsum"
                },

                 new Category()
                 {   CategoryId=2,
                     CategoryName="Cheese cacke",
                     Description="Lorem ipsum"
                 },

                 new Category()
                 {    CategoryId=3,
                     CategoryName="Saisonal pies",
                     Description="All fruit pies"
                 }

            };
            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.AllCategories).Returns(categories);
            return mockCategoryRepository;

            
        }
        private static Dictionary<string, Category>? _categories;
        public static Dictionary<string,Category> Categories
        {
            get
            {
                if(_categories==null)
                {
                    var generesList = new Category[]
                    {
                        new Category { CategoryName = "Fruit pies" },
                        new Category { CategoryName = "Cheese cakes" },
                        new Category { CategoryName = "Seasonal pies" }
                    };
                    _categories = new Dictionary<string, Category>(); 
                }
                return _categories;
               
            }
            
        }
    }
}
