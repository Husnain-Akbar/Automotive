using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Automotive3S.Data.Repository.IRepository;
using Automotive3S.DataAccess.Repository.IRepository;
using Automotive3S.Models;
using Automotive3S.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Automotive3S.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AutoPartController : Controller
    {
        private readonly IAutoPartRepository _autoPartRepository ;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;

        public AutoPartController(IAutoPartRepository autoPartRepository,IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _autoPartRepository = autoPartRepository;
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
        }
        

        public IActionResult AddNewPart(bool isSuccess = false, int partId = 0)
        {
            IEnumerable<Category> CatList =  _unitOfWork.Category.GetAll();
            IEnumerable<SubCategory> SubCatList = _unitOfWork.SubCategory.GetAll();

            AutoPartViewModel autoPartViewModel = new AutoPartViewModel()
            {
                CategoryList = CatList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                SubCategoryList = SubCatList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            var model = autoPartViewModel;
            ViewBag.IsSuccess = isSuccess;
            ViewBag.PartId = partId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPart(AutoPartViewModel partModel)
        {
            if (ModelState.IsValid)
            {
                if (partModel.CoverPhoto != null)
                {
                    string folder = "parts/cover/";
                    partModel.CoverImageUrl = await UploadImage(folder, partModel.CoverPhoto);
                }

                if (partModel.GalleryFiles != null)
                {
                    string folder = "parts/gallery/";

                    partModel.Gallery = new List<GalleryModel>();

                    foreach (var file in partModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file)
                        };
                        partModel.Gallery.Add(gallery);
                    }
                }

               
                int id = await _autoPartRepository.AddNewPart(partModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewPart), new { isSuccess = true, bookId = id });
                }
            }

            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        //[Route("part-details/{id:int:min(1)}", Name = "partDetailsRoute")]
        public async Task<ViewResult> GetPart(int id)
        {
            var data = await _autoPartRepository.GetPArtById(id);

            var autopartViewModel = new AutoPartViewModel()
            {
                autoPart =data,
                CoverImageUrl = data.MainImageUrl,
                Gallery = data.PartGallery.Select(g => new GalleryModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    URL = g.URL
                }).ToList(),
            };

            return View(autopartViewModel);
        }
    }
}

 