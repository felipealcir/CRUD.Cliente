using CRUD.Cliente.Application.Core.IService;
using CRUD.Cliente.Domain.Core;
using CRUD.Cliente.Domain.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Cliente.Application.Core.Service
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : Entity<TEntity>
    {
        protected IRepository<TEntity> _repository;
        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }
    }
}


 