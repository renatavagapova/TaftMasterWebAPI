
namespace TaftMasterWebAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Recipient { get; set; }
        public string Comment { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
