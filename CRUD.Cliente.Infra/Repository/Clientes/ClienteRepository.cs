using CRUD.Cliente.Domain.Clientes;
using CRUD.Cliente.Domain.Clientes.IRepository;
using CRUD.Cliente.Infra.Core.Repository;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.Cliente.Infra.Repository.Clientes
{
    public class ClienteRepository : Repository<Cliente.Domain.Clientes.Cliente>, IClienteRepository
    {
        public ClienteRepository(Context.Context context)
            : base(context)
        {

        }

        public void AdicionarEndereco(Endereco endereco)
        {
            Db.Enderecos.Add(endereco);
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            Db.Enderecos.Update(endereco);
        }

        public Endereco ObterEnderecoPorId(Guid id)
        {
            var sql = @"SELECT * FROM Enderecos E " +
                     "WHERE E.Id = @uid";

            var endereco = Db.Database.GetDbConnection().Query<Endereco>(sql, new { uid = id });

            return endereco.SingleOrDefault();
        }
    }
}
