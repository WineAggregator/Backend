using Backend.Database.Models;

namespace Backend.Api.Dto;

public class CreateEventDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Address { get; set; }
    public required double Price { get; set; }
    public string? Link { get; set; }

    public required EventType EventType { get; set; }
    public required DateTime DateFrom { get; set; }
    public required DateTime DateTo { get; set; }

    public required string OrganizerName { get; set; }
}

public class GetEventDto
{
    public required int Id { get; set; }

    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Address { get; set; }
    public required double Price { get; set; }
    public string? Link { get; set; }

    public required EventType EventType { get; set; }
    public required DateTime DateFrom { get; set; }
    public required DateTime DateTo { get; set; }

    public required string OrganizerName { get; set; }

    public required string PreviewPhotoLink { get; set; }
}