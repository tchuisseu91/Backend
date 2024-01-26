using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Reposotories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Reposotories.Implementation
{
   
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
