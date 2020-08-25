using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NETBANK.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int CardNumber { get; set; }
        public string Name { get; set; }
        public string CardType { get; set; }
        public int Cash { get; set; }
        public int BankId { get; set; }
    }
}