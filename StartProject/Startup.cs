using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
using StartProject.App_Start.Identity;
using StartProject.Models.Conta;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(StartProject.Startup))]

namespace StartProject
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            ConfiguracaoUsuario(builder);
        }

        private static void ConfiguracaoUsuario(IAppBuilder builder)
        {
            builder.CreatePerOwinContext<DbContext>(() =>
                            new IdentityDbContext<UsuarioAplicacao>("DefaultConnection"));

            builder.CreatePerOwinContext<IUserStore<UsuarioAplicacao>>(
                (opcoes, contextoOwin) =>
                {
                    var dbContext = contextoOwin.Get<DbContext>();
                    return new UserStore<UsuarioAplicacao>(dbContext);
                });

            builder.CreatePerOwinContext<UserManager<UsuarioAplicacao>>(
                (opcoes, contextoOwin) =>
                {
                    var userStore = contextoOwin.Get<IUserStore<UsuarioAplicacao>>();
                    var userManager = new UserManager<UsuarioAplicacao>(userStore);

                    var userValidator = new UserValidator<UsuarioAplicacao>(userManager);
                    userValidator.RequireUniqueEmail = true;

                    userManager.UserValidator = userValidator;
                    userManager.PasswordValidator = new SenhaValidador()
                    {
                        TamanhoRequerido = 6,
                        ObrigarorioUpperCase = true,
                        ObrigatorioCaracteresEspeciais = true,
                        ObrigatorioDigitos = true,
                        ObrigatorioLowerCase = true
                    };

                    userManager.EmailService = new EmailServico();

                    var dataProtectionProvider = opcoes.DataProtectionProvider;
                    var dataProtectionProviderCreated = dataProtectionProvider.Create("AppStart");

                    userManager.UserTokenProvider = new DataProtectorTokenProvider<UsuarioAplicacao>(dataProtectionProviderCreated);

                    return userManager;
                });
        }
    }
}