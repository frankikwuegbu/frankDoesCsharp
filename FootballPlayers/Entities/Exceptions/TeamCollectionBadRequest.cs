namespace Entities.Exceptions;

public sealed class TeamCollectionBadRequest : BadRequestException
{
    public TeamCollectionBadRequest()
     : base("Team collection sent from a client is null.")
    {

    }
}
