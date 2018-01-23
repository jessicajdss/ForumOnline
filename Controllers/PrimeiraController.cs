using System.Collections.Generic;
using System.Linq;
using ForumWebServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebServices.Controllers
{
    [Route("api/[controller]")]   
   // [Route("Usuario")]   
    public class PrimeiraController : Controller
    {
        DAOUsuarios daoUsuarios = new DAOUsuarios();

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return daoUsuarios.ListarUsuarios();
        }

        // [HttpGet("{id}")]
        // public Usuario Get(int id)
        // {
        //     return daoUsuarios.ListarUsuarios().Where(x => x.idUsuario == id).FirstOrDefault();
        // }

        [HttpGet("{id}")]
        public IActionResult Listar(int id)
        {
            var rs = new JsonResult(daoUsuarios.ListarUsuarios().Where(x => x.idUsuario == id).FirstOrDefault());
            rs.ContentType = "application/json";
            if(rs.Value==null){
                rs.StatusCode =204;
                rs.Value= $"Não existe resultado para o id {id}";
            }
            else{
                rs.StatusCode = 200;
            }

            return Json(rs);
        }

        [HttpPost]
        public void Adicionar([FromBody]Usuario usuario)
        {
            daoUsuarios.Cadastro(usuario);
        }

        [HttpPut]
        public void Editar([FromBody]Usuario usuario)
        {
            daoUsuarios.Editar(usuario);    
        }


        [HttpDelete("{id}")]
        public void Delete(int id){
            daoUsuarios.Apagar(id);            
        }

 
    }
}