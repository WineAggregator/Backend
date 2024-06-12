using Backend.Database.Enums;
using Backend.Database.Models;

namespace Backend.Api.Dto;

public class CreateEventDto
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string Address { get; init; }
    public required double Price { get; init; }
    public string? Link { get; init; }

    public required EventType EventType { get; init; }
    public required DateTime DateFrom { get; init; }
    public required DateTime DateTo { get; init; }

    public required string OrganizerName { get; init; }
}

public class GetEventDto
{
    public required int Id { get; init; }

    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string Address { get; init; }
    public required double Price { get; init; }
    public string? Link { get; init; }

    public required EventType EventType { get; init; }
    public required DateTime DateFrom { get; init; }
    public required DateTime DateTo { get; init; }

    public required string OrganizerName { get; init; }

    public required string PreviewPhotoLink { get; init; }
}

public class GetAllEventsDto
{
    public required List<GetEventDto> Events { get; init; } = [];
}

public class UpdateEventDto : BaseUpdateDto<Event>
{
    public string? Title { get; init; }
    public string? Description { get; init; }
    public string? Address { get; init; }
    public double? Price { get; init; }
    public string? Link { get; init; }
    public EventType? EventType { get; init; }
    public DateTime? DateFrom { get; init; }
    public DateTime? DateTo { get; init; }
    public string? OrganizerName { get; init; }

    public override Event UpdateEntity(Event entityToUpdate)
    {
        if (Title is not null)
            entityToUpdate.Title = Title;

        if (Description is not null)
            entityToUpdate.Description = Description;

        if (Address is not null)
            entityToUpdate.Address = Address;

        if (Price is not null)
            entityToUpdate.Price = Price.Value;

        if (Link is not null)
            entityToUpdate.Link = Link;

        if (EventType is not null)
            entityToUpdate.EventType = EventType.Value;

        if (DateFrom is not null)
            entityToUpdate.DateFrom = DateFrom.Value;

        if (DateTo is not null)
            entityToUpdate.DateTo = DateTo.Value;

        if (OrganizerName is not null)
            entityToUpdate.OrganizerName = OrganizerName;

        return entityToUpdate;
    }
}