using Microsoft.EntityFrameworkCore;
using RestaurantAppWpf.BL.Models;
using RestaurantAppWpf.UI.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppWpf.UI.MVVM.ViewModel
{
    public class CartViewModel : BaseViewModel
    {
        public ObservableCollection<CartItem> Carts { get; }
        private decimal priceAll;
        public decimal PriceAll
        {
            get => priceAll;
            set
            {
                priceAll = value;
                OnPropertyChanged();
            }
        }
        
        public RelayCommand PaymentCommand { get; }

        public CartViewModel()
        {
            Db.Dishes.ToList();
            Db.Cart.Load();
            Carts = Db.Cart.Local.ToObservableCollection();
            PriceAll = GetAll();
            PaymentCommand = new RelayCommand(() =>
            {
                Carts.Clear();
                Db.SaveChanges();
                PriceAll = GetAll();
            });
        }

        public decimal GetAll()
        {
            decimal price = 0;
            foreach (var cartItem in Carts)
            {
                for (int i = 0; i < cartItem.Count; i++)
                {
                    price += cartItem.Dish.Price;
                }
            }
            return price;
        }
    }
}
