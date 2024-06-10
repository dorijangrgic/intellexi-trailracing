using Intellexi.TrailRacing.Domain;
using MediatR;

namespace Intellexi.TrailRacing.Application.RaceManagement.Requests;

public class RaceCreateRequest : IRequest
{
    public string Name { get; set; }
    public RaceDistance Distance { get; set; }
}