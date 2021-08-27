using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;

namespace ControleServices.Utils
{
    public static class UtilsBusiness
    {
        // Envia o emil com a Senha 
        public static void SendEmail(string senha, string email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("controlesuporteteste@gmail.com");
            mail.To.Add(new MailAddress(email));
            mail.Subject = "Controle Suporte";
            mail.Body = "Sua senha é :" + senha;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("controlesuporteteste@gmail.com", "dontus01");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

        //Gera um senha randomica 
        public static string GeraSenhas(string senha, string email)
        {
            int Tamanho = 6; // Numero de digitos da senha
            senha = string.Empty;
            for (int i = 0; i < Tamanho; i++)
            {
                Random random = new Random();
                int codigo = Convert.ToInt32(random.Next(1,9).ToString());

                senha += codigo.ToString();
            }
            SendEmail(senha, email);
            return senha;
        }

        //Codifca em MD5
        public static string MD5Hash(string text, string email)
        {
            string text2;
            if (text == "")
            {
                text2 = GeraSenhas("", email);
            }
            else
            {  
                text2 = text;
            }
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(text2);

            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();

        }

        public static DateTime GetData()
        {
            DateTime Data = DateTime.Now;

            return Data;
        }
    }
}
