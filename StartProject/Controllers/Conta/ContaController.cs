using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StartProject.Models.Conta;
using StartProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartProject.Controllers.Conta
{
    public class ContaController : Controller
    {
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(ContaRegistrarViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var dbContext = new IdentityDbContext<UsuarioAplicacao>("DefaultConnection");
                var userStore = new UserStore<UsuarioAplicacao>(dbContext);
                var userManager = new UserManager<UsuarioAplicacao>(userStore);

                var novoUsuario = new UsuarioAplicacao();

                novoUsuario.Email = modelo.Email;
                novoUsuario.UserName = modelo.UserName;
                novoUsuario.NomeCompleto = modelo.NomeCompleto;

                userManager.Create(novoUsuario, modelo.Senha);

            }
            return View();
        }
    }
}