using ShopCenter.Models;

namespace ShopCenter.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; }
        public HomeViewModel(IEnumerable<Pie> piesOfTheWeek) {

            PiesOfTheWeek = piesOfTheWeek;
        }
    }
}
