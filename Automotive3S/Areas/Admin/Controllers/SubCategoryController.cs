using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automotive3S.Data;
using Automotive3S.DataAccess.Repository.IRepository;
using Automotive3S.Models;
using Automotive3S.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Automotive3S.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;

        public SubCategoryController(IUnitOfWork unitOfWork, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_unitOfWork.SubCategory.GetAll(includeProperties:"Category"));
        }
       
        public IActionResult Upsert(int? id)
        {
            IEnumerable<Category> Categories = _unitOfWork.Category.GetAll();

            SubCategoryVM subCategoryVM = new SubCategoryVM()
            {
                SubCategory = new SubCategory(),
                CategoryList = Categories.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            if (id == null)
            {
                return View(subCategoryVM);
            }

            subCategoryVM.SubCategory = _unitOfWork.SubCategory.Get(id.GetValueOrDefault());
            if (subCategoryVM.SubCategory == null)
            {
                return NotFound();

            }
            return View(subCategoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(SubCategoryVM subcategoryVM)
        {
            if (ModelState.IsValid)
            {
                if (subcategoryVM.SubCategory.Id == 0)
                {
                    _unitOfWork.SubCategory.Add(subcategoryVM.SubCategory);
                }
                else
                {
                    _unitOfWork.SubCategory.Update(subcategoryVM.SubCategory);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(subcategoryVM);
        }
        #region API CALLS

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.SubCategory.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.SubCategory.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful." });

        }


        #endregion

        [ActionName("GetSubCategory")]
        public async Task<IActionResult> GetSubCategory(int id)
        {
            List<SubCategory> subCategories = new List<SubCategory>();

            subCategories = await (from subCategory in _db.SubCategory
                                   where subCategory.CategoryId == id
                                   select subCategory).ToListAsync();
            return Json(new SelectList(subCategories, "Id", "Name"));
        }

    }
}
