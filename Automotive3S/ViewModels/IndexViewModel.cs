using Automotive3S.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automotive3S.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<AutoPart> AutoPartList { get; set; }
    }
}
