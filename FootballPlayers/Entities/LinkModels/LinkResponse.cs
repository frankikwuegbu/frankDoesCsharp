using Shared.DataTransferObjects;

namespace Entities.LinkModels;

public class LinkResponse
{
    public bool HasLinks { get; set; }
    //public List<Entity> ShapedEntities { get; set; }
    public LinkCollectionWrapper<PlayerDto> LinkedEntities { get; set; }
    public LinkResponse()
    {
        LinkedEntities = new LinkCollectionWrapper<PlayerDto>();
        //ShapedEntities = new List<Entity>();
    }
}
