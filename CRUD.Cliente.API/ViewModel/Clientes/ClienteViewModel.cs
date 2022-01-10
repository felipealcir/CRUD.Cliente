using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Cliente.API.ViewModel.Clientes
{
    public class ClienteViewModel
    {
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "O Nome é requerido")]
        [MinLength(3, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Documento é requerido")]
        [MinLength(9, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(11, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        public string Documento { get; set; }


        [Required(ErrorMessage = "A Data de Nascimento é requerida")]        
        public DateTime DataNascimento { get; set; }

        public EnderecoViewModel Endereco{ get; set; }      

    }
}
