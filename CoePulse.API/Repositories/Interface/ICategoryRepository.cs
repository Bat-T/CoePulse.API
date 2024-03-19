using CoePulse.API.Models.Domain;
using CoePulse.API.Models.DTO;

namespace CoePulse.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category?> CreateAsync(Category category);
        Task<List<Category>> GetAllCategory();
        Task<Category?> GetCategoryByID(Guid id);
        Task<Category?> UpdateCategory(Category request);

        Task<Category?> DeleteCategoryByID(Guid id);
    }
}