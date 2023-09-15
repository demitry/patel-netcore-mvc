using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AppRole.Admin)]
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
            var productList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
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
            if (id == null || id == 0)
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

        private const string ProductImagePath = @"images\product\product-";

        void SaveOrUpdateProductImages(ref ProductViewModel productViewModel, List<IFormFile?> files)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (files != null)
            {
                string productPath = $"{Path.Combine(wwwRootPath, ProductImagePath)}{productViewModel.Product.Id}";
                if (!Directory.Exists(productPath))
                {
                    Directory.CreateDirectory(productPath);
                }

                foreach (IFormFile file in files)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string fullFilePath = Path.Combine(productPath, fileName);
                    using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    ProductImage productImage = new ProductImage
                    {
                        ImageUrl = $"{productPath}\\{fileName}",
                        ProductId = productViewModel.Product.Id,
                    };

                    if (productViewModel.Product.ProductImages == null)
                        productViewModel.Product.ProductImages = new List<ProductImage>();

                    productViewModel.Product.ProductImages.Add(productImage);
                }

                _unitOfWork.Product.Update(productViewModel.Product);
                _unitOfWork.Save();
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProductViewModel productViewModel, List<IFormFile?> files) // remember enctype="multipart/form-data" ?
        {
            if (ModelState.IsValid)
            {
                // We have to create a new product, so we will have and id, and can create a new folder 
                if (productViewModel.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productViewModel.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productViewModel.Product);
                }

                _unitOfWork.Save();

                SaveOrUpdateProductImages(ref productViewModel, files);

                TempData["success"] = "Product created successfully";
                return RedirectToAction(nameof(Index));
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

        #region Api Calls

        //https://localhost:7209/Admin/Product/getall
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = productList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(u => u.Id == id);

            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            /*
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            */

            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }


        #endregion
    }
}
