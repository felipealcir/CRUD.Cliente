using CRUD.Cliente.Domain.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Cliente.Domain.Clientes
{
    public class Endereco : Entity<Endereco>
    {
        public Endereco(
            string logradouro,
            string numero, 
            string complemento, 
            string cep, 
            string bairro,
            string cidade,
            string estado, 
            Guid clienteID
            )
        {
            Id = Guid.NewGuid();
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;  
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            ClienteID = clienteID;
        }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public Guid ClienteID { get; private set; }

        public virtual Cliente Cliente { get; private set; }

        public override bool EstaValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            RuleFor(c => c.Logradouro)
               .NotEmpty().WithMessage("O Logradouro precisa ser fornecido")
               .Length(2, 150).WithMessage("O Logradouro precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.Numero)
              .NotEmpty().WithMessage("O Numero precisa ser fornecido")
              .Length(1, 150).WithMessage("O Numero precisa ter entre 1 e 150 caracteres");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("O Bairro precisa ser fornecido")
                .Length(2, 150).WithMessage("O Bairro precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("O CEP precisa ser fornecido")
                .Length(8).WithMessage("O CEP precisa ter 8 caracteres");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("A Cidade precisa ser fornecida")
                .Length(2, 150).WithMessage("A Cidade precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("O Estado precisa ser fornecido")
                .Length(2, 150).WithMessage("O Estado precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("O Numero precisa ser fornecido")
                .Length(1, 10).WithMessage("O Numero precisa ter entre 1 e 10 caracteres");
        }
    }
}
