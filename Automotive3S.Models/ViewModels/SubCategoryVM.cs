using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automotive3S.Models.ViewModels
{
    public class SubCategoryVM
    {
        public SubCategory SubCategory { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }

    }
}
