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
                
                db.Savings.Add(new Saving { Name = name, Money = money, Date = date, Current = 0 });
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
        public IActionResult Update(string name, int money, int current, DateTime date)
        {
            foreach (Saving i in db.Savings)
            {
                if (i.Name == name)
                {
                    i.Money = money;
                    i.Current = current;
                    i.Date = date;

                    break;
                }
            }
            db.SaveChanges();
           
            return View("Index", db.Savings);
        }
    }
}
