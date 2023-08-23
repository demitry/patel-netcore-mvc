using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var productList = _unitOfWork.Product.GetAll().ToList();
            return View(productList);
        }

        public IActionResult Upsert(int? id)
        {
            ProductViewModel productViewModel = new()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem()
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            if(id == null || id == 0)
            {
                //create
                return View(productViewModel);
            }
            else
            {
                //update
                productViewModel.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productViewModel);
            }
            
        }

        private const string ProductImagePath = @"images\product";

        void SaveOrUpdateProductImage(ref ProductViewModel productViewModel, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, ProductImagePath);
                
                if(!string.IsNullOrEmpty(productViewModel.Product.ImageUrl))
                {
                    // delete the old image
                    var oldImagePath = Path.Combine(wwwRootPath, productViewModel.Product.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                string fullFilePath = Path.Combine(productPath, fileName);
                using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                productViewModel.Product.ImageUrl = "\\" + ProductImagePath + "\\" + fileName;
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProductViewModel productViewModel, IFormFile? file) // remember enctype="multipart/form-data" ?
        {
            if (ModelState.IsValid)
            {
                SaveOrUpdateProductImage(ref productViewModel, file);

                //string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot
                //if(file != null)
                //{
                //    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                //    string productPath = Path.Combine(wwwRootPath, @"images\product");
                //    string fullFilePath = Path.Combine(productPath, fileName);
                //    using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
                //    {
                //        file.CopyTo(fileStream);
                //    }
                //    productViewModel.Product.ImageUrl = @"images\product" + fileName;
                //}

                if (productViewModel.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productViewModel.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productViewModel.Product);
                }
                
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                productViewModel.CategoryList = 
                    _unitOfWork.Category.GetAll().Select(u => new SelectListItem()
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });

                // In case of validation error - return the same page, do not forget the CategoryList
                return View(productViewModel);
            }
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
