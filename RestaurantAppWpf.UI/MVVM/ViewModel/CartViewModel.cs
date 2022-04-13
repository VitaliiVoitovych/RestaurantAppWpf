using RestaurantAppWpf.BL.Models;
using RestaurantAppWpf.UI.Core;
using System;
using System.Linq;

namespace RestaurantAppWpf.UI.MVVM.ViewModel
{
    public class CartViewModel : BaseViewModel
    {
        public RelayCommand PaymentCommand { get; }
        public RelayCommand<CartItem> RemoveDishCommand { get; }

        public CartViewModel()
        {
            Db.Dishes.ToList();
            Cart.UpdatePrice();
            PaymentCommand = new RelayCommand(() =>
            {
                if (Order != null)
                {
                    DateTime paymentDate = DateTime.Now;
                    Db.Orders.Add(Order);
                    Db.SaveChanges();
                    foreach (Dish dish in Cart)
                    {
                        Payment payment = new Payment()
                        {
                            DishId = dish.DishId,
                            OrderId = Order.OrderId,
                            PaymentDate = paymentDate
                        };
                        Db.Payments.Add(payment);
                    }
                    Cart.Clear();
                    Cart.UpdatePrice();
                    Db.SaveChanges();
                    Order = null;
                }
            });
            RemoveDishCommand = new RelayCommand<CartItem>((cartItem) =>
            {
                Cart.Dishes.Remove(cartItem);
                Cart.UpdatePrice();
            });
        }
    }
}
