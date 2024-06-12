using Backend.Api.Dto;

using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/v1/tickets")]
public class TicketController
{
    [HttpGet]
    public async Task GetAllUserTickets([FromHeader] UserAuthInfo authInfo)
    {

    }

    [HttpPost]
    public async Task<IResult> CreateTicket()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("{ticketId}/check")]
    public async Task<CheckTicketDto> Check([FromRoute] int ticketId)
    {
        throw new NotImplementedException();
    }


    [HttpGet]
    [Route("{ticketId}/activate")]
    public async Task<IResult> Activate([FromRoute] int ticketId)
    {
        throw new NotImplementedException();
    }
}
