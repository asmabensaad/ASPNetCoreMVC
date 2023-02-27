using ShopCenterTests.Mocks;
using ShopCenter.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCenter.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ShopCenterTests.Controllers
{
    public  class PieControllerTest
    {
        [Fact]
        public void List_EmptyCategory_ReturnAllPies()
        {
            //arrange
            var mockPieRepository =  RepositoryMocks.GetPieRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);


            //action
            var result=pieController.List("");
            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(1, pieListViewModel.Pies.Count());


        }
    }
}
