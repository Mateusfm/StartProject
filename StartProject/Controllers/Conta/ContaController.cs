using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using StartProject.Models.Conta;
using StartProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace StartProject.Controllers.Conta
{
    public class ContaController : Controller
    {
        private UserManager<UsuarioAplicacao> _userManager;

        public UserManager<UsuarioAplicacao> UserManager
        {
            get
            {
                if (_userManager == null)
                {
                    var contextOwin = HttpContext.GetOwinContext();
                    _userManager = contextOwin.GetUserManager<UserManager<UsuarioAplicacao>>();
                }

                return _userManager;
            }
            set
            {
                _userManager = value;
            }
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registrar(ContaRegistrarViewModel modelo)
        {
            if (ModelState.IsValid)
            {                
                var novoUsuario = new UsuarioAplicacao();

                novoUsuario.Email = modelo.Email;
                novoUsuario.UserName = modelo.UserName;
                novoUsuario.NomeCompleto = modelo.NomeCompleto;

                var usuarioDoBanco = await UserManager.FindByEmailAsync(modelo.Email);
                var usuarioJaExiste = usuarioDoBanco != null;

                if (usuarioJaExiste)
                    return View("AguardandoConfirmacao");



                var resultado = await UserManager.CreateAsync(novoUsuario, modelo.Senha);

                if (resultado.Succeeded)
                {
                    await EnviarEmailDeconfirmacaoAsync(novoUsuario);
                    return View("AguardandoConfirmacao");
                }                    
                else
                    AdicionaErros(resultado);

            }
            return View();
        }

        private async Task EnviarEmailDeconfirmacaoAsync(UsuarioAplicacao usuario)
        {
            var token = await UserManager.GenerateEmailConfirmationTokenAsync(usuario.Id);

            var linkCallBack = Url.Action(
                "ConfirmacaoEmail"
                , "Conta"
                , new {usuarioId = usuario.Id, token = token }
                , Request.Url.Scheme
                );

            await UserManager.SendEmailAsync(
                usuario.Id
                , "Email de confirmação para novo cadastro"
                , $"Clique aqui {linkCallBack} para confirmar seu e-mail!");
        }

        public ActionResult ConfirmacaoEmail(string usuarioId, string token)
        {
            return View("AguardandoConfirmacao");
        }

        private void AdicionaErros(IdentityResult resultado)
        {
            foreach (var erro in resultado.Errors)
            {
                ModelState.AddModelError("", erro);
            }
        }
    }
}