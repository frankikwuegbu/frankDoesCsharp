using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FootballPlayers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Team, TeamDto>()
        .ForCtorParam("Location",
        opt => opt.MapFrom(x => ($"{x.City}, {x.Country}")));

        CreateMap<Player, PlayerDto>();

        CreateMap<NewTeamDto, Team>();
    }
}
