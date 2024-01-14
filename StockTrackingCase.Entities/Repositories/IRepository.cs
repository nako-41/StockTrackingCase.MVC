using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingCase.Entities.Repositories;
public interface IRepository<TEntity>
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    TEntity? GetByExpession(Expression<Func<TEntity, bool>> expression);
    IQueryable<TEntity> GetAll();
}
