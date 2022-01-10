using CRUD.Cliente.Application.Clientes.IService;
using CRUD.Cliente.Application.Core.Service;
using CRUD.Cliente.Domain.Clientes.IRepository;
using CRUD.Cliente.Domain.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Cliente.Application.Clientes.Service
{
    public class ClienteService : Service<Cliente.Domain.Clientes.Cliente>, IClienteService
    {        
        public ClienteService(IRepository<Domain.Clientes.Cliente> repository) : base(repository)
        {
        }
    }
}
