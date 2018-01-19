using System.Collections.Generic;
using System.Linq;
using ForumWebServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebServices.Controllers
{
    [Route("api/[controller]")]    
    public class PrimeiraController : Controller
    {
        DAOUsuarios daoUsuarios = new DAOUsuarios();

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return daoUsuarios.ListarUsuarios();
        }

        [HttpGet("{id}",Name="UsuarioAtual")]
        public Usuario Get(int id)
        {
            return daoUsuarios.ListarUsuarios().Where(x => x.idUsuario == id).FirstOrDefault();
        }

        [HttpPost]
        public void Adicionar([FromBody]Usuario us)
        {
            daoUsuarios.Cadastro(us);
            //return CreatedAtRoute("UsuarioAtual", new { id = usuarios.idUsuario }, usuarios);
        }

    }
}