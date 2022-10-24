namespace WebApi.Dto
{
    public class MediaDto
    {
        public string FileName { get; set; }
        public string MediaType { get; set; }
        public string FileExtension { get; set; }
        public string FileUrl { get; set; }
        public IFormFile Files { get; set; }
    }
}
