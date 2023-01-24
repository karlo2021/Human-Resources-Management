

namespace IdentityApp.Models;

public interface IFileUploadService 
{
    Task UploadFile(IFormFile file);
}
