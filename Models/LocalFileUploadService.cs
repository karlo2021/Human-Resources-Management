using Microsoft.AspNetCore.Http;

namespace IdentityApp.Models;
public class LocalFileUploadService : IFileUploadService
{
    private readonly IWebHostEnvironment env;
    public PersonDbContext DbContext { get; set; }
    public LocalFileUploadService(IWebHostEnvironment env, PersonDbContext db)
    {
        DbContext = db;
        this.env = env;
    }
    public async Task UploadFile(IFormFile file)
    {
        var filePath = Path.Combine(env.ContentRootPath, @"wwwroot\images", file.FileName);
        
        var day = DbContext.Days.First<Day>();
        if (day != null) {
            filePath = Path.Combine(env.ContentRootPath, day.CvLocation, file.FileName);
        }

        using var fileStream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fileStream);
    }
}