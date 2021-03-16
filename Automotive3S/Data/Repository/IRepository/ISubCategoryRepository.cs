using Automotive3S.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Automotive3S.DataAccess.Repository.IRepository
{
    public interface ISubCategoryRepository: IRepository<SubCategory>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();

        void Update(SubCategory category);
    }
}
