namespace TaftMasterWebAPI.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
