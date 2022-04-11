using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppWpf.BL.Models
{
    public class CartItem
    {
        public Dish Dish { get; set; }
        public int Count { get; set; }
        public CartItem(Dish dish, int count)
        {
            Dish = dish;
            Count = count;
        }
    }
}
