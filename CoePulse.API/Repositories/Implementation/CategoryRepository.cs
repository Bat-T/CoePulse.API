using CoePulse.API.Data;
using CoePulse.API.Models.Domain;
using CoePulse.API.Models.DTO;
using CoePulse.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoePulse.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category?> CreateAsync(Category category)
        {
            if (category == null) { return null; }
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> UpdateCategory(Category request)
        {
            var categ = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (categ == null)
                return categ;
            _context.Entry(categ).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync();
            return categ;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByID(Guid id)
        {
            return await _context.Categories.Where(x => x.Id == id).SingleOrDefaultAsync();

        }

        public async Task<Category?> DeleteCategoryByID(Guid id)
        {
            var existingCategory = await _context.Categories.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (existingCategory is null) { return null; }
            
            _context.Categories.Remove(existingCategory);
            await _context.SaveChangesAsync();
            return existingCategory;
        }
    }
}
