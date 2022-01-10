using CRUD.Cliente.Domain.Core;
using CRUD.Cliente.Domain.Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CRUD.Cliente.Infra.Core.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected Context.Context Db;
        protected DbSet<TEntity> DbSet;       

        protected Repository(Context.Context context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();           
        }

        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
            SaveChanges();

        }

        public virtual void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
            SaveChanges();
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
