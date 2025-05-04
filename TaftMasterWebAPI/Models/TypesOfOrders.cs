namespace TaftMasterWebAPI.Models
{
    public class TypesOfOrders
    {
        public int Id { get; set; }
        public int? IdOreder { get; set; }
        public int? IdZ { get; set; }
        public int? IdMC { get; set; }
        public int? IdStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<Zayav> ZItems { get; set; }
        public List<MasterClass> MCItems { get; set; }
        public List<Statuses> StatusItems { get; set; }
    }
}
