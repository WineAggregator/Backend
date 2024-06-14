using AutoMapper;

using Backend.Api.Dto;
using Backend.Database.Models;
using Backend.Database.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/v1/tickets")]
public class TicketController(
    TicketRepository ticketRepository,
    EventRepository eventRepository,
    UserRepository userRepository,
    IMapper mapper)
{
    private readonly TicketRepository _ticketRepository = ticketRepository;
    private readonly EventRepository _eventRepository = eventRepository;
    private readonly UserRepository _userRepository = userRepository;

    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<GetManyTicketsDto> GetAllUserTickets([FromHeader] UserAuthInfo authInfo)
    {
        var userTickets = await _ticketRepository.GetAllUserTickets(userId: authInfo.Id);
        var mappedTickets = userTickets.Select(t => _mapper.Map<GetTicketDto>(t)).ToList();
        return new GetManyTicketsDto { Tickets = mappedTickets };
    }

    [HttpGet]
    [Route("{ticketId}")]
    public async Task<GetTicketDto> GetTicketById([FromRoute] int ticketId)
    {
        var ticket = await _ticketRepository.GetEntityByIdAsync(ticketId);
        var mappedTicket = _mapper.Map<GetTicketDto>(ticket);

        return mappedTicket;
    }

    [HttpPost]
    public async Task<int> CreateTicket([FromHeader] UserAuthInfo authInfo, [FromBody] CreateTicketDto ticketDto)
    {
        var eventObject = await _eventRepository.GetEntityByIdAsync(ticketDto.EventId);
        if (eventObject is null)
            throw new BadHttpRequestException("Нет события с таким id", 422);

        var user = await _userRepository.GetEntityByIdAsync(authInfo.Id);
        if (user is null)
            throw new BadHttpRequestException("Нет пользователя с таким id", 401);

        var newTicket = new Ticket
        {
            Event = eventObject,
            User = user,
            IsActivated = false
        };

        var ticketId = await _ticketRepository.CreateEntityAsync(newTicket);

        return ticketId;
    }

    [HttpGet]
    [Route("{ticketId}/check/organizer")]
    public async Task<CheckOrganizerTicketDto> CheckOrganizer([FromHeader] UserAuthInfo authInfo, [FromRoute] int ticketId)
    {
        return new CheckOrganizerTicketDto { IsOrganizer = await CheckOrganizer(ticketId, authInfo.Id) };
    }

    [HttpGet]
    [Route("{ticketId}/check/activated")]
    public async Task<CheckActivationTicketDto> Check([FromRoute] int ticketId)
    {
        return new CheckActivationTicketDto { IsActivated = await CheckIsActivated(ticketId) };
    }


    [HttpGet]
    [Route("{ticketId}/activate")]
    public async Task<ActivateTicketResponseDto> Activate([FromHeader] UserAuthInfo authInfo, [FromRoute] int ticketId)
    {
        var isOrganizer = await CheckOrganizer(ticketId, authInfo.Id);
        if (!isOrganizer)
            throw new BadHttpRequestException("Вы не организатор", 401);

        var isAlreadyActivated = await CheckIsActivated(ticketId);
        if (isAlreadyActivated)
            throw new BadHttpRequestException("Билет уже активирован", 409);

        try
        {
            await _ticketRepository.ActivateTicket(ticketId);
        }
        catch
        {
            return new ActivateTicketResponseDto { IsActivated = false };
        }
        
        return new ActivateTicketResponseDto { IsActivated = true };
    }

    private async Task<bool> CheckOrganizer(int ticketId, int userId)
    {
        var ticket = await _ticketRepository.GetEntityByIdAsync(ticketId);
        if (ticket is null)
            throw new BadHttpRequestException("Нет билета с таким id", 422);

        return ticket.Event.Organizer.Id == userId;
    }

    private async Task<bool> CheckIsActivated(int ticketId)
    {
        var ticket = await _ticketRepository.GetEntityByIdAsync(ticketId);
        if (ticket is null)
            throw new BadHttpRequestException("Нет билета с таким id", 422);

        return ticket.IsActivated;
    }
}
