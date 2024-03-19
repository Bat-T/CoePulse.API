using CoePulse.API.Data;
using CoePulse.API.Models.Domain;
using CoePulse.API.Models.DTO;
using CoePulse.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoePulse.API.Repositories.Implementation
{
    public class BlogPostsRepository : IBlogPostsRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogPostsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BlogPost> CreateAsync(BlogPost request)
        {
            _context.BlogPosts.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<List<BlogPost>> GetAllAsync()
        {
           return await _context.BlogPosts.Include(x=>x.Categories).ToListAsync(); 
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            var blogPost = await _context.BlogPosts.Include(x=>x.Categories).FirstOrDefaultAsync(x => x.Id == id);
            if(blogPost is null) { return null; }

            return blogPost;
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost request)
        {
            var blogPost = await _context.BlogPosts.Include(x=>x.Categories).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (blogPost is null) { return null; }

            _context.Entry(blogPost).CurrentValues.SetValues(request);
            blogPost.Categories = request.Categories; 
            await _context.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var blogPost = await _context.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
            if(blogPost is null) { return null; }
            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            var existingBlogPost= await _context.BlogPosts.Include(x=>x.Categories).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
            if(existingBlogPost is null) { return null; }
            return existingBlogPost;
        }
    }
}
