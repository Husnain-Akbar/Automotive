using System;
using System.Collections.Generic;
using System.Text;

namespace Automotive3S.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        ICategoryRepository Category { get; }
        ISubCategoryRepository SubCategory { get; }
        void Save();
    }
}
