using Automotive3S.Data;
using Automotive3S.DataAccess.Repository.IRepository;
using Automotive3S.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automotive3S.DataAccess.Repository
{
    public class SubCategoryRepository: Repository<SubCategory>, ISubCategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public SubCategoryRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {

            return _db.SubCategory.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(SubCategory subCategory)
        {
            var objFromDb = _db.SubCategory.FirstOrDefault(s => s.Id ==subCategory.Id);

            objFromDb.Name = subCategory.Name;

            _db.SaveChanges();
        }

    }
}
