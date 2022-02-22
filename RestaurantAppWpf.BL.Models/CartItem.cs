using System.Collections;
using System.Collections.ObjectModel;

namespace RestaurantAppWpf.BL.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int Count { get; set; }
    }
}
