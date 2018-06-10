using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Dogs.Email
{
    public class SendEmailCod
    {
        public void sendEmail(string sendToEmail, int Text)
        {
            try
            {
                string smtpSvr = "smtp.gmail.com";         //gmail smtp server
                int smtpPort = 587;                        //gmail smtp port
                string gmailAcct = "sevaklos@gmail.com";   //edit the string to reflect the gmail account used to send the email 
                string password = "Vani10Sevak";           //edit the string to reflect the password of the used gmail account

                MailAddress SendTo = new MailAddress(sendToEmail);

                MailMessage MyMessage = new MailMessage(gmailAcct, sendToEmail);

                MyMessage.Subject = "ZIBADOGS";
                MyMessage.Body = "<b>Ձեր կոդը ` " + Text +"</b>";
                MyMessage.IsBodyHtml = true;
                

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
