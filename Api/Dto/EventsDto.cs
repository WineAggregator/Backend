using Backend.Database.Enums;

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
    public List<GetEventDto> Events { get; init; }
}