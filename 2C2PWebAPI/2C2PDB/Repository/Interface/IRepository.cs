using _2C2PDB.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2C2PDB.Repository.Interface
{
    public interface IRepository<TEntity, in TKey> where TEntity : BaseModel
    {
        DbContext GetContext();


        TEntity Get(TKey id);

        TEntity Find(Expression<Func<TEntity, bool>> @exp);

        IQueryable<TEntity> FindByDescending<T>(Expression<Func<TEntity, bool>> @exp, Expression<Func<TEntity, T>> @order);

        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> @exp);

        IQueryable<TEntity> Table { get; }
        void Dispose();
    }
}
