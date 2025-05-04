using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaftMasterWebAPIData
{
    [Table("CategoryOfRugs")]
    public class CategoryOfRugs
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryOfRugId { get; set; }

        [ForeignKey(nameof(Rug))]
        public int RugId { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Rug Rug { get; set; }
        public Category Category { get; set; }
    }
}
