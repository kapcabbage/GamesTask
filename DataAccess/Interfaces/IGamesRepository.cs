using DataAccess.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IGamesRepository : IRepository<Game>
    {
        IEnumerable<Game> GetAll();
        Game Get(int id);
        void Delete(Game entity);
    }
}
