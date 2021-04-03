using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Project.COMMON.Tools
{
    public static class MailSender
    {

        public static void Send(string receiver, string password = "Ak17041971 ", string body = "Müşteri Hizmetleri", string subject = "Hesap Aktivasyon", string sender = "ercankarahan@hotmail.de")
        {

            MailAddress senderEmail = new MailAddress(sender);

            MailAddress receiverEmail = new MailAddress(receiver);


            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };




            using (var mesaj = new MailMessage(senderEmail, receiverEmail)
            {
                //Object initializer
                Subject = subject,
                Body = body
            })
            {
                //using scope'u
                smtp.Send(mesaj); 
            }




        }



    }
}