using System;
using AutoMapper;
using CRUD.Cliente.API.ViewModel.Clientes;
using CRUD.Cliente.Domain.Clientes;

namespace CRUD.Cliente.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente.Domain.Clientes.Cliente>()
                .ConstructUsing(c => new Cliente.Domain.Clientes.Cliente(c.Nome, c.DataNascimento, c.Documento,
                    new Endereco(c.Endereco.Logradouro, c.Endereco.Numero, c.Endereco.Complemento, c.Endereco.Cep,
                    c.Endereco.Bairro, c.Endereco.Cidade, c.Endereco.Estado, c.Id)));
                
                CreateMap<EnderecoViewModel, Endereco>()
                .ConstructUsing(c => new Endereco(c.Logradouro, c.Numero, c.Complemento, c.Bairro,c.Cep, c.Cidade, c.Estado, c.ClienteID));

           

           
        }
    }
}