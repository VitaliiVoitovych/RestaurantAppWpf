using System.Collections;
using System.Collections.ObjectModel;

namespace RestaurantAppWpf.BL.Models
{
    public class Cart : IEnumerable
    {
        public ObservableCollection<CartItem> Dishes { get; } = new ObservableCollection<CartItem>();
        public decimal Price => GetAll().Sum(d => d.Price);
        public void Clear() => Dishes.Clear();
        public void Add(Dish dish, int count)
        {
            var cartItem = Dishes.FirstOrDefault(c => c.Dish.Name == dish.Name);
            if (cartItem != null)
            {
                cartItem.Count += count;
            }
            else
            {
                Dishes.Add(new CartItem(dish, count));
            }
        }

        private List<Dish> GetAll()
        {
            var dishes = new List<Dish>();
            foreach (Dish dish in this)
            {
                dishes.Add(dish);

            }
            return dishes;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in Dishes)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    yield return item.Dish;
                }
            }
        }
    }
}
