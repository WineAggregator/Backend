namespace Backend.Api.Dto;

public class CheckOrganizerTicketDto
{
    public bool IsOrganizer { get; init; }
}

public class CheckActivationTicketDto
{
    public bool IsActivated { get; init; }
}

public class GetTicketDto
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public int EventId { get; init; }
    public bool IsActivated { get; init; }
}

public class GetManyTicketsDto
{
    public List<GetTicketDto> Tickets { get; init; } = [];
}

public class CreateTicketDto
{
    public int EventId { get; init; }
}

public class ActivateTicketResponseDto
{
    public bool IsActivated { get; init; }
}