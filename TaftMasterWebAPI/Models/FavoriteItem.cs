using System.ComponentModel.DataAnnotations.Schema;

namespace TaftMasterWebAPI.Models
{
    public class FavoriteItem
    {
        public int Id { get; set; }
        public int? RugId { get; set; }
        public Rug? Rug { get; set; }
        public int? CertificateId { get; set; }

        [ForeignKey("CertificateId")]
        public Certificate? Certificate { get; set; }  // Навигационное свойство
        public string UserIdentifier { get; set; } // Привязка корзины к пользователю
    }
}
