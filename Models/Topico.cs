using System;

namespace ForumWebServices.Models
{
    public class Topico
    {
        public int idTopico { get; set; }

        public string titulo { get; set; }

        public string descricao { get; set; }

        public DateTime dataCadTopico { get; set; }
    }
}