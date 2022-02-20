namespace RestaurantAppWpf.BL.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
