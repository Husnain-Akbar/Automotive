using Automotive3S.DataAccess.Repository.IRepository;
using Automotive3S.Models;
using Automotive3S.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Automotive3S.Data.Repository.IRepository
{
    public interface IAutoPartRepository :IRepository<AutoPart>
    {
        Task<int> AddNewPart(AutoPartViewModel model);
        Task<List<AutoPart>> GetAllParts();
        Task<AutoPart> GetPArtById(int id);
        Task<List<AutoPart>> GetTopPartsAsync(int count);
        //List<AutoPartViewModel> SearchPart(string name, string authorName);



    }
}
