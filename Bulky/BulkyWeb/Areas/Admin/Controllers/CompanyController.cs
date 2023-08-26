using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AppRole.Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var companyList = _unitOfWork.Company.GetAll().ToList();
            return View(companyList);
        }

        public IActionResult Upsert(int? id)
        {
            CompanyViewModel companyViewModel = new()
            {
                Company = new Company()
            };

            if (id == null || id == 0)
            {
                //create
                return View(companyViewModel);
            }
            else
            {
                //update
                companyViewModel.Company = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyViewModel);
            }

        }

        [HttpPost]
        public IActionResult Upsert(CompanyViewModel companyViewModel)
        {
            if (ModelState.IsValid)
            {
                if (companyViewModel.Company.Id == 0)
                {
                    _unitOfWork.Company.Add(companyViewModel.Company);
                }
                else
                {
                    _unitOfWork.Company.Update(companyViewModel.Company);
                }

                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                // In case of validation error - return the same page, do not forget the CategoryList
                return View(companyViewModel);
            }
        }

        #region Api Calls

        //https://localhost:7209/Admin/Company/getall
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = companyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);

            if (companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
