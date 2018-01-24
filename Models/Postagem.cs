using System;
using System.ComponentModel.DataAnnotations;

namespace ForumWebServices.Models
{
    public class Postagem
    {
        [Key]
        public int idPostagem { get; set; }

        [Display(Name="Id do Tópico")]
        [Required(ErrorMessage="Este campo não pode ficar vazio")]
        [RegularExpression(@"^[a-zA-Z-'\s]{1,40}$",ErrorMessage="Você não pode adicionar um caracter especial")]
        public int idTopico { get; set; }

        [Display(Name="Id do Usuario")]
        [Required(ErrorMessage="Este campo não pode ficar vazio")]
        [RegularExpression(@"^[a-zA-Z-'\s]{1,40}$",ErrorMessage="Você não pode adicionar um caracter especial")]
        public int idUsuario { get; set; }

        public string mensagem { get; set; }

        public DateTime dataPublicacao { get; set; }


    }
}