using CoePulse.API.Data;
using CoePulse.API.Models.Domain;
using CoePulse.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoePulse.API.Repositories.Implementation
{
    public class ImageRepository : IImageRepository
    {
        public readonly IWebHostEnvironment webHostEnvironment;
        public readonly IHttpContextAccessor httpContextAccessor;
        public readonly ApplicationDbContext context;

        public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.context = context;
        }

        public async Task<IEnumerable<BlogImage>> GetAllAsync()
        {
            return await context.BlogImages.ToListAsync();
        }

        public async Task<BlogImage> UploadImage(IFormFile file, BlogImage blogImage)
        {
            //upload file to localpath
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images");

            //check if directory exists, if not, create it
            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
            }
            var filePath = Path.Combine(localPath, $"{blogImage.FileName}{blogImage.FileExtension}");
            //copy file to local path
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            //update database
            var httpRequest = httpContextAccessor.HttpContext?.Request;
            if (httpRequest != null)
            {
                var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{blogImage.FileName}{blogImage.FileExtension}";
                blogImage.Url = urlPath;
            }

            await context.BlogImages.AddAsync(blogImage);
            await context.SaveChangesAsync();
            return blogImage;
        }
    }
}
