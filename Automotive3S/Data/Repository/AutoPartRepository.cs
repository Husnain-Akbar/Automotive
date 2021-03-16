using Automotive3S.Data.Repository.IRepository;
using Automotive3S.DataAccess.Repository;
using Automotive3S.DataAccess.Repository.IRepository;
using Automotive3S.Models;
using Automotive3S.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automotive3S.Data.Repository
{
    public class AutoPartRepository : IAutoPartRepository
    {
        public readonly ApplicationDbContext _db;
        public AutoPartRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<int> AddNewPart(AutoPartViewModel model)
        {
            var newPart = new AutoPart()
            {

                Name = model.autoPart.Name,
                ListPrice = model.autoPart.ListPrice,
                Price = model.autoPart.Price,
                Price50 = model.autoPart.Price50,
                Price100 = model.autoPart.Price100,
                Description = model.autoPart.Description,
                SellerComments = model.autoPart.Description,
                MainImageUrl = model.autoPart.MainImageUrl,
                CreatedOn = DateTime.UtcNow,
                CategoryId = model.autoPart.CategoryId,
                SubCategoryId = model.autoPart.SubCategoryId
            };
            newPart.PartGallery = new List<PartGallery>();

            foreach (var file in model.Gallery)
            {
                newPart.PartGallery.Add(new PartGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _db.AutoParts.AddAsync(newPart);
            await _db.SaveChangesAsync();

            return newPart.Id;
        }

        public async Task<List<AutoPart>> GetAllParts()
        {
            return await _db.AutoParts.Include(x=>x.Category).Include(x=>x.SubCategory).Include(x=>x.PartGallery)
                .ToListAsync();
        }

        public async Task<AutoPart> GetPArtById(int id)
        {


            return await _db.AutoParts.Include(x=>x.Category).Include(x=>x.SubCategory).Include(x=>x.PartGallery)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            
        }

        public async Task<List<AutoPart>> GetTopPartsAsync(int count)
        {
           
            return await _db.AutoParts.Include(x => x.Category).Include(x => x.SubCategory).Include(x => x.PartGallery)
                .ToListAsync();
        }
    }
}