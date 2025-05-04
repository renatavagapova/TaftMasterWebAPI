using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace TaftMasterWebAPIData
{
    [Table("Account")]
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [StringLength(255)]
        public string EMail { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string PasswordSalt { get; set; }

        [StringLength(100)]
        public string PasswordHash { get; set; }

        public bool Locked { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string SurName { get; set; }

        [StringLength(255)]
        public string Patronymic { get; set; }

        [InverseProperty(nameof(AccountSession.Account))]
        public virtual ICollection<AccountSession> Sessions { get; set; } = new HashSet<AccountSession>();
    }
}