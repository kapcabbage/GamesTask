using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Interfaces;
using DataAccess.POCO;

namespace DataAccess.Repositories
{
    public class GameRepository : IGamesRepository
    {
        protected readonly IGamesContext _context;
        public GameRepository(IGamesContext context)
        {
            _context = context;
        }

        #region Implementation of ICustomerRepository

        public IEnumerable<Game> GetAll()
        {
            return _context.Games.ToList();
        }

        public Game Get(int id)
        {
            return _context.Games.Where(x=>x.GameId == id).Select(x=>new Game {
                GameId = x.GameId,
                Name = x.Name,
                Description = x.Description,
                MaxPlayers = x.MaxPlayers,
                MinPlayers = x.MinPlayers,
                RecommendedAge = x.RecommendedAge
            }).FirstOrDefault();
        }

        public void Add(Game entity)
        {
            _context.Games.Add(entity);
        }

        public void Delete(Game entity)
        {
            _context.Games.Remove(entity);
        }

        #endregion
    }
}
