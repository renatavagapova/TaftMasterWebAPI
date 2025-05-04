using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaftMasterWebAPIData
{
    [Table("MasterClass")]
    public class MasterClass
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MasterClassId { get; set; }

        [Column, StringLength(225)]
        public string Title { get; set; }

        [Column, StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int MaxAttendees { get; set; }
        
    }
}
