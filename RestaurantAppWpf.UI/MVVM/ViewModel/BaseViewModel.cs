using RestaurantAppWpf.BL.EF;
using RestaurantAppWpf.UI.Core;

namespace RestaurantAppWpf.UI.MVVM.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        public RestaurantAppDbContext Db { get; set; }
        public BaseViewModel()
        {
            Db = new RestaurantAppDbContext();
        }
    }
}
