using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Automotive3S.Models;
using Automotive3S.DataAccess.Repository.IRepository;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Automotive3S.Utitlities;
using Automotive3S.ViewModels;

namespace Automotive3S.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private IndexViewModel IndexVM;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            IndexVM = new IndexViewModel()
            {
                CategoryList = _unitOfWork.Category.GetAll(),
                AutoPartList = _unitOfWork.AutoPart.GetAll(includeProperties: "Category,SubCategory")

            };
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var count = _unitOfWork.ShoppingCart
                    .GetAll(c => c.ApplicationUserId == claim.Value)
                    .ToList().Count();

                HttpContext.Session.SetInt32(SD.ssShoppingCart, count);
            }
        

            return View(IndexVM);
        }


        public IActionResult Details(int id)
        {
            var partFromDb = _unitOfWork.AutoPart.
                        GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,SubCategory");
            ShoppingCart cartObj = new ShoppingCart()
            {
                AutoPart = partFromDb,
                AutoPartId = partFromDb.Id
            };
            return View(cartObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize]
        public IActionResult Details(ShoppingCart CartObject)
        {
            CartObject.Id = 0;
            if (ModelState.IsValid)
            {
                //then we will add to cart
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                CartObject.ApplicationUserId = claim.Value;

                ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
                    u => u.ApplicationUserId == CartObject.ApplicationUserId && u.AutoPartId == CartObject.AutoPartId
                    , includeProperties: "AutoPart"
                    );

                if (cartFromDb == null)
                {
                    //no records exists in database for that product for that user
                    _unitOfWork.ShoppingCart.Add(CartObject);
                }
                else
                {
                    cartFromDb.Count += CartObject.Count;
                    //_unitOfWork.ShoppingCart.Update(cartFromDb);
                }
                _unitOfWork.Save();

                var count = _unitOfWork.ShoppingCart
                    .GetAll(c => c.ApplicationUserId == CartObject.ApplicationUserId)
                    .ToList().Count();

                //HttpContext.Session.SetObject(SD.ssShoppingCart, CartObject);
                HttpContext.Session.SetInt32(SD.ssShoppingCart, count);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                var partFromDb = _unitOfWork.AutoPart.
                        GetFirstOrDefault(u => u.Id == CartObject.AutoPartId, includeProperties: "Category,CoverType");
                ShoppingCart cartObj = new ShoppingCart()
                {
                    AutoPart = partFromDb,
                    AutoPartId = partFromDb.Id
                };
                return View(cartObj);
            }


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
