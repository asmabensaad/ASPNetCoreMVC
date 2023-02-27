using ShopCenter.Models;

namespace ShopCenter.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string? CurrentCategory { get; }
        public PieListViewModel(IEnumerable<Pie> pies, string? currentCategory ) {
        Pies= pies;
            CurrentCategory= currentCategory;
        }

    }
}
