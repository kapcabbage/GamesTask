using DataAccess.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IGamesRepository : IRepository<Game>
    {
        IEnumerable<Game> GetAll(int? limit);
        Game Get(int id);
    }
}
