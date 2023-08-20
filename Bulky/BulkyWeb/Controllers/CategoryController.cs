using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            var categoryList = _categoryRepo.GetAll().ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }

            //if (obj.Name != null && obj.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", $"{obj.Name} is an invalid value"); //the key is not specified, so this message will be available in asp-sammary
            //}

            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            //var category = _db.Categories.Find(id); // id is primary key
            var category = _categoryRepo.Get(c => c.Id == id); // works even is id is not primary
            //var category = _db.Categories.Where(category => category.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _categoryRepo.Get(c => c.Id == id);
            
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // used the id as a parameter, not the obj,
        // so the POST method name should be different,
        // and so - declared the Action Name [HttpPost, ActionName("Delete")] 
        [HttpPost, ActionName("Delete")] 
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _categoryRepo.Get(c => c.Id == id);
            if (obj == null) 
            {
                return NotFound();
            }

            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
