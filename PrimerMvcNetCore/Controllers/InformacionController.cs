using Microsoft.AspNetCore.Mvc;
using PrimerMvcNetCore.Models;

namespace PrimerMvcNetCore.Controllers
{
    public class InformacionController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }

       //Siempre tiene que haber un get

        public IActionResult VistaControladorPost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult VistaControladorPost(Persona persona, string aficiones)
        {
            //Algunos vienen de un modle y otro ahi creado no hace falta que sean todos iguales
            ViewData["DATOS"] = "Nombre: " + persona.Nombre + " Correo: " + persona.Email + " Edad: " + persona.Edad + ", Aficiones: " + aficiones;
            return View();
        }

        public IActionResult ControladorVista()
        {
            //Vamos a enviar informacion simple a nuestra vista
            ViewData["NOMBRE"] = "Alumno";
            ViewData["EDAD"] = 25;
            ViewBag.DiaSemana = "Lunes";
            ViewData["DIASEMANA"] = "Mañana martes!!"; //Se comen con el ultimo y hacen lo mismo en el controlador da igual cual pongas

            //Con Model
            Persona persona = new Persona();
            persona.Nombre = "Persona Model";
            persona.Email = "laktcuento@gmail.com";
            persona.Edad = 777;
            return View(persona); //IMPORTANTE CON MODEL AÑADIR AL RETURN EL PROPIO MDEL
        }

        //VAMOS A RECIBIR DOS PARAMETROS
        public IActionResult VistaControladorGet(string app, System.Nullable<int> version)          
        {   
            //Ahora la version es opcional gracias al system nullable de la declaraicon de arriba
            if (version is null)
            {

            }
            //Dibujamos en la vista los parametros recibidos
            ViewData["DATOS"] = "Aplicacion " + app + " , Version: " + version.GetValueOrDefault();
         
            return View();
        }
    }
}
