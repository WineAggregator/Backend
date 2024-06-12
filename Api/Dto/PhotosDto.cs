namespace Backend.Api.Dto;

public class UrlToGetFileDto
{
    public string Url { get; init; }
}

public class UploadPhotoDto
{
    public required IFormFile Photo { get; init; }
}
