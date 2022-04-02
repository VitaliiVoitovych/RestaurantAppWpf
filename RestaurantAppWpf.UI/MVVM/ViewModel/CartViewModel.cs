using RestaurantAppWpf.BL.Models;
using RestaurantAppWpf.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAppWpf.UI.MVVM.ViewModel
{
    public class CartViewModel : BaseViewModel
    {
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
            PriceAll = GetAll();
            PaymentCommand = new RelayCommand(() =>
            {
                Update();
                if (Order != null)
                {
                    DateTime paymentDate = DateTime.Now;
                    Db.Orders.Add(Order);
                    Db.SaveChanges();
                    foreach (var cartItems in Cart)
                    {
                        if (cartItems.Count > 0)
                        {
                            for (int i = 0; i < cartItems.Count; i++)
                            {
                                Payment payment = new Payment()
                                {
                                    DishId = cartItems.Dish.DishId,
                                    OrderId = Order.OrderId,
                                    PaymentDate = paymentDate
                                };
                                Db.Payments.Add(payment);
                            }
                        }
                    }
                    Cart.Clear();
                    Db.SaveChanges();
                    PriceAll = GetAll();
                    Order = null;
                }
            });
        }

        public void Update()
        {
            List<CartItem> cartItems = new List<CartItem>();
            foreach (var cartItem in Cart)
            {
                if (cartItem.Count == 0)
                {
                    cartItems.Add(cartItem);
                }
            }
            foreach (var item in cartItems)
            {
                Cart.Remove(item);
            }
            if (Cart.Count == 0)
            {
                Order = null;
            }
            Db.SaveChanges();
            PriceAll = GetAll();
        }

        public decimal GetAll()
        {
            decimal price = 0;
            foreach (var cartItem in Cart)
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
