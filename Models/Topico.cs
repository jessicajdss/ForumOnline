using System;
using System.ComponentModel.DataAnnotations;

namespace ForumWebServices.Models
{
    public class Topico
    {
        [Key]
        public int idTopico { get; set; }
        
        [Display(Name="Título do Tópico")]
        [Required(ErrorMessage="Este campo não pode ficar vazio")]
        [MinLength(3,ErrorMessage="Você deve inserir um titulo com três ou mais caracteres")]
        [MaxLength(10,ErrorMessage="Você não pode inserir um titulo com mais de 10 caracteres")]
        [RegularExpression(@"^[a-zA-Z-'\s]{1,40}$",ErrorMessage="Você não pode adicionar um caracter especial")]
        public string titulo { get; set; }

        [Required]
        [MinLength(3,ErrorMessage="Você deve inserir uma descrição com três ou mais caracteres")]
        [MaxLength(50,ErrorMessage="Você não pode inserir uma descrição com mais de 50 caracteres")]
        public string descricao { get; set; }

        public DateTime dataCadTopico { get; set; }
    }
}