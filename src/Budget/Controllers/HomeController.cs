using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Budget.Models;

namespace Budget.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db;
        public HomeController(UserContext context)
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
            
            return View(db);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
       
    }
}
