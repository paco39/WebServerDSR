using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        /*Obtiene el listado de usuarios */
        [HttpGet]
        public ActionResult Get(){
            return Ok(Datos.Usuarios);
        }

        /*Inserta un usuario*/
        [HttpPost]
        public ActionResult Post([FromBody]Usuario usuario){
            if(!this.ModelState.IsValid || usuario==null){
                return BadRequest();
            } else{
                 
                Datos.Usuarios.Add(Datos.Usuarios.Count, usuario);

                //TODO validar aquí
                return Ok(usuario);
            }
        }

        /*
        http://localhost:5000/api/usuarios/:id
        Obtiene la información del Usuario dado a un Id especificado 
         */
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            // Verifica si existe el id especificado
            if (Datos.Usuarios.ContainsKey(id))
            {
                // Si el id es encontrado regresa el elemento de nuestro IDictionary en la posición especificada
                return Ok(Datos.Usuarios[id]);
            }
            else
            {
                // Si el id no es encontrado, regresa un 404
                return NotFound();
            }
        }
    }
}