using Backend.Database.Models;
using Backend.Database.Repositories;

namespace Backend.Api.Services;

public class PhotoManager(
    PhotoRepository _photoRepository,
    IHttpContextAccessor _httpContextAccessor,
    IConfiguration _config)
{
    public async Task<byte[]> GetPhoto(Photo photo)
    {
        var photoBytes = await GetPhotoBytes(photo.PhotoPath);
        return photoBytes;
    }

    // Должна возвращать ссылку на закачку фото
    public async Task<string> UploadPhoto(IFormFile file)
    {
        var filePath = GeneratePath(file.FileName);

        using (var fileStream = new FileStream(path: filePath, mode: FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        var photoObjectToCreate = new Photo { PhotoPath = filePath };
        var photoId = await _photoRepository.CreateEntityAsync(photoObjectToCreate);

        var photoUrl = GetUrlToPhoto(photoId);

        return photoUrl;
    }

    public async Task<byte[]> GetStandardPhoto()
    {
        return await GetPhotoBytes(photoPath: $"{GetPhotosDirectoryPath()}/standard_photo.png");
    }

    public string GetUrlToPhoto(int photoId)
    {
        var context = _httpContextAccessor.HttpContext;

        var protocolString = (context.Request.IsHttps ? "https" : "http") ?? "http";
        var host = context?.Request.Host;


        return $"{protocolString}://{host}/api/v1/photos/{photoId}";
    }

    private static async Task<byte[]> GetPhotoBytes(string photoPath)
    {
        return await File.ReadAllBytesAsync(photoPath);
    }

    private static string GetRandomGuid()
    {
        return Guid.NewGuid().ToString("N");
    }

    private string GeneratePath(string fileName)
    {
        var directory = GetPhotosDirectoryPath();
        CreateDirectoryIfNotExists(directory);

        var guid = GetRandomGuid();
        var filePath = Path.Combine(directory, guid);

        var extension = Path.GetExtension(fileName);
        if (extension is not null)
            filePath += extension;

        return filePath;
    }

    private static void CreateDirectoryIfNotExists(string path)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }

    private string GetPhotosDirectoryPath()
    {
        return _config["Photos:Directory"] ?? "/static_files/photos";
    }
}
