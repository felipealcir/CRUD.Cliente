using CRUD.Cliente.Domain.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Cliente.Domain.Clientes.IRepository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Endereco ObterEnderecoPorId(Guid id);
        void AdicionarEndereco(Endereco endereco);
        void AtualizarEndereco(Endereco endereco);
    }
}
