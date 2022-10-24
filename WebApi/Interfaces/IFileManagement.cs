using WebApi.Dto;

namespace WebApi.Interfaces
{
    public interface IFileManagement
    {
        Task<(bool, MediaDto, string)> SaveImage(IFormFile imageFile);
    }
}
