using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
    }
}
