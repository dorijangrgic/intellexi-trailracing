// using Intellexi.TrailRacing.Application.RaceManagement.Requests;
// using Intellexi.TrailRacing.Application.Services;
// using Intellexi.TrailRacing.Domain.Entities;
//
// namespace Intellexi.TrailRacing.QueryService.MessageHandlers;
//
// public class RaceCreatedMessageHandler : IMessageHandler<RaceCreateRequest>
// {
//     private readonly IGenericRepository<Race> _raceRepository;
//
//     public RaceCreatedMessageHandler(IGenericRepository<Race> raceRepository)
//     {
//         _raceRepository = raceRepository;
//     }
//
//     public async Task HandleMessage(RaceCreateRequest message)
//     {
//         var race = Race.Create(message.Name, message.Distance);
//         await _raceRepository.AddAsync(race);
//     }
// }