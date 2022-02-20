namespace RestaurantAppWpf.BL.Models
{
    public class TypeDish
    {
        public int TypeDishId { get; set; }
        public string Name { get; set; }
        public List<Dish> Dishes { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
