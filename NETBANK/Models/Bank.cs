using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NETBANK.Models
{
    [Table("Bank")]
    public class Bank
    {


        [Key]
        public int BankId { get; set; }
        public string BankName { get; set; }
        public List<Account> Accounts { get; set; }
    }
}