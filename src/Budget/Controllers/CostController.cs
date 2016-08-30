using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Budget.Models;
using Microsoft.AspNetCore.Authorization;
using Budget.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Budget.Controllers
{
    public class CostController : Controller
    {
        // GET: /<controller>/
        private UserContext db;
        public CostController(UserContext context)
        {
            db = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            db.CostModels.RemoveRange(db.CostModels);
            foreach (Cost i in db.Costs)
            {
                CostModel p = new CostModel { Name = i.Name, Money = i.Money, Category = db.Categorys.Where(j => j.Id == i.CategoryId).FirstOrDefault().Name, Date = i.Date, User = db.Users.Where(j => j.Id == i.UserId).FirstOrDefault().Login, Count = i.Count, Unit = i.Unit, Cash = i.Cash };
                db.CostModels.Add(p);
            }
            db.SaveChanges();
                return View(db);

        }
        public IActionResult Add(string name, int money, string category,int count, string unit,string cash="Наличные")
        {
            Cash tmp = db.Cashs.Where(i => i.Name == cash).FirstOrDefault();
            if (tmp.Money >= money)
            {


                db.Costs.Add(new Cost { Name = name, Money = money, Category = db.Categorys.Where(i => i.Name == category).FirstOrDefault(), Date = DateTime.Today, User = db.Users.Where(i => i.Login == User.Identity.Name).FirstOrDefault(), Count = count, Unit = unit,Cash=cash });
                tmp.Money -= money;
            }
            db.SaveChanges();
            return Redirect("~/Home/Index");
        }
        public IActionResult Sort(string category, DateTime datestart, DateTime dateend)
        {
            DateTime correct = new DateTime(2015, 05, 18);
            db.CostModels.RemoveRange(db.CostModels);
            db.SaveChanges();
            foreach (Cost i in db.Costs)
            {
                CostModel p = new CostModel { Name = i.Name, Money = i.Money, Category = db.Categorys.Where(j => j.Id == i.CategoryId).FirstOrDefault().Name, Date = i.Date, User = db.Users.Where(j => j.Id == i.UserId).FirstOrDefault().Login, Count = i.Count, Unit = i.Unit, Cash = i.Cash };
                db.CostModels.Add(p);
            }
            db.SaveChanges();
            if (category!="Все")
            {
                db.CostModels.RemoveRange(db.CostModels.Where(i => i.Category != category));
            }
            db.SaveChanges();
            
                db.CostModels.RemoveRange(db.CostModels.Where(i => i.Date < datestart));
            
            db.SaveChanges();
            if (dateend > correct)
            {
                db.CostModels.RemoveRange(db.CostModels.Where(i => i.Date > dateend));
            }
            db.SaveChanges();
            return View("Index", db);

        }
    }
}
