using Microsoft.EntityFrameworkCore;
using RestaurantAppWpf.BL.Models;
using RestaurantAppWpf.UI.Core;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media.Imaging;

namespace RestaurantAppWpf.UI.MVVM.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        public ObservableCollection<Dish> Dishes { get; }
        private Dish currentDish;
        public Dish CurrentDish
        {
            get => currentDish;
            set
            {
                currentDish = value;
                OnPropertyChanged();
            }
        }

        public MenuViewModel()
        {
            Db.Dishes.Load();
            Dishes = Db.Dishes.Local.ToObservableCollection();
            CurrentDish = Dishes.FirstOrDefault();
        }
    }
}
