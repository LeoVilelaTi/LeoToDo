using System;
using System.Security.Cryptography;
using System.Text;

namespace LeoTodo.Dominio.InfraEstrutura
{
    public static class Criptografia
    {
        private static readonly string SaltText = @"984(743HFjyt25OtrDH5A32HdsNBA~_FFXDF=+0425/-*'";

        public static string CriptografaSenha(string senha)
        {
            return GerarHashSha1ComSalt(senha);
        }

        public static string GerarHashSha1ComSalt(string senha)
        {
            senha = senha.Trim();

            var HashTool = new SHA512Managed();
            var PhraseAsByte = Encoding.UTF8.GetBytes(string.Concat(senha + SaltText));
            var EncryptedBytes = HashTool.ComputeHash(PhraseAsByte);

            HashTool.Clear();

            return Convert.ToBase64String(EncryptedBytes);
        }
    }
}