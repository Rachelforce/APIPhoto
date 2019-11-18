using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new file();
            while(true)
            {
                if(file.isFile())
                file.MailSender();
            }
        }

    }

    
        class file
        {
            readonly string pathToMail = @"C:\Test\Test.txt";
            readonly string pathToPhoto = @"C:\Test\Test.jpg";
        readonly string pathToServer = @"C:\Test\Server.txt";
        readonly string pathToLogin = @"C:\Test\login.txt";
        readonly string pathToPassword = @"C:\Test\Password.txt";

            public bool isFile()
            {
                FileInfo fileInfMail = new FileInfo(pathToMail);
                return fileInfMail.Exists;
            }

            

            public string ReadMailFromFile()
            {
                FileInfo fileInfMail = new FileInfo(pathToMail);

            try
            {
                StreamReader Mail = new StreamReader(pathToMail);
                string mail = Mail.ReadLine();
                Mail.Close();
                fileInfMail.Delete();

                return mail;
            }
            catch
            {
                Console.WriteLine("Okey");
                return null;
            }

            }




            public void MailSender()
            {
            StreamReader serverR = new StreamReader(pathToServer);
            StreamReader loginR = new StreamReader(pathToLogin);
            StreamReader passwordR = new StreamReader(pathToPassword);
            string server = serverR.ReadLine();
            string login = loginR.ReadLine();
            string password = passwordR.ReadLine();
            MailAddress from = new MailAddress(login, "тут можно написать все что угодно");
                MailAddress to = new MailAddress(ReadMailFromFile());
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Тест";
                message.Body = "! Ты пидор!!!";
                message.IsBodyHtml = false;
                message.Attachments.Add(new Attachment(pathToPhoto));
                SmtpClient smtp = new SmtpClient(server, 587);
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(login, password);
                smtp.EnableSsl = true;
                smtp.Send(message);


            }
        }
    }



