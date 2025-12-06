namespace Shared.DataTransferObjects;

public record TeamUpdateDto(string Name, string Country, string City,
    IEnumerable<CreatePlayerDto> Players);
