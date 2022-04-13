namespace RestaurantAppWpf.BL.Models
{
    public class CartItem : ObservableObject
    {
        public Dish Dish { get; set; }
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
        public CartItem(Dish dish, int count)
        {
            Dish = dish;
            Count = count;
        }
    }
}
