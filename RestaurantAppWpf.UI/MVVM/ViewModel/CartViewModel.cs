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
        public RelayCommand UpdateCartCommand { get; }

        public CartViewModel()
        {
            Db.Dishes.ToList();
            Db.Cart.Load();
            Carts = Db.Cart.Local.ToObservableCollection();
            PriceAll = GetAll();
            PaymentCommand = new RelayCommand(() =>
            {
                Update();
                if (Order != null)
                {
                    DateTime paymentDate = DateTime.Now;
                    Db.Orders.Add(Order);
                    Db.SaveChanges();
                    foreach (var cartItems in Carts)
                    {
                        if (cartItems.Count > 0)
                        {
                            for (int i = 0; i < cartItems.Count; i++)
                            {
                                Payment payment = new Payment()
                                {
                                    DishId = cartItems.DishId,
                                    OrderId = Order.OrderId,
                                    PaymentDate = paymentDate
                                };
                                Db.Payments.Add(payment);
                            }
                        }
                    }
                    Carts.Clear();
                    Db.SaveChanges();
                    PriceAll = GetAll();
                    Order = null;
                }
            });
        }

        public void Update()
        {
            List<CartItem> cartItems = new List<CartItem>();
            foreach (var cartItem in Carts)
            {
                if (cartItem.Count == 0)
                {
                    cartItems.Add(cartItem);
                }
            }
            Db.Cart.RemoveRange(cartItems);
            if (Carts.Count == 0)
            {
                Order = null;
            }
            Db.SaveChanges();
            PriceAll = GetAll();
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
