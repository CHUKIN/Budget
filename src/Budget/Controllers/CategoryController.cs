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
    public class CategoryController : Controller
    {
        // GET: /<controller>/
        private UserContext db;
        public CategoryController(UserContext context)
        {
            db = context;
        }
        [Authorize]
        public IActionResult Index()
        {

         
            return View(db.Categorys);
        }
        
        public IActionResult Add(string name)
        {
            if (db.Categorys.Where(i => i.Name == name).FirstOrDefault() == null)
            {

                db.Categorys.Add(new Category { Name = name });
                db.SaveChanges();
            }


            return View("Index", db.Categorys);

        }
        public IActionResult Delete(string NameDel)
        {
            foreach (Category i in db.Categorys)
            {
                if (i.Name == NameDel)
                {
                    db.Categorys.Remove(i);

                    break;
                }
            }
            db.SaveChanges();

            return View("Index", db.Categorys);
        }
    }
}
