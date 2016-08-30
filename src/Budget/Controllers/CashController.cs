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
    public class CashController : Controller
    {
        // GET: /<controller>/
        private UserContext db;
        public CashController(UserContext context)
        {
            db = context;
        }
        [Authorize]
        public IActionResult Index()
        {

            List<Cash> cash = new List<Cash> { };
            foreach (Cash tmp in db.Cashs)
            {
                cash.Add(tmp);
            }
            return View(cash);
        }

        [HttpPost]
        public IActionResult Update(string Name, int Money, string OldName)
        {
            foreach (Cash i in db.Cashs)
            {
                if (i.Name == OldName)
                {
                    i.Money = Money;
                    i.Name = Name;
                    break;
                }
            }
            db.SaveChanges();
            List<Cash> cash = new List<Cash> { };
            foreach (Cash tmp in db.Cashs)
            {
                cash.Add(tmp);
            }
            return View("Index",cash);
        }
        [HttpPost]
        public IActionResult Delete(string NameDel)
        {
            foreach (Cash i in db.Cashs)
            {
                if (i.Name == NameDel)
                {
                    db.Cashs.Remove(i);

                    break;
                }
            }
            db.SaveChanges();
            List<Cash> cash = new List<Cash> { };
            foreach (Cash tmp in db.Cashs)
            {
                cash.Add(tmp);
            }
            return View("Index",cash);
        }
        [HttpPost]
        public IActionResult Add(string name, int money)
        {
            if (db.Cashs.Where(i => i.Name == name).FirstOrDefault()==null)
            {
                db.Cashs.Add(new Cash { Name = name, Money = money });
                db.SaveChanges();
            }
            
            List<Cash> cash = new List<Cash> { };
            foreach (Cash tmp in db.Cashs)
            {
                cash.Add(tmp);
            }
            return View("Index", cash);
        }
        [HttpPost]
        public IActionResult Many(string name, int money)
        {
            Cash cash = db.Cashs.Where(i => i.Name == name).FirstOrDefault();
            cash.Money += money;
            db.SaveChanges();
            return Redirect("~/Home/Index");
        }
        public IActionResult Transfer(string name, int money)
        {
            Cash cash = db.Cashs.Where(i => i.Name == name).FirstOrDefault();
            if (cash.Money>=money)
            {
                Cash cashcash = db.Cashs.Where(i => i.Name == "Наличные").FirstOrDefault();
                if (cashcash!=null)
                {
                    cash.Money -= money;
                    cashcash.Money += money;
                }
            }
            db.SaveChanges();
            return Redirect("~/Home/Index");
        }
    }

}
