using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace StartProject.App_Start.Identity
{
    public class SenhaValidador : IIdentityValidator<string>
    {
        public int TamanhoRequerido { get; set; }
        public bool ObrigatorioCaracteresEspeciais { get; set; }
        public bool ObrigatorioLowerCase { get; set; }
        public bool ObrigarorioUpperCase { get; set; }
        public bool ObrigatorioDigitos { get; set; }

        public async Task<IdentityResult> ValidateAsync(string item)
        {
            var erros = new List<string>();

            if (!TemTamanhoRequerido(item))
                erros.Add($"A senha deve conter no mínimo {TamanhoRequerido} caracteres.");

            if (ObrigatorioCaracteresEspeciais && !TemCaracteresEspeciais(item))
                erros.Add("A senha deve conter pelo menos um caractere especial.");

            if (ObrigarorioUpperCase && !VerificaUpperCase(item))
                erros.Add("A senha deve conter pelo menos uma letra maiúscula.");

            if (ObrigatorioLowerCase && !VerificaLowerCase(item))
                erros.Add("A senha deve conter pelo menos uma letra minúscula.");

            if (ObrigatorioDigitos && !VerificaDigito(item))
                erros.Add("A senha deve conter pelo menos um dígito.");

            if (erros.Any())
                return IdentityResult.Failed(erros.ToArray());
            else
                return IdentityResult.Success;
        }

        private bool TemTamanhoRequerido(string senha) =>
            senha?.Length >= TamanhoRequerido;

        private bool TemCaracteresEspeciais(string senha) =>
            Regex.IsMatch(senha, "/[^0-9A-Za-z]*/");

        private bool VerificaLowerCase(string senha) =>
            senha.Any(char.IsLower);

        private bool VerificaUpperCase(string senha) =>
            senha.Any(char.IsUpper);

        private bool VerificaDigito(string senha) =>
            senha.Any(char.IsDigit);
    }
}