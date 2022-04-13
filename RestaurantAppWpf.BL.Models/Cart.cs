using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RestaurantAppWpf.BL.Models
{
    public class Cart : ObservableObject,IEnumerable
    {
        public ObservableCollection<CartItem> Dishes { get; } = new ObservableCollection<CartItem>();
        private decimal price;
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        public Cart()
        {
            Dishes.CollectionChanged += Dishes_CollectionChanged;
        }

        private void Dishes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (var item in e.NewItems.Cast<CartItem>())
                    item.PropertyChanged += OnChanged;

            if (e.OldItems != null)
                foreach (var item in e.OldItems.Cast<CartItem>())
                    item.PropertyChanged -= OnChanged;
        }

        private void OnChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is CartItem c && c.Count <= 0)
            {
                Dishes.Remove(c);
            }
            UpdatePrice();
        }

        public void Clear() => Dishes.Clear();
        public void UpdatePrice() => Price = GetAll().Sum(d => d.Price);
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

        private ObservableCollection<Dish> GetAll()
        {
            var dishes = new ObservableCollection<Dish>();
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
