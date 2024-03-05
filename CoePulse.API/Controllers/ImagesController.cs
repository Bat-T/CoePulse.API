using CoePulse.API.Models.Domain;
using CoePulse.API.Models.DTO;
using CoePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] string fileName, [FromForm] string title)
        {
            validateFormFile(file);

            //File Upload
            var blogFile = new BlogImage
            {
                Title = title,
                FileName = fileName,
                FileExtension = Path.GetExtension(file.FileName),
                DateCreated = DateTime.Now
            };

            var createdBlogFile = await imageRepository.UploadImage(file, blogFile);

            //convert domainModel to DTO
            var blogImageDTO = new BlogImageDTO
            {
                Id = createdBlogFile.Id,
                Title = createdBlogFile.Title,
                FileName = createdBlogFile.FileName,
                FileExtension = createdBlogFile.FileExtension,
                DateCreated = createdBlogFile.DateCreated,
                Url = createdBlogFile.Url
            };

            return Ok(blogImageDTO);
        }

        private void validateFormFile(IFormFile file)
        {
            /* should check null and check valid extension*/
            if (file == null)
            {
                ModelState.AddModelError("file", "File is null");
                return;
            }
            /* check valid extension */
            if (file.Length == 0)
            {
                ModelState.AddModelError("file", "File is empty");
            }

            var allowedFileExtension = new string[] { ".jpg", ".png", ".jpeg" };
            var fileExtension = Path.GetExtension(file.FileName);
            if (!allowedFileExtension.Contains(fileExtension))
            {
                ModelState.AddModelError("file", "File extension not allowed");
            }
            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size should be less than 1 MB");
            }
        }
    }
}
