namespace TaftMasterWebAPI.Models
{
    public class Rug
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal Sale { get; set; }
        public int Quantity { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
