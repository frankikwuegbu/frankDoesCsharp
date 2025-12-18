using Entities.LinkModels;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects;
using System.Net.Http;

namespace Contracts;

public interface IPlayerLinks
{
    LinkResponse TryGenerateLinks(IEnumerable<PlayerDto> playersDto,
        Guid teamId, HttpContext httpContext);
}