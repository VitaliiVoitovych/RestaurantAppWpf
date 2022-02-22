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
        private int index = 0;
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
        private int count;
        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand NextBtnCommand { get; }
        public RelayCommand PrevBtnCommand { get; }
        public RelayCommand AddToCartCommand { get; }
        public MenuViewModel()
        {
            Db.Dishes.Load();
            Dishes = Db.Dishes.Local.ToObservableCollection();
            CurrentDish = Dishes.FirstOrDefault();
            NextBtnCommand = new RelayCommand(() =>
            {
                if (index < Dishes.Count - 1)
                {
                    CurrentDish = Dishes[++index];
                }
            });
            PrevBtnCommand = new RelayCommand(() =>
            {
                if (index > 0)
                {
                    CurrentDish = Dishes[--index];
                }
            });
            AddToCartCommand = new RelayCommand(() =>
            {
                CartItem cartItem = new CartItem
                {
                    Dish = CurrentDish,
                    Count = Count
                };
                Db.Cart.Add(cartItem);
                Db.SaveChanges();
            });

        }
    }
}
