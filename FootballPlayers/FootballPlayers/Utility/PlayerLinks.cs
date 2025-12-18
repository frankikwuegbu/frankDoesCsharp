using Contracts;
using Entities.LinkModels;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
//using System.Net.Http.Headers;

namespace FootballPlayers.Utility;

public class PlayerLinks : IPlayerLinks
{
    private readonly LinkGenerator _linkGenerator;
    //private readonly IDataShaper<EmployeeDto> _dataShaper;

    public PlayerLinks(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
        //_dataShaper = dataShaper;
    }

    public LinkResponse TryGenerateLinks(IEnumerable<PlayerDto> playerDto, Guid teamId, HttpContext httpContext)
    {
        //if (ShouldGenerateLinks(httpContext))
        return ReturnLinkedPlayers(playerDto, teamId, httpContext);

        //return default;
    }

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        //var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];
        //return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas",
        //    StringComparison.InvariantCultureIgnoreCase);

        var accept = httpContext.Request.Headers["Accept"].ToString();

        return accept.Contains("hateoas", StringComparison.OrdinalIgnoreCase);

    }

    private LinkResponse ReturnLinkedPlayers(IEnumerable<PlayerDto> playersDto,
            Guid teamId, HttpContext httpContext)
    {
        var playerDtoList = playersDto.ToList();

        for (var index = 0; index < playerDtoList.Count(); index++)
        {
            var playerLinks = CreateLinksForPlayer(httpContext, teamId,
                playerDtoList[index].Id);
        }

        var playerCollection = new LinkCollectionWrapper<PlayerDto>(playerDtoList);
        var linkedPlayers = CreateLinksForPlayers(httpContext, playerCollection);

        return new LinkResponse { HasLinks = true, LinkedEntities = linkedPlayers };
    }

    private List<Link> CreateLinksForPlayer(HttpContext httpContext, Guid teamId, Guid id)
    {
        var links = new List<Link>
    {
        new Link(_linkGenerator.GetUriByAction(httpContext, "GetPlayerForTeam",
        values: new { teamId, id }),
        "self",
        "GET"),
        new Link(_linkGenerator.GetUriByAction(httpContext,
        "DeletePlayerForTeam", values: new { teamId, id }),
        "delete_player",
        "DELETE"),
        new Link(_linkGenerator.GetUriByAction(httpContext,
        "UpdatePlayerForTeam", values: new { teamId, id }),
        "update_player",
        "PUT"),
        new Link(_linkGenerator.GetUriByAction(httpContext,
        "PartiallyUpdatePlayerForTeam", values: new { teamId, id }),
        "partially_update_player",
        "PATCH")
    };

        return links;
    }

    private LinkCollectionWrapper<PlayerDto> CreateLinksForPlayers(HttpContext httpContext,
        LinkCollectionWrapper<PlayerDto> playersWrapper)
    {
        playersWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext,
        "GetPlayersForTeam", values: new { }),
        "self",
        "GET"));
        return playersWrapper;
    }
}
