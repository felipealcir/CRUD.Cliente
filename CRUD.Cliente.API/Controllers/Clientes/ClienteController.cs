using AutoMapper;
using CRUD.Cliente.API.Core;
using CRUD.Cliente.API.ViewModel.Clientes;
using CRUD.Cliente.Domain.Clientes.IRepository;
using CRUD.Cliente.Domain.Core.Notifications;
using CRUD.Cliente.Domain.Core.Notifications.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CRUD.Cliente.API.Controllers.Clientes
{
    public class ClienteController : BaseController
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;


        public ClienteController(INotification<DomainNotification> notifications,
                                 IClienteRepository clienteService,
                                 IMapper mapper)
            : base(notifications)
        {
            _clienteRepository = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("clientes")]
        [AllowAnonymous]
        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        [HttpPost]
        [Route("adicionar")]
        [AllowAnonymous]
        public IActionResult Adicionar([FromBody] ClienteViewModel clienteViewModel)
        {
            if (!ModelStateValida())
            {
                Response();
            }

            var entity = _mapper.Map<Cliente.Domain.Clientes.Cliente>(clienteViewModel);
            _clienteRepository.Adicionar(entity);

            return Response(entity);

        }

        [HttpPut]
        [Route("atualizar")]
        [AllowAnonymous]
        public IActionResult Atualizar([FromBody] ClienteViewModel clienteViewModel)
        {
            if (!ModelStateValida())
            {
                Response();
            }

            var entity = _mapper.Map<Cliente.Domain.Clientes.Cliente>(clienteViewModel);
            _clienteRepository.Atualizar(entity);

            return Response(entity);

        }

        [HttpDelete]
        [Route("remover/{id:guid}")]
        [AllowAnonymous]
        public IActionResult Remover(Guid id)
        {
            if (!ModelStateValida())
            {
                Response();
            }

            _clienteRepository.Remover(id);

            return Response(id);
        }

        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;

            NotificarErroModelInvalida();
            return false;
        }
    }
}
