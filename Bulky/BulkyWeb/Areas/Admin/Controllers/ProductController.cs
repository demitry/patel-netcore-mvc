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
                productViewModel.Product = _unitOfWork.Product.Get(u => u.Id == id, includeProperties: "ProductImages");
                return View(productViewModel);
            }

        }

        void SaveOrUpdateProductImages(ref ProductViewModel productViewModel, List<IFormFile?> files)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string productPath = GetProductPath(productViewModel.Product.Id);
            string finalPath = Path.Combine(wwwRootPath, productPath);

            if (!Directory.Exists(finalPath))
                Directory.CreateDirectory(finalPath);

            if (files != null)
            {
                foreach (IFormFile file in files)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    ProductImage productImage = new()
                    {
                        ImageUrl = @"\" + productPath + @"\" + fileName,
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

        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted = _unitOfWork.ProductImage.Get(u => u.Id == imageId);
            int productId = imageToBeDeleted.ProductId;
            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldImagePath =
                                   Path.Combine(_webHostEnvironment.WebRootPath,
                                   imageToBeDeleted.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                _unitOfWork.ProductImage.Remove(imageToBeDeleted);
                _unitOfWork.Save();

                TempData["success"] = "Image Deleted successfully";
            }

            return RedirectToAction(nameof(Upsert), new { id = productId });
        }

        private string GetProductPath(int? productId) => @"images\products\product-" + productId;
        
        private void DeleteImagesForProduct(int? id)
        {
            string productPath = GetProductPath(id);
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
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

            DeleteImagesForProduct(id);

            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Product Successful" });
        }


        #endregion
    }
}
