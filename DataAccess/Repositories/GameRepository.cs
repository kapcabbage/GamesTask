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

        public IEnumerable<Game> GetAll(int? limit)
        {
            var query = _context.Games.AsQueryable();
            if(limit != null)
            {
                query.Take((int)limit);
            }
            return query.ToList();
        }

        public Game Get(int id)
        {
            return _context.Games.FirstOrDefault(x => x.GameId == id);
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
