using RestaurantAppWpf.BL.EF;
using RestaurantAppWpf.BL.Models;
using RestaurantAppWpf.UI.Core;
using System.Collections.ObjectModel;

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
