using AutoMapper;
using CRUD.Cliente.API.ViewModel.Clientes;
using CRUD.Cliente.Domain.Clientes;

namespace CRUD.Cliente.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Clientes.Cliente, ClienteViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();           
        }
    }
}