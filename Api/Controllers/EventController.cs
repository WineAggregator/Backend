using Backend.Api.Dto;
using Backend.Api.Services;
using Backend.Database.Models;
using Backend.Database.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/v1/events")]
public class EventController(
    UserRepository _userRepository,
    EventRepository _eventRepository,
    PhotoManager _photoManager) : ControllerBase
{
    [HttpGet]
    public async Task<GetAllEventsDto> GetAllEvents()
    {
        var events = await _eventRepository.GetAllEntitiesAsync() ?? [];
        return new GetAllEventsDto { Events = events.Select(MapEventToGetDto).ToList() };
    }

    [HttpGet]
    [Route("{eventId}")]
    public async Task<GetEventDto> GetAllEvents([FromRoute] int eventId)
    {
        var eventObject = await _eventRepository.GetEntityByIdAsync(eventId);
        return MapEventToGetDto(eventObject);
    }

    [HttpPost]
    public async Task<int> CreateEvent([FromHeader] UserAuthInfo authInfo, [FromBody] CreateEventDto dto)
    {
        var user = await _userRepository.GetEntityByIdAsync(authInfo.Id);
        if (user is null)
            throw new BadHttpRequestException("Ќет пользовател€ с таким id", 401);

        if (user.Role != Database.Enums.Role.Manager)
            throw new BadHttpRequestException("¬ы не можете создавать свои мероприти€, так как €вл€етесь пользователем", 403);

        var eventObject = MapCreateDtoToModel(dto, user);
        var id = await _eventRepository.CreateEntityAsync(eventObject);

        return id;
    }

    [HttpPatch]
    [Route("{eventId}")]
    public async Task UpdateEvent([FromRoute] int eventId, [FromBody] UpdateEventDto updateEventDto)
    {
        await _eventRepository.UpdateEntityAsync(eventId, updateEventDto);
    }

    [HttpPost]
    [Route("{eventId}/preview")]
    public async Task<UrlToGetPhotoDto> SetPreview([FromRoute] int eventId, [FromForm] UploadPhotoDto photoDto)
    {
        var photoUrl = await _photoManager.UploadPhotoAndGetUrl(photoDto.Photo);
        await _eventRepository.SetPreview(eventId, photoUrl);

        return new UrlToGetPhotoDto { Url = photoUrl };
    }

    [HttpPost]
    [Route("{eventId}/gallery")]
    public async Task<GetUrlsForMultiplePhotos> UploadGallery([FromRoute] int eventId, [FromForm] UploadMultiplePhotosDto photoDto)
    {
        var urls = new List<UrlToGetPhotoDto>();

        foreach (var photo in photoDto.Photos)
        {
            var photoUrl = await _photoManager.UploadPhotoAndGetUrl(photo);
            urls.Add(new UrlToGetPhotoDto { Url = photoUrl });
        }

        return new GetUrlsForMultiplePhotos { Urls = urls };
    }

    private GetEventDto MapEventToGetDto(Event eventObject)
    {
        return new GetEventDto() {
            Address = eventObject.Address,
            DateFrom = eventObject.DateFrom,
            DateTo = eventObject.DateTo,
            Description = eventObject.Description,
            EventType = eventObject.EventType,
            Id = eventObject.Id,
            Link = eventObject.Link,
            OrganizerName = eventObject.OrganizerName,
            PreviewPhotoLink = eventObject.PreviewPhotoLink,
            Price = eventObject.Price,
            Title = eventObject.Title,
        };
    }

    private Event MapCreateDtoToModel(CreateEventDto dto, User user)
    {
        return new Event()
        {
            EventType = dto.EventType,
            DateFrom = dto.DateFrom,
            DateTo = dto.DateTo,
            Description = dto.Description,
            Address = dto.Address,
            Link = dto.Link ?? "",
            Organizer = user,
            OrganizerName = dto.OrganizerName,
            Price = dto.Price,
            Title = dto.Title,
            PreviewPhotoLink = GetLinkToPhoto(null),
        };
    }

    private string GetLinkToPhoto(Photo? photo)
    {
        return _photoManager.GetUrlToPhoto(photo?.Id ?? 0);
    }
}