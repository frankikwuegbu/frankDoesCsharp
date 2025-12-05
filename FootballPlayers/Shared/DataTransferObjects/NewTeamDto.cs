namespace Shared.DataTransferObjects;

public record NewTeamDto(string Name, string City, string Country, 
        IEnumerable<CreatePlayerDto> Players);
