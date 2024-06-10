using Intellexi.TrailRacing.Domain;
using MediatR;

namespace Intellexi.TrailRacing.Application.RaceManagement.Requests;

public class RaceUpdateRequest : IRequest
{
    public Guid RaceId { get; set; }
    public string Name { get; set; }
    public RaceDistance Distance { get; set; }
}