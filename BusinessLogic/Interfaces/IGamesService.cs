using System.Collections.Generic;
using BusinessLogic.Dtos;
using DataAccess.Common;
using DataAccess.POCO;

namespace BusinessLogic.Interfaces
{
    public interface IGamesService
    {
        OperationResult<IEnumerable<GameDto>> GetAllGames(int? limit);
        OperationResult<Game> GetGame(int id);
        OperationResult<int> AddGame(Game customer);
        OperationResult<int> UpdateGame(Game customer);
        OperationResult<bool> DeleteGame(int id);
        OperationResult<IEnumerable<EventDto>> GetEvents(int gameId);
        OperationResult<int> AddEvent(Event eventEntity);
    }
}
