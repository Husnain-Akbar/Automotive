using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Automotive3S.DataAccess.Repository.IRepository;
using Automotive3S.Models;
using Automotive3S.Utitlities;
using Automotive3S.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Automotive3S.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }



        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCartVM = new ShoppingCartVM()
            {
                OrderHeader = new Models.OrderHeader(),
                ListCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value, includeProperties: "AutoPart")
            };
            ShoppingCartVM.OrderHeader.OrderTotal = 0;
            ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser
                                                        .GetFirstOrDefault(u => u.Id == claim.Value,
                                                        includeProperties: "Showroom");

            foreach (var list in ShoppingCartVM.ListCart)
            {
                list.Price = SD.GetPriceBasedOnQuantity(list.Count, list.AutoPart.Price,
                                                    list.AutoPart.Price50, list.AutoPart.Price100);
                ShoppingCartVM.OrderHeader.OrderTotal += (list.Price * list.Count);
                list.AutoPart.Description = SD.ConvertToRawHtml(list.AutoPart.Description);
                if (list.AutoPart.Description.Length > 100)
                {
                    list.AutoPart.Description = list.AutoPart.Description.Substring(0, 99) + "...";
                }
            }
            ShoppingCartVM.OrderHeader.OrderTotalOriginal = ShoppingCartVM.OrderHeader.OrderTotal;


            if (HttpContext.Session.GetString(SD.ssCouponCode) != null)
            {
                ShoppingCartVM.OrderHeader.CouponCode = HttpContext.Session.GetString(SD.ssCouponCode);
                var couponFromDb =  _unitOfWork.Coupon.GetFirstOrDefault(c => c.Name.ToLower() == ShoppingCartVM.OrderHeader.CouponCode.ToLower());
                ShoppingCartVM.OrderHeader.OrderTotal = SD.DiscountedPrice(couponFromDb, ShoppingCartVM.OrderHeader.OrderTotalOriginal);
            }

            return View(ShoppingCartVM);
        }
        public IActionResult AddCoupon()
        {
            if (ShoppingCartVM.OrderHeader.CouponCode == null)
            {
                ShoppingCartVM.OrderHeader.CouponCode = "";
            }
            HttpContext.Session.SetString(SD.ssCouponCode, ShoppingCartVM.OrderHeader.CouponCode);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveCoupon()
        {

            HttpContext.Session.SetString(SD.ssCouponCode, string.Empty);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Plus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault
                            (c => c.Id == cartId, includeProperties: "AutoPart");
            cart.Count += 1;
            cart.Price = SD.GetPriceBasedOnQuantity(cart.Count, cart.AutoPart.Price,
                                    cart.AutoPart.Price50, cart.AutoPart.Price100);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault
                            (c => c.Id == cartId, includeProperties: "AutoPart");

            if (cart.Count == 1)
            {
                var cnt = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
                _unitOfWork.ShoppingCart.Remove(cart);
                _unitOfWork.Save();
                HttpContext.Session.SetInt32(SD.ssShoppingCart, cnt - 1);
            }
            else
            {
                cart.Count -= 1;
                cart.Price = SD.GetPriceBasedOnQuantity(cart.Count, cart.AutoPart.Price,
                                    cart.AutoPart.Price50, cart.AutoPart.Price100);
                _unitOfWork.Save();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault
                            (c => c.Id == cartId, includeProperties: "AutoPart");

            var cnt = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
            _unitOfWork.ShoppingCart.Remove(cart);
            _unitOfWork.Save();
            HttpContext.Session.SetInt32(SD.ssShoppingCart, cnt - 1);


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Summary()
        {
            

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCartVM = new ShoppingCartVM()
            {
                OrderHeader = new Models.OrderHeader(),
                ListCart = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value,
                                                            includeProperties: "AutoPart")
            };
            ShoppingCartVM.OrderHeader.OrderTotal = 0;
            ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser
                                                            .GetFirstOrDefault(c => c.Id == claim.Value,
                                                                includeProperties: "Showroom");

            foreach (var list in ShoppingCartVM.ListCart)
            {
                list.Price = SD.GetPriceBasedOnQuantity(list.Count, list.AutoPart.Price,
                                                    list.AutoPart.Price50, list.AutoPart.Price100);
                ShoppingCartVM.OrderHeader.OrderTotal += (list.Price * list.Count);
            }
            ShoppingCartVM.OrderHeader.OrderTotalOriginal = ShoppingCartVM.OrderHeader.OrderTotal;

            ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.ApplicationUser.Name;
            ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;
            ShoppingCartVM.OrderHeader.StreetAddress = ShoppingCartVM.OrderHeader.ApplicationUser.StreetAddress;
            ShoppingCartVM.OrderHeader.City = ShoppingCartVM.OrderHeader.ApplicationUser.City;
            ShoppingCartVM.OrderHeader.State = ShoppingCartVM.OrderHeader.ApplicationUser.State;
            ShoppingCartVM.OrderHeader.PostalCode = ShoppingCartVM.OrderHeader.ApplicationUser.PostalCode;
            if (HttpContext.Session.GetString(SD.ssCouponCode) != null)
            {
                ShoppingCartVM.OrderHeader.CouponCode = HttpContext.Session.GetString(SD.ssCouponCode);
                var couponFromDb = _unitOfWork.Coupon.GetFirstOrDefault(c => c.Name.ToLower() == ShoppingCartVM.OrderHeader.CouponCode.ToLower());
                ShoppingCartVM.OrderHeader.OrderTotal = SD.DiscountedPrice(couponFromDb, ShoppingCartVM.OrderHeader.OrderTotalOriginal);
            }
            return View(ShoppingCartVM);
        }

        [HttpPost]
        [ActionName("Summary")]
        [ValidateAntiForgeryToken]
        public IActionResult SummaryPost()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser
                                                            .GetFirstOrDefault(c => c.Id == claim.Value,
                                                                    includeProperties: "Showroom");

            ShoppingCartVM.ListCart = _unitOfWork.ShoppingCart
                                        .GetAll(c => c.ApplicationUserId == claim.Value,
                                        includeProperties: "AutoPart");

            ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
            ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusPending;
            ShoppingCartVM.OrderHeader.ApplicationUserId = claim.Value;
            ShoppingCartVM.OrderHeader.OrderDate = DateTime.Now;
            ShoppingCartVM.OrderHeader.ShippingDate = DateTime.Now.AddDays(7);
            _unitOfWork.OrderHeader.Add(ShoppingCartVM.OrderHeader);
            _unitOfWork.Save();
            ShoppingCartVM.OrderHeader.OrderTotalOriginal = 0;

            foreach (var item in ShoppingCartVM.ListCart)
            {
                item.Price = SD.GetPriceBasedOnQuantity(item.Count, item.AutoPart.Price,
                    item.AutoPart.Price50, item.AutoPart.Price100);
                OrderDetails orderDetails = new OrderDetails()
                {
                    AutoPartId = item.AutoPartId,
                    OrderId = ShoppingCartVM.OrderHeader.Id,
                    Price = item.Price,
                    Count = item.Count
                };
                ShoppingCartVM.OrderHeader.OrderTotalOriginal += orderDetails.Count * orderDetails.Price;
                _unitOfWork.OrderDetails.Add(orderDetails);

            }

            if (HttpContext.Session.GetString(SD.ssCouponCode) != null)
            {
                ShoppingCartVM.OrderHeader.CouponCode = HttpContext.Session.GetString(SD.ssCouponCode);
                var couponFromDb = _unitOfWork.Coupon.GetFirstOrDefault(c => c.Name.ToLower() == ShoppingCartVM.OrderHeader.CouponCode.ToLower());
                ShoppingCartVM.OrderHeader.OrderTotal = SD.DiscountedPrice(couponFromDb, ShoppingCartVM.OrderHeader.OrderTotalOriginal);
            }
            else
            {
                ShoppingCartVM.OrderHeader.OrderTotal = ShoppingCartVM.OrderHeader.OrderTotalOriginal;
            }
            ShoppingCartVM.OrderHeader.CouponCodeDiscount = ShoppingCartVM.OrderHeader.OrderTotalOriginal - ShoppingCartVM.OrderHeader.OrderTotal;

            _unitOfWork.ShoppingCart.RemoveRange(ShoppingCartVM.ListCart);
            _unitOfWork.Save();
            HttpContext.Session.SetInt32(SD.ssShoppingCart, 0);

           
                
                //process the payment
              

                
                    ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusRejected;
                
                
                
                    ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusApproved;
                    ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusApproved;
                    ShoppingCartVM.OrderHeader.PaymentDate = DateTime.Now;
                

            _unitOfWork.Save();

            return RedirectToAction("OrderConfirmation", "Cart", new { id = ShoppingCartVM.OrderHeader.Id });

        }
    }
}
