namespace Entities.Exceptions;

public class PlayerNotFoundException :NotFoundException
{
    public PlayerNotFoundException(Guid playerId) : base($"Employee with id: {playerId} doesn't exist in the database.")
    {
    }
}
