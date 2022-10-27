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

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            //var objCategoryList2 = _db.Categories.ToList();
            return View(objCategoryList);
        }

        /// <summary>
        /// delete data
        /// </summary>
        /// <param name="id">category id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category delete successfully";
            return RedirectToAction("Index","Category");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// add new category
        /// </summary>
        /// <param name="obj">name and displayOrder</param>
        /// <returns></returns>
        // ValidateAntiForgeryToken : prevent CSRF(Cross-Site Request Forgery) attack
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name");
            }
            // server side validation 
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Add Category successfully";
                return RedirectToAction("Index");
                //return RedirectToAction("Action","Controller");
            }
            return View(obj);
        }

        /// <summary>
        /// enter edit page
        /// </summary>
        /// <param name="id">category id</param>
        /// <returns>edit page</returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        /// <summary>
        /// add edit into db
        /// </summary>
        /// <param name="obj">new change</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name");
            }
            // server side validation 
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Edit category successfully";
                return RedirectToAction("Index");
                //return RedirectToAction("Action","Controller");
            }
            return View(obj);
        }
    }
}

