using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var productList = _unitOfWork.Product.GetAll().ToList();

            //IEnumerable<SelectListItem> categoryList = 
            //    _unitOfWork.Category.GetAll().ToList(); ... 
            //Q: How to convert?
            //A: Projections in .NET Core

            //IEnumerable<SelectListItem> categoryList =
            //    _unitOfWork.Category.GetAll().Select(u => new SelectListItem()
            //    {
            //        Text = u.Name,
            //        Value = u.Id.ToString()
            //    });

            //Q: And how to pass it?
            //A: ViewBag transfers data from controller to View and NOT vise-versa
            // ViewBag is dynamic property, C# 4.0
            // Any number of properties can be assigned to ViewBag
            // The ViewBag's life only lasts during the current http request.
            // ViewBag values will be null if redirections occurs.
            // ViewBag is wrapper around the ViewData
            return View(productList);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> categoryList =
                _unitOfWork.Category.GetAll().Select(u => new SelectListItem()
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            //ViewBag.CategoryList = categoryList;
            ViewData["CategoryList"] = categoryList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            //}

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = _unitOfWork.Product.Get(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
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

            var product = _unitOfWork.Product.Get(c => c.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(p => p.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
