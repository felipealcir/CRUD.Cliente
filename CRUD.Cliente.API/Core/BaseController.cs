using CRUD.Cliente.Domain.Core.Notifications;
using CRUD.Cliente.Domain.Core.Notifications.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUD.Cliente.API.Core
{
    public class BaseController : Controller
    {
        private readonly Notification _notifications;
        public BaseController(INotification<DomainNotification> notifications)
        {
            _notifications = (Notification)notifications;
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }

        protected void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _notifications.AddNotification(new DomainNotification(codigo, mensagem));
        }
    }
}
