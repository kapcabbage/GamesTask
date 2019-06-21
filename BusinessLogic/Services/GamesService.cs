using System;
using System.Collections.Generic;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using DataAccess.Common;
using DataAccess.Interfaces;
using DataAccess.POCO;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGamesContext _context;
        private readonly IGamesRepository _gameRepo;
        private readonly IEventsRepository _eventRepo;

        public GamesService(IGamesContext context)
        {
            _context = context;
            _gameRepo = new GameRepository(context);
            _eventRepo = new EventRepository(context);


        }

        public OperationResult<IEnumerable<Game>> GetAllGames()
        {
            var result = new OperationResult<IEnumerable<Game>>();
            result.Data = _gameRepo.GetAll();
            result.Status = eOperationStatus.Success;
            return result;
        }

        public OperationResult<int> AddGame(Game game)
        {
            var result = new OperationResult<int>();
            try
            {
                _gameRepo.Add(game);
                var saveResult = _context.SaveChanges();
                if(saveResult > 0)
                {
                    result.Data = game.GameId;
                    result.Status = eOperationStatus.Success;
                }
                else
                {
                    result.Data = 0;
                    result.Status = eOperationStatus.GeneralError;
                }
                
                
            }
            catch (Exception ex)
            {
                result.Status = eOperationStatus.GeneralError;
                result.ExceptionMessage = ex.Message;
                result.Data = 0;
            }

            return result;
        }

        public OperationResult<int> UpdateGame(Game Game)
        {
            var result = new OperationResult<int>();
            try
            {
              
 
                var toUpdate = _gameRepo.Get(Game.GameId);
                toUpdate.Name = Game.Name;
                toUpdate.MinPlayers = Game.MinPlayers;
                toUpdate.Description = Game.Description;
                toUpdate.MaxPlayers = Game.MaxPlayers;
                toUpdate.RecommendedAge = Game.RecommendedAge;
                var saveResult = _context.SaveChanges();
                if (saveResult > 0)
                {
                    result.Data = toUpdate.GameId;
                    result.Status = eOperationStatus.Success;
                }
                else
                {
                    result.Data = 0;
                    result.Status = eOperationStatus.GeneralError;
                    result.ExceptionMessage = "Could not update Game";
                }
                
               
            }
            catch (Exception ex)
            {
                result.Status = eOperationStatus.GeneralError;
                result.ExceptionMessage = ex.Message;
                result.Data = 0;
            }

            return result;
        }

        public OperationResult<Game> GetGame(int id)
        {
            var result = new OperationResult<Game>();
            var Game = _gameRepo.Get(id);
            if (Game != null)
            {
                _context.SaveChanges();
                result.Data = Game;
                result.Status = eOperationStatus.Success;

            }
            else
            {
                result.Data = null;
                result.Status = eOperationStatus.NotFound;
                
            }

            return result;
        }

        public OperationResult<bool> DeleteGame(int id)
        {
            var result = new OperationResult<bool>();
            try
            {
                var Game = _gameRepo.Get(id);
                if (Game != null)
                {
                    _gameRepo.Delete(Game);
                    var saveResult = _context.SaveChanges();
                    if (saveResult > 0)
                    {
                        result.Data = true;
                        result.Status = eOperationStatus.Success;
                    }
                    else
                    {
                        result.Data = false;
                        result.Status = eOperationStatus.GeneralError;
                    }
                }
                else
                {
                    result.Data = false;
                    result.Status = eOperationStatus.NotFound;

                }

            }
            catch (Exception ex)
            {
                result.Data = false;
                result.Status = eOperationStatus.GeneralError;
                result.ExceptionMessage = ex.Message;
            }
           
            return result;
        }

        public OperationResult<IEnumerable<Event>> GetEvents(int gameId)
        {
            var result = new OperationResult<IEnumerable<Event>>();
            result.Data = _eventRepo.GetTop(gameId);
            result.Status = eOperationStatus.Success;
            return result;
        }

        public OperationResult<int> AddEvent(Event eventEntity)
        {
            var result = new OperationResult<int>();
            try
            {
                _eventRepo.Add(eventEntity);
                var saveResult = _context.SaveChanges();
                if (saveResult > 0)
                {
                    result.Data = eventEntity.EventId;
                    result.Status = eOperationStatus.Success;
                }
                else
                {
                    result.Data = 0;
                    result.Status = eOperationStatus.GeneralError;
                }


            }
            catch (Exception ex)
            {
                result.Status = eOperationStatus.GeneralError;
                result.ExceptionMessage = ex.Message;
                result.Data = 0;
            }

            return result;
        }
    }
}
