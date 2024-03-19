using CoePulse.API.Models.Domain;
using CoePulse.API.Models.DTO;
using CoePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController(IBlogPostsRepository blogPostsRepository, ICategoryRepository categoryRepository) : ControllerBase
    {
        private readonly IBlogPostsRepository blogPostsRepository = blogPostsRepository;
        private readonly ICategoryRepository categoryRepository = categoryRepository;

        [HttpPost]
        [Produces<BlogPostDTO>]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDto request)
        {
            var blogpostRequest = new BlogPost
            {
                Title = request.Title,
                Author = request.Author,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                IsVisible = request.IsVisible,
                PublishedDate = request.PublishedDate,
                ShortDescription = request.ShortDescription,
                UrlHandle = request.UrlHandle,
                Categories = new List<Category>()
            };

            foreach (var category in request.Categories)
            {
                var existingcategory = await categoryRepository.GetCategoryByID(category);
                if (existingcategory is not null)
                {
                    blogpostRequest.Categories.Add(existingcategory);
                }
            }

            var createdBlogPost = await blogPostsRepository.CreateAsync(blogpostRequest);

            BlogPostDTO response = new BlogPostDTO
            {
                Id = createdBlogPost.Id,
                UrlHandle = createdBlogPost.UrlHandle,
                ShortDescription = createdBlogPost.ShortDescription,
                Author = createdBlogPost.Author,
                Content = createdBlogPost.Content,
                FeaturedImageUrl = createdBlogPost.FeaturedImageUrl,
                IsVisible = createdBlogPost.IsVisible,
                PublishedDate = createdBlogPost.PublishedDate,
                Title = createdBlogPost.Title,
                Categories = createdBlogPost.Categories == null ? new List<CategoryDTO>() : createdBlogPost.Categories.Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()
            };

            return Ok(response);
        }

        [HttpGet]
        [Produces<List<BlogPostDTO>>]
        public async Task<IActionResult> GetAllAsync()
        {
            var allBlogPosts = await blogPostsRepository.GetAllAsync();
            if (allBlogPosts.Count == 0)
            {
                return NoContent();
            }
            var convertedResult = allBlogPosts.Select(x => new BlogPostDTO
            {
                Id = x.Id,
                UrlHandle = x.UrlHandle,
                Author = x.Author,
                Content = x.Content,
                FeaturedImageUrl = x.FeaturedImageUrl,
                ShortDescription = x.ShortDescription,
                IsVisible = x.IsVisible,
                PublishedDate = x.PublishedDate,
                Title = x.Title,
                Categories = x.Categories == null ? new List<CategoryDTO>() : x.Categories.Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()
            });

            return Ok(convertedResult);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var blogPost = await blogPostsRepository.GetAsync(id);
            if (blogPost == null) { return NotFound(); }
            return Ok(new BlogPostDTO
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                IsVisible = blogPost.IsVisible,
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle,
                Categories = blogPost.Categories == null ? new List<CategoryDTO>() : blogPost.Categories.Select(x => new CategoryDTO { Id = x.Id, Name = x.Name, UrlHandle = x.UrlHandle }).ToList()
            });
        }

        //GET: api/BlogPosts/{urlHandle}
        [HttpGet]
        [Route("{urlHandle}")]
        public async Task<IActionResult> GetByUrlHandleAsync([FromRoute] string urlHandle)
        {
            var blogPost = await blogPostsRepository.GetByUrlHandleAsync(urlHandle);
            if (blogPost == null) { return NotFound(); }
            return Ok(new BlogPostDTO
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                IsVisible = blogPost.IsVisible,
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle,
                Categories = blogPost.Categories == null ? new List<CategoryDTO>() : blogPost.Categories.Select(x => new CategoryDTO { Id = x.Id, Name = x.Name, UrlHandle = x.UrlHandle }).ToList()
            });
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateBlogPostRequestDto request)
        {
            var blogPost = new BlogPost
            {
                Id = id,
                Title = request.Title,
                Author = request.Author,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                IsVisible = request.IsVisible,
                PublishedDate = request.PublishedDate,
                ShortDescription = request.ShortDescription,
                UrlHandle = request.UrlHandle,
                Categories = new List<Category>()
            };

            foreach (var category in request.Categories)
            {
                var existingcategory = await categoryRepository.GetCategoryByID(category);
                if (existingcategory is not null)
                {
                    blogPost.Categories.Add(existingcategory);
                }
            }

            var updatedBlogPost = await blogPostsRepository.UpdateAsync(blogPost);

            if (updatedBlogPost == null) { return NotFound(); }
            return Ok(new BlogPostDTO
            {
                Id = updatedBlogPost.Id,
                UrlHandle = updatedBlogPost.UrlHandle,
                ShortDescription = updatedBlogPost.ShortDescription,
                Author = updatedBlogPost.Author,
                Content = updatedBlogPost.Content,
                FeaturedImageUrl = updatedBlogPost.FeaturedImageUrl,
                IsVisible = updatedBlogPost.IsVisible,
                PublishedDate = updatedBlogPost.PublishedDate,
                Title = updatedBlogPost.Title,
                Categories = updatedBlogPost.Categories == null ? new List<CategoryDTO>() : updatedBlogPost.Categories.Select(x => new CategoryDTO {
                    Id = x.Id, Name = x.Name, UrlHandle = x.UrlHandle 
                }).ToList()
            });

        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var deletedBlogPost = await blogPostsRepository.DeleteAsync(id);
            if (deletedBlogPost == null) { return NotFound(); }
            return Ok(new BlogPostDTO
            {
                Author = deletedBlogPost.Author,
                Content = deletedBlogPost.Content,
                FeaturedImageUrl = deletedBlogPost.FeaturedImageUrl,
                IsVisible = deletedBlogPost.IsVisible,
                PublishedDate = deletedBlogPost.PublishedDate,
                ShortDescription = deletedBlogPost.ShortDescription,
                Title = deletedBlogPost.Title,
                UrlHandle = deletedBlogPost.UrlHandle
            });
        }
    }
}
