﻿using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;
using BulkyBook.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace BulkyBookWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product
                .GetAll(includeProperties: "Category");
            
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new ShoppingCart()
            {
                Product = _unitOfWork.Product.Get(p => p.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
            };
            
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart cart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            cart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart
                .Get(u => u.ApplicationUserId == userId && u.ProductId == cart.ProductId);

            if(cartFromDb != null)
            {
                // shopping cart exists
                cartFromDb.Count += cart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }
            else
            {
                // add a cart
                _unitOfWork.ShoppingCart.Add(cart);
            }

            _unitOfWork.Save();
            int cartItemsCount = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count();
            HttpContext.Session.SetInt32(AppSession.ShoppingCart, cartItemsCount);

            var cartUpdate = (cartFromDb != null) ? "updated" : "added";
            TempData["success"] = $"Cart {cartUpdate} successfully";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}