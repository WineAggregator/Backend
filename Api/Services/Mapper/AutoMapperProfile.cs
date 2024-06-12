using AutoMapper;

using Backend.Api.Dto;
using Backend.Database.Models;

namespace Backend.Api.Services.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Ticket, GetTicketDto>();
    }
}
