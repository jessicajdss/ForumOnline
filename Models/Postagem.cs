using System;

namespace ForumWebServices.Models
{
    public class Postagem
    {
        public int idPostagem { get; set; }

        public int idTopico { get; set; }

        public int idUsuario { get; set; }

        public string mensagem { get; set; }

        public DateTime dataPublicacao { get; set; }


    }
}