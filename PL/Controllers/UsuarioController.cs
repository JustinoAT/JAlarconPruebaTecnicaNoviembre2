using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Objetos = new List<object>();
            usuario.Objetos = BL.Usuario.GetAll();
            if (usuario.Objetos != null)
            {


                return View(usuario);
            }
            else
            {
                return View();
            }

        }
        public ActionResult Form(int? IdUsuario)
        {
          
            if (IdUsuario != null)
            {
                ML.Usuario usuario = new ML.Usuario();
                usuario.Objeto = BL.Usuario.GetById(IdUsuario.Value);
                return View(usuario.Objeto);
            }
            else {
                return View();
            }

        }
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {

            if (usuario.IdUsuario != 0)
            {
                bool result;
                result = BL.Usuario.Update(usuario);
                if (result)
                {
                    ViewBag.Mensaje = "Usuario actalizado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo actualizar el usuario";
                }

            }
            else
            {
                bool result;
                result = BL.Usuario.Add(usuario);
                if (result)
                {
                    ViewBag.Mensaje = "Usuario agregado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo agregar el usuario";
                }

            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int IdUsuario)
        {
            bool result;
            result = BL.Usuario.Delete(IdUsuario);
            if (result)
            {
                ViewBag.Mensaje = "Usuario eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "No se pudo eliminar el usuario";
            }
            return PartialView("Modal");
        }
    }
}