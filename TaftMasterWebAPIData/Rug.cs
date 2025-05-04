using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaftMasterWebAPIData
{
    [Table("Rug")]
    public class Rug
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RugId { get; set; }

        [Column, StringLength(225)]
        public string Name { get; set; }

        [Column, StringLength(225)]
        public string Description { get; set; }

        [ForeignKey(nameof(CategoryOfRugs))]
        public int CategoryId { get; set; }

        public List<Material> Materials { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public bool IsInStock { get; set; }

        public CategoryOfRugs Category { get; set; }
    }
}
