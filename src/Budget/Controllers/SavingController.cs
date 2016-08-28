using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Budget.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Budget.Controllers
{
    public class SavingController : Controller
    {
        // GET: /<controller>/
        private UserContext db;
        public SavingController(UserContext context)
        {
            db = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(db.Savings);
        }
        public IActionResult Add(string name, int money, DateTime date)
        {
            if (db.Savings.Where(i => i.Name == name).FirstOrDefault() == null)
            {
                
                db.Savings.Add(new Saving { Name = name, Money = money, Date = date, Current = 0,DateCreate=DateTime.Today });
                db.SaveChanges();
            }


            return View("Index", db.Savings);

        }
        public IActionResult Delete(string NameDel)
        {
            foreach (Saving i in db.Savings)
            {
                if (i.Name == NameDel)
                {
                    db.Savings.Remove(i);

                    break;
                }
            }
            db.SaveChanges();
           
            return View("Index", db.Savings);
        }
        [HttpPost]
        public IActionResult Update(string name, int money, int current, DateTime date,string oldname)
        {
            foreach (Saving i in db.Savings)
            {
                if (i.Name == oldname)
                {
                    i.Money = money;
                    i.Current = current;
                    i.Date = date;
                    i.Name = name;
                    break;
                }
            }
            db.SaveChanges();
           
            return View("Index", db.Savings);
        }
        public IActionResult Current(string cash, string name, int money)
        {
            Cash tmp = db.Cashs.Where(i => i.Name == cash).FirstOrDefault();
            Saving saving = db.Savings.Where(i => i.Name == name).FirstOrDefault();
            if (tmp.Money>=money)
            {
                db.Deposits.Add(new Deposit { Name = name, Money = money ,Date=DateTime.Now, Cash=cash});
                tmp.Money -= money;
                saving.Current += money;
                db.SaveChanges();
            }
            return Redirect("~/Home/Index");
        }
    }
}
