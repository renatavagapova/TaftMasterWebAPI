using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaftMasterWebAPI.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int? RugId { get; set; }

        [ForeignKey("RugId")]
        public Rug? Rug { get; set; }

        public int? CertificateId { get; set; }  

        [ForeignKey("CertificateId")]
        public Certificate? Certificate { get; set; }  // Навигационное свойство
        public int Quantity { get; set; }
        public string UserIdentifier { get; set; } // Привязка корзины к пользователю
    }
}
