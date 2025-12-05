namespace Entities.Exceptions;

public class PlayerNotFoundExcetption :NotFoundException
{
    public PlayerNotFoundExcetption(Guid playerId) : base($"Employee with id: {playerId} doesn't exist in the database.")
    {
    }
}
