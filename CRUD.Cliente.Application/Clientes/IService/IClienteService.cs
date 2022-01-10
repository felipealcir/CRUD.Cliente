using CRUD.Cliente.Application.Core.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Cliente.Application.Clientes.IService
{
    public interface IClienteService : IService<Cliente.Domain.Clientes.Cliente>
    {
    }
}
