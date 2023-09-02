using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulkyBookWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public ShoppingCartViewModel CartViewModel { get; set; }

        public IActionResult Plus(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
            cartFromDb.Count++;
            _unitOfWork.ShoppingCart.Update(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);

            if (cartFromDb.Count <= 1)
            {
                //remove from cart
                _unitOfWork.ShoppingCart.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Count--;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
            _unitOfWork.ShoppingCart.Remove(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CartViewModel = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Product"),
                OrderHeader = new()
            };

            foreach (var cart in CartViewModel.ShoppingCartList)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                CartViewModel.OrderHeader.OrderTotal += cart.Price * cart.Count;
            }
            
            return View(CartViewModel);
        }

        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var cart = CartViewModel = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Product"),
                OrderHeader = new()
            };

            var user = CartViewModel.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

            cart.OrderHeader.Name = user.Name;
            cart.OrderHeader.PhoneNumber = user.PhoneNumber;
            cart.OrderHeader.StreetAddress = user.StreetAddress;
            cart.OrderHeader.City = user.City;
            cart.OrderHeader.State = user.State;
            cart.OrderHeader.PostalCode = user.PostalCode;

            foreach (var cartItem in CartViewModel.ShoppingCartList)
            {
                cartItem.Price = GetPriceBasedOnQuantity(cartItem);
                CartViewModel.OrderHeader.OrderTotal += cartItem.Price * cartItem.Count;
            }

            return View(CartViewModel);
        }

        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()// Don't pass the ShoppingCartViewModel cartViewModel because we have Binding property
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CartViewModel.ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Product");

            CartViewModel.OrderHeader.OrderDate = DateTime.UtcNow;
            CartViewModel.OrderHeader.ApplicationUserId = userId;

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

            foreach (var cartItem in CartViewModel.ShoppingCartList)
            {
                cartItem.Price = GetPriceBasedOnQuantity(cartItem);
                CartViewModel.OrderHeader.OrderTotal += cartItem.Price * cartItem.Count;
            }

            bool isRegularCustomerAccount = applicationUser.CompanyId.GetValueOrDefault() == 0;

            if (isRegularCustomerAccount)
            {
                // Capture payment
                CartViewModel.OrderHeader.PaymentStatus = PaymentStatus.Pending;
                CartViewModel.OrderHeader.OrderStatus = OrderStatus.Pending;
            }
            else
            {
                // It is Company User
                CartViewModel.OrderHeader.PaymentStatus = PaymentStatus.DelayedPayment;
                CartViewModel.OrderHeader.OrderStatus = OrderStatus.Approved;
            }

            _unitOfWork.OrderHeader.Add(CartViewModel.OrderHeader);
            _unitOfWork.Save();

            foreach (var cart in CartViewModel.ShoppingCartList)
            {
                OrderDetail orderDetail = new()
                {
                    ProductId = cart.ProductId,
                    OrderHeaderId = CartViewModel.OrderHeader.Id, // Id was populated after the _unitOfWork.Save();
                    Price = cart.Price,
                    Count = cart.Count
                };

                _unitOfWork.OrderDetail.Add(orderDetail);
                _unitOfWork.Save();
            }

            if (isRegularCustomerAccount)
            {
                // It is regular customer account and we need to capture payment
            }

            return RedirectToAction(nameof(OrderConfirmation), new { orderId = CartViewModel.OrderHeader.Id });
        }

        public IActionResult OrderConfirmation(int orderId)
        {
            return View(orderId);
        }


        private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Count <= 50)
            {
                return shoppingCart.Product.Price;
            }
            else
            {
                if (shoppingCart.Count <= 100)
                {
                    return shoppingCart.Product.Price50;
                }
                else
                {
                    return shoppingCart.Product.Price100;
                }
            }
        }
    }
}
