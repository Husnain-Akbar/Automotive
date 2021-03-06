using Automotive3S.Data;
using Automotive3S.Data.Repository;
using Automotive3S.Data.Repository.IRepository;
using Automotive3S.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automotive3S.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            SubCategory = new SubCategoryRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            AutoPart = new AutoPartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            Coupon = new CouponRepository(_db);
            OrderDetails = new OrderDetailsRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public ISubCategoryRepository SubCategory { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IAutoPartRepository AutoPart { get; private set; }
        public ICouponRepository Coupon { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IOrderDetailsRepository OrderDetails { get; private set; }

        public IOrderHeaderRepository OrderHeader { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
