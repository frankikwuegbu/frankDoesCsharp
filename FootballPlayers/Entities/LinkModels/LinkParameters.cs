using Microsoft.AspNetCore.Http;
using Shared.RequestFeatures;
using System.Net.Http;

namespace Entities.LinkModels;

public record LinkParameters(PlayerParameters PlayerParameters, HttpContext Context);

