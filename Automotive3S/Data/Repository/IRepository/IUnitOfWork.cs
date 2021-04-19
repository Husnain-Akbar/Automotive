using Automotive3S.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automotive3S.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        ICategoryRepository Category { get; }
        ISubCategoryRepository SubCategory { get; }
        IShoppingCartRepository ShoppingCart { get; }

        IAutoPartRepository AutoPart { get; }

        IApplicationUserRepository ApplicationUser { get; }
        ICouponRepository Coupon { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IOrderHeaderRepository OrderHeader { get; }
        void Save();
    }
}
