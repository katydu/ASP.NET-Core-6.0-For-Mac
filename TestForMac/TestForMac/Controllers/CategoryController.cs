using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// so controller can know what is applicationDbContext
using TestForMac.Data;
// know what is Category
using TestForMac.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestForMac.Controllers
{
    public class CategoryController : Controller
    {
        // define a parameter later will catch data from ApplicationDbContext
        private readonly ApplicationDbContext _db;

        // constructor : when we load in this controller will first into CategoryController class, it's a oo concept
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            //var objCategoryList2 = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}

