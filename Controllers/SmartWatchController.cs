using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    public class SmartWatchController : Controller
    {
        /*Obtiene el listado de datos de SmartWatch */
        [HttpGet]
        public ActionResult Get(){
            return Ok(Datos.DatosSmartWatch);
        }

        /*Inserta un smartwatch*/
        [HttpPost]
        public ActionResult Post([FromBody]SmartWatch sm){
            if(!this.ModelState.IsValid || sm==null){
                return BadRequest();
            } else{
                 
                Datos.DatosSmartWatch.Add(Datos.DatosSmartWatch.Count, sm);

                //TODO validar aquí
                return Ok(sm);
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