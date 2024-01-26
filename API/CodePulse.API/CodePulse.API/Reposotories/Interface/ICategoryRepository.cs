using CodePulse.API.Models.Domain;

namespace CodePulse.API.Reposotories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
