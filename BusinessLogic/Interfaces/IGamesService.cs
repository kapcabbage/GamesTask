using System.Collections.Generic;
using DataAccess.Common;
using DataAccess.POCO;

namespace BusinessLogic.Interfaces
{
    public interface IGamesService
    {
        OperationResult<IEnumerable<Game>> GetAllGames();
        OperationResult<Game> GetGame(int id);
        OperationResult<int> AddGame(Game customer);
        OperationResult<int> UpdateGame(Game customer);
        OperationResult<bool> DeleteGame(int id);
        OperationResult<IEnumerable<Event>> GetEvents(int gameId);
        OperationResult<int> AddEvent(Event eventEntity);
    }
}
