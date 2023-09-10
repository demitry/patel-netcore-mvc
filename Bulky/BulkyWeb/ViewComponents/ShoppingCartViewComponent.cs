using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Utility.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulkyBookWeb.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null) // null if user is not logged in
            {
                if (HttpContext.Session.GetInt32(AppSession.ShoppingCart) == null)
                {
                    string userId = claim.Value;
                    int cartItemsCount = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == userId).Count();
                    HttpContext.Session.SetInt32(AppSession.ShoppingCart, cartItemsCount);
                }
                return View(HttpContext.Session.GetInt32(AppSession.ShoppingCart));
            }
            else
            {
                HttpContext.Session.Clear();
                return View(0);
            }

        }
    }
}
