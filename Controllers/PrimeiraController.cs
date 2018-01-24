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
            if (rs.Value == null)
            {
                rs.StatusCode = 204;
                rs.Value = $"Não existe resultado para o id {id}";
            }
            else
            {
                rs.StatusCode = 200;
            }

            return Json(rs);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody]Usuario usuario)
        {
            JsonResult rs = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                rs = new JsonResult(daoUsuarios.Cadastro(usuario));
                rs.ContentType = "application/json";
                if (rs.Value == null)
                {
                    rs.StatusCode = 404;
                    rs.Value = "Ocorreu um erro ";
                }
                else
                {
                    rs.StatusCode = 200;
                }
            }
            catch (System.Exception ex)
            {
                rs = new JsonResult("");
                rs.StatusCode = 204;
                rs.ContentType = "application/json";
                rs.Value = ex.Message;
            }
            return Json(rs);
        }
        // [HttpPost]
        // public void Adicionar([FromBody]Usuario usuario)
        // {
        //     daoUsuarios.Cadastro(usuario);
        // }

        [HttpPut]
        public void Editar([FromBody]Usuario usuario)
        {
            daoUsuarios.Editar(usuario);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            daoUsuarios.Apagar(id);
        }


    }
}