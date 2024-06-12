namespace Backend.Api.Dto;

public class UrlToGetPhotoDto
{
    public required string Url { get; init; }
}

public class GetUrlsForMultiplePhotos
{
    public List<UrlToGetPhotoDto> Urls { get; init; } = [];
}

public class UploadPhotoDto
{
    public required IFormFile Photo { get; init; }
}

public class UploadMultiplePhotosDto
{
    public required List<IFormFile> Photos { get; init; }
}