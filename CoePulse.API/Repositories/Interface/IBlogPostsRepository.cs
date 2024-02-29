using CoePulse.API.Models.Domain;
using CoePulse.API.Models.DTO;

namespace CoePulse.API.Repositories.Interface
{
    public interface IBlogPostsRepository
    {
        public Task<BlogPost> CreateAsync(BlogPost request);
        public Task<List<BlogPost>> GetAllAsync();
        public Task<BlogPost?> GetAsync(Guid id);

        public Task<BlogPost?> UpdateAsync(BlogPost request);

        public Task<BlogPost?> DeleteAsync(Guid id);
    }
}
