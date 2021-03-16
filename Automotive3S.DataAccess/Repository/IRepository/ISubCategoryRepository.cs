using Automotive3S.Models;


namespace Automotive3S.DataAccess.Repository.IRepository
{
    public interface ISubCategoryRepository: IRepository<SubCategory>
    {
        void Update(SubCategory category);
    }
}
