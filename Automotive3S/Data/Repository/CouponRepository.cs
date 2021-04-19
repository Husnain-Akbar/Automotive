using Automotive3S.Data.Repository.IRepository;
using Automotive3S.DataAccess.Repository;
using Automotive3S.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automotive3S.Data.Repository
{
    public class CouponRepository : Repository<Coupon>, ICouponRepository
    {
        private readonly ApplicationDbContext _db;

        public CouponRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
    }
}
