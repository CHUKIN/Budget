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
            List<CostModel> result = new List<CostModel> { };
            foreach (Cost i in db.Costs)
            {
                CostModel costmodel = new CostModel { Name = i.Name, Money = i.Money, Category = db.Categorys.Where(j => j.Id==i.CategoryId).FirstOrDefault().Name, Date = i.Date, User = db.Users.Where(j => j.Id == i.UserId).FirstOrDefault().Login };
                result.Add(costmodel);
            }

            return View(result);

        }
        public IActionResult Add(string name, int money, string category)
        {
            db.Costs.Add(new Cost { Name = name, Money = money, Category = db.Categorys.Where(i => i.Name == category).FirstOrDefault(), Date = DateTime.Now ,User=db.Users.Where(i=> i.Login==User.Identity.Name).FirstOrDefault()});
            db.SaveChanges();
            return Redirect("~/Home/Index");
        }
    }
}
