using Automotive3S.DataAccess.Data;
using Automotive3S.DataAccess.Repository.IRepository;
using Automotive3S.Models;
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


        public void Update(SubCategory subCategory)
        {
            var objFromDb = _db.SubCategory.FirstOrDefault(s => s.Id ==subCategory.Id);

            objFromDb.Name = subCategory.Name;

            _db.SaveChanges();
        }

    }
}
