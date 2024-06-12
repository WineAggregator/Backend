using Backend.Api.Dto;
using Backend.Api.Services;
using Backend.Database.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/v1/photos")]
public class PhotoController(PhotoRepository _photoRepository, PhotoManager _photoManager)
{
    [HttpGet]
    [Route("{photoId}")]
    public async Task<IResult> GetPhoto([FromRoute] int photoId)
    {
        var photoObject = await _photoRepository.GetEntityByIdAsync(photoId);
        var photoBytes = photoObject is not null ? await _photoManager.GetPhoto(photoObject) : await _photoManager.GetStandardPhoto();

        return Results.File(fileContents: photoBytes, contentType: "image/png");
    }

    [HttpPost]
    [Route("upload")]
    public async Task<BaseIdDto> UploadPhoto([FromForm] UploadPhotoDto photoDto)
    {
        var photoId = await _photoManager.UploadPhotoAndGetId(photoDto.Photo);

        return new BaseIdDto { Id = photoId };
    }
}
