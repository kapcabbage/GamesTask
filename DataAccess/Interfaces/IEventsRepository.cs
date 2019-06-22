using DataAccess.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IEventsRepository : IRepository<Event>
    {
        IEnumerable<Event> GetTop(int gameId);
        IEnumerable<Event> GetAll(int gameId);
    }
}
