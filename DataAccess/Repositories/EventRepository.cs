using DataAccess.Interfaces;
using DataAccess.POCO;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class EventRepository : IEventsRepository
    {
        protected readonly IGamesContext _context;
        public EventRepository(IGamesContext context)
        {
            _context = context;
        }


        public void Add(Event entity)
        {
            _context.Events.Add(entity);
        }

        public IEnumerable<Event> GetTop(int gameId)
        {
            return _context.Events
                .Where(x=>x.GameId == gameId)
                .Select(x=> new Event {
                    EventId = x.EventId,
                    GameId = x.GameId,
                    TimeStamp = x.TimeStamp,
                    Source = x.Source,
                    EventType = x.EventType
            })
                .OrderBy(x=>x.TimeStamp).Take(10).ToList();
        }
    }
}
