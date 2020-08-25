using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NETBANK.Models;

namespace NETBANK.Controllers
{
    public class BankController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            AccountContext accountContext = new AccountContext();
           List<Bank>banks = accountContext.Banks.ToList();
            return View(banks);
        }
    }
}