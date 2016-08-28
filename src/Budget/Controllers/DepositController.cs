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
    public class DepositController : Controller
    {
        // GET: /<controller>/
        // GET: /<controller>/
        private UserContext db;
        public DepositController(UserContext context)
        {
            db = context;
        }
        [Authorize]
        public IActionResult Index()
        {

           
            return View(db);
        }
    }
}
