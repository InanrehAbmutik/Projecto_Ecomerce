using EntidadeDao;
using ProyectoTest.Logica;
using ProyectoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoTest.Controllers
{
    public class LoginController : Controller
    {
        void Dados()
        {
            Contexto db = new Contexto();
            db.Database.CreateIfNotExists();
            if (db.USUARIOs.ToList().Count == 0)
            {
                db.USUARIOs.Add(new USUARIO
                {
                    Nomes = "Admin",
                    Apelido = "Administrador",
                    Email = "admin@admin.com",
                    Senha = "admin123",
                    Activo = true,
                    EsAdministrador = true,
                    DataRegisto = DateTime.Now
                });

                db.SaveChanges();
            }
        }
        // GET: Login
        public ActionResult Index()
        {
            Dados();
            return View();
            
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string NCorreo, string NContrasena)
        {
            
            Usuario oUsuario = new Usuario();

            oUsuario = UsuarioLogica.Instancia.Obtener(NCorreo, NContrasena);

            if (oUsuario == null)
            {
                ViewBag.Error = "E-mail ou senha incorretos";
                return View();
            }

            FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);
            Session["Usuario"] = oUsuario;

            if (oUsuario.EsAdministrador == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else {
                return RedirectToAction("Index", "Tienda");
            }

            
        }

        // GET: Login
        public ActionResult Registrarse()
        {
            return View(new Usuario() { Nombres= "",Apellidos= "",Correo="",Contrasena="",ConfirmarContrasena="" });
        }

        [HttpPost]
        public ActionResult Registrarse(string NNombres, string NApellidos, string NCorreo, string NContrasena, string NConfirmarContrasena)
        {
            Usuario oUsuario = new Usuario()
            {
                Nombres = NNombres,
                Apellidos = NApellidos,
                Correo = NCorreo,
                Contrasena = NContrasena,
                ConfirmarContrasena = NConfirmarContrasena,
                EsAdministrador = false
            };

            if (NContrasena != NConfirmarContrasena)
            {
                ViewBag.Error = "As senhas não coincidem";
                return View(oUsuario);
            }
            else {
                

                int idusuario_respuesta = UsuarioLogica.Instancia.Registrar(oUsuario);

                if (idusuario_respuesta == 0)
                {
                    ViewBag.Error = "Erro de registro";
                    return View();

                }
                else {
                    return RedirectToAction("Index", "Login");
                }
            }
        }

    }

}