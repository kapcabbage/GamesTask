using System;
using DataAccess.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Interfaces
{
    public interface IGamesContext : IDisposable
    {
        DbSet<Game> Games { get; set; }
        DbSet<Event> Events { get; set; }

        int SaveChanges();
        //DbContext methods
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry Entry(object entity);
    }
}
