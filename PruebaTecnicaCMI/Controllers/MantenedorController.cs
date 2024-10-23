using Microsoft.AspNetCore.Mvc;


using PruebaTecnicaCMI.Datos;
using PruebaTecnicaCMI.Models;

namespace PruebaTecnicaCMI.Controllers
{
    public class MantenedorController : Controller
    {
      
        UsuarioDatos _UsuarioDatos = new UsuarioDatos();

        public IActionResult AutenticarFrm()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult AutenticarFrm(UsuarioModel oUsuario)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = _UsuarioDatos.Autenticar(oUsuario);
            
            if (respuesta)
            {
                //HttpContext.Session.SetString("Usuario", oUsuario.Usuario);
                return RedirectToAction("Programa");
            }
            else { 
                return View(); 
            }
                
        }


        // ------------------------------------------------------------------------
        IngresoDatos _IngresoDatos = new IngresoDatos();
        public IActionResult Programa()
        {
            var oLista = _IngresoDatos.Listar();

            return View(oLista);
        }
        // ------------------------------------------------------------------------

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(IngresoModel oIngreso)
        {
           
            if (!ModelState.IsValid)
                return View();


            var respuesta = _IngresoDatos.Guardar(oIngreso);

            if (respuesta)
                return RedirectToAction("Programa");
            else
                return View();
        }

        // ------------------------------------------------------------------------
    }
}
