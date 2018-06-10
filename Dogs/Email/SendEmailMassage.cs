using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Dogs.Email
{
    public class SendEmailMassage
    {
        public void sendEmail(string sendToEmail, string attachmentLocation,string Text,string SubJ,string Phone)
        {
            try
            {
                string smtpSvr = "smtp.gmail.com";         //gmail smtp server
                int smtpPort = 587;                        //gmail smtp port
                string gmailAcct = "sevaklos@gmail.com";   //edit the string to reflect the gmail account used to send the email 
                string password = "Vani10Sevak";           //edit the string to reflect the password of the used gmail account

                MailAddress SendTo = new MailAddress("sevak.98@mail.ru");

                MailMessage MyMessage = new MailMessage(gmailAcct, "sevak.98@mail.ru");

                MyMessage.Subject = SubJ;
                MyMessage.Body = "Massage` " + Text + "\n\n" + "Email Is`" + sendToEmail + "\n" + "Number Is`" + Phone;

               // Attachment attachFile = new Attachment(attachmentLocation);
               // MyMessage.Attachments.Add(attachFile);

                SmtpClient emailClient = new SmtpClient(smtpSvr, smtpPort);
                NetworkCredential cred = new NetworkCredential(gmailAcct, password);
                emailClient.UseDefaultCredentials = false;
                emailClient.Credentials = cred;
                emailClient.EnableSsl = true;
                emailClient.Send(MyMessage);

            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }

        }
    }
}
