using CoePulse.API.Models.Domain;

namespace CoePulse.API.Repositories.Interface
{
    public interface IImageRepository
    {
        public Task<BlogImage> UploadImage(IFormFile file,BlogImage blogimage);
    }
}
