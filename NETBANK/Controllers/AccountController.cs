using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NETBANK.Models;

namespace NETBANK.Controllers
{
    public class AccountController : Controller
    {
   
        public ActionResult Index(int bankId)   
        {
            AccountContext accountContext = new AccountContext();
            List<Account> accounts = accountContext.Accounts.Where(ac => ac.BankId == bankId).ToList();

            return View(accounts);
        }
        public ActionResult Details(int Id)
        {
            AccountContext accountContext = new AccountContext();
            Account account = accountContext.Accounts.Single(acc => acc.CardNumber == Id);

            return View(account);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(int CardNumber, string Name ,string CardType,int Cash,int BankId)
        {
            Account account = new Account();
            account.CardNumber = CardNumber;
            account.Name = Name;
            account.CardType = CardType;
            account.Cash = Cash;
            account.BankId = BankId;

            TranzactionBussniessLayer tranzactionBussniessLayer = new TranzactionBussniessLayer();
            tranzactionBussniessLayer.AddAccount(account);
            return RedirectToAction("AllAccount"); 
        }
        public ActionResult AllAccount()
        {
            TranzactionBussniessLayer tranzactionBussniessLayer = new TranzactionBussniessLayer();
           List<Account> accounts= tranzactionBussniessLayer.Accounts.ToList();
            return View(accounts);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            TranzactionBussniessLayer tranzactionBussniessLayer = new TranzactionBussniessLayer();
          Account account=  tranzactionBussniessLayer.Accounts.Single(acc => acc.CardNumber == Id);

            return View(account);
        }
        

        
    }
}