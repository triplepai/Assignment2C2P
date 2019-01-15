using _2C2PDB.Model;
using _2C2PDB.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2C2PDB.Repository
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseModel
    {
        private readonly DBContext dbCtx;
        private readonly IDbSet<TEntity> dbSet;



        public Repository(DBContext context)
        {
            dbCtx = context;
            dbSet = dbCtx.Set<TEntity>();

        }

        public DbContext GetContext()
        {
            return this.dbCtx;
        }



        public TEntity Get(TKey id)
        {
            return dbSet.Find(id);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> @exp)
        {
            return dbSet.FirstOrDefault(@exp);
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> @exp)
        {
            return dbSet.Where(@exp);
        }

        public IQueryable<TEntity> Table { get => dbSet; }


        public void Dispose()
        {
            dbCtx?.Dispose();
        }



        public IQueryable<TEntity> FindByDescending<T>(Expression<Func<TEntity, bool>> @exp, Expression<Func<TEntity, T>> @order)
        {
            return dbSet.Where(@exp).OrderByDescending(@order);
        }

    }
}