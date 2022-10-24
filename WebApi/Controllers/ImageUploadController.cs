using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        //private readonly IFileManagement _fileManagement;
        public ImageUploadController(IWebHostEnvironment environment)
        {
            this._environment = environment;
            //this._fileManagement = fileManagement;
        }

        [HttpPost]
        public async Task<MediaDto> UploadImage([FromForm] FileUploadModel model)
        {
            (bool response, MediaDto fileDetails, string message) = await SaveImage(model.File);
            return fileDetails;
        }

        [NonAction]
        public async Task<(bool, MediaDto, string)> SaveImage(IFormFile imageFile)
        {
            string[] allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string message = "success";

            string extension = Path.GetExtension(imageFile.FileName);
            if (imageFile.Length > 2000000) message = "Big Image";
            else if (extension == null) message = "png or jpg";

            bool isExists = Directory.Exists("Images");
            if (!isExists) Directory.CreateDirectory("Images");

            string fileName = $"{DateTime.Now.Ticks.ToString()}{extension}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);

            try
            {
                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                var media = new MediaDto()
                {
                    FileName = imageFile.FileName,
                    FileExtension = extension,
                    FileUrl = $"Images/{fileName}",
                    MediaType = imageFile.ContentType,
                };

                return (true, media, message);

            }
            catch { }


            return (false, null, message);
        }
    }
}
