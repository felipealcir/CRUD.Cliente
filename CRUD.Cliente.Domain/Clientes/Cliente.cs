using CRUD.Cliente.Domain.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Cliente.Domain.Clientes
{
    public class Cliente : Entity<Cliente>
    {
        private Cliente()
        { }

        public Cliente(
            string nome,
            DateTime dataNascimento,
            string documento,
            Endereco endereco
            )
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataNascimento = dataNascimento;
            Documento = documento;
            Endereco = endereco;
            DataCadastro = DateTime.Now;
            Ativo = true;
        }

        public string Nome { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public string Documento { get; private set; }

        public bool Ativo { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public Guid EnderecoId { get; private set; }

        public virtual Endereco Endereco { get; private set; }

        public override bool EstaValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }


        #region Validações

        private void Validar()
        {
            ValidarNome();
            ValidationResult = Validate(this);

            // Validacoes adicionais 
            ValidarEndereco();
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do cliente precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome do evento precisa ter entre 3 e 150 caracteres");
        }

        private void ValidarEndereco()
        {
            if (Endereco.EstaValido()) return;

            foreach (var error in Endereco.ValidationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }

        #endregion

    }
}

