using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace GestorRRHH_BackEnd_Api.Utils
{
    public static class Utils
    {
        public static async Task<string> Send_Email(string to,string subject, string body)
        {
            String Result = "";
            try
            {
                MailMessage oMail = new MailMessage();
                SmtpClient oSmtp = new SmtpClient("smtp.office365.com");

                // Set your hotmail/live/outlook.com email address
                oMail.From = new MailAddress("teNotificaciones@outlook.com", "Notificaciones Capturador RRHH");

                // Add recipient email address, please change it to yours
                oMail.To.Add(new MailAddress(to));

                // Set email subject and email body text
                oMail.Subject = subject;
                oMail.Body = body;
                oMail.IsBodyHtml = true;

                oSmtp.Credentials = new System.Net.NetworkCredential("teNotificaciones@outlook.com", "D3s4rr0ll0*2022");
                // Set 587 port, if you want to use 25 port, please change 587 to 25
                oSmtp.Port = 587;

                // detect SSL/TLS type automatically
                oSmtp.EnableSsl = true;

                await oSmtp.SendMailAsync(oMail);
                Result = "OK";
            }
            catch (Exception ep)
            {
                Result = String.Format("Failed to send email with the following error: {0}", ep.Message);
            }
            return Result;
        }

        /// <summary>
        /// Random string
        /// </summary>
        /// <param name="size">Length</param>
        /// <param name="lowerCase">If has lower case</param>
        /// <returns></returns>
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        /// <summary>
        /// Random numbr
        /// </summary>
        /// <param name="min">Min value</param>
        /// <param name="max">Max value</param>
        /// <returns></returns>
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        /// <summary>
        /// Generate random password
        /// </summary>
        /// <returns></returns>
        public static string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
    }
}
