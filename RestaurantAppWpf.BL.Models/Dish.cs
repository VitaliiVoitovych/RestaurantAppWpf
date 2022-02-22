namespace RestaurantAppWpf.BL.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public int TypeDishId { get; set; }
        public TypeDish TypeDish { get; set; }
        public byte[] Image { get; set; }
        public double Kilocalories { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public List<Payment> Payments { get; set; }
        public List<CartItem> Cart { get; set; }
        public override string ToString()
        {
            return $"{Name} : ${Price}";
        }
    }
}
