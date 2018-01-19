using System;

namespace ForumWebServices.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        public string nomeUsuario { get; set; }

        public string login { get; set; }

        public string senha { get; set; }

        public DateTime dataCadastro { get; set; }
    }
}