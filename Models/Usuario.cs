using System;

using System.ComponentModel.DataAnnotations;

namespace ForumWebServices.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        [Display(Name="Nome do Usuário")]
        [Required(ErrorMessage="Este campo não pode ficar vazio")]
        [MinLength(2,ErrorMessage="Você deve inserir um nome com dois ou mais caracteres")]
        [MaxLength(30,ErrorMessage="Você não pode inserir um nome com mais de 30 caracteres")]
        [RegularExpression(@"^[a-zA-Z-'\s]{1,40}$",ErrorMessage="Você não pode adicionar um caracter especial")]
        public string nomeUsuario { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string login { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(6)]
        public string senha { get; set; }

        public DateTime dataCadastro { get; set; }
    }
}