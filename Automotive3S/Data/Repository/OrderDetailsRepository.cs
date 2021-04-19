using Automotive3S.Data.Repository.IRepository;
using Automotive3S.DataAccess.Repository;
using Automotive3S.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automotive3S.Data.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderDetails obj)
        {
            _db.Update(obj);
        }
    }
}
