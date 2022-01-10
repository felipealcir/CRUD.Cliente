using CRUD.Cliente.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.Cliente.Application.Core.IService
{
    public interface IService<TEntity> where TEntity : Entity<TEntity>
    {
        IEnumerable<TEntity> ObterTodos();
    }
}
