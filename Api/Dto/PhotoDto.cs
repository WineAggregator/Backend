namespace Backend.Api.Dto;

public class UrlToGetFileDto
{
    public string Url { get; set; }
}

public class UploadPhotoDto
{
    public required IFormFile Photo { get; set; }
}
