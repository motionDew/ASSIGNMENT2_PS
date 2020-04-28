using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace assignment2.Data
{
    interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        void Create(TEntity entity);
        TEntity Retrieve(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Retrieve(int id);
        void Delete(int id);

    }
}
