using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaftMasterWebAPIData
{
    [Table("Schedule")]
    public class Schedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SheduleId { get; set; }

        public int DayOfWeek { get; set; }

        public DateTime TimeOfMC { get; set; }
    }
}
