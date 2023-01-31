using Cipher;
using EmailSender;
using ReportService.Core;
using ReportService.Core.Domains;
using System;
using System.Collections.Generic;

namespace ReportService.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            var stringCipher = new StringCipher("1");
            var encryptedPassword = stringCipher.Encrypt("hasło");
            var decryptedPassword = stringCipher.Decrypt(encryptedPassword);

            Console.WriteLine(encryptedPassword);
            Console.WriteLine(decryptedPassword);

            Console.ReadLine();

            return;


            var emailReciever = "kureksebastian@gmail.com";
            var htmlEmail = new GenerateHtmlEmail();

            var email = new Email(new EmailParams
            {
                HostSmtp = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                SenderName = "Sebo",
                SenderEmail = "sebookk@gmail.com",
                SenderEmailPassword = "xtuykgkbgmfyalgk"
            });

            var report = new Report
            {
                Id = 1,
                Title = "R/1/2023",
                Date = new DateTime(2023, 1, 1, 12, 0, 0),
                Position = new List<ReportPostion>
                {
                    new ReportPostion
                    {
                        Id = 1,
                        ReportId = 1,
                        Title = "Position 1",
                        Description = "Description 1",
                        Value = 34.01m,
                    },
                    new ReportPostion
                    {
                        Id = 2,
                        ReportId = 1,
                        Title = "Position 2",
                        Description = "Description 2",
                        Value = 44.01m,
                    },
                    new ReportPostion
                    {
                        Id = 3,
                        ReportId = 1,
                        Title = "Position 3",
                        Description = "Description 3",
                        Value = 14.99m,
                    },
                }
            };

            var errors = new List<Error>
            {
                new Error {Id = 1, Message = "Bład 1", Date = DateTime.Now},
                new Error {Id = 2, Message = "Bład 2", Date = DateTime.Now},
            };

            Console.WriteLine("Wysyłanie email Raport dobowy");

            email.Send("Raport dobowy",
                htmlEmail.GenerateReport(report),
                emailReciever).Wait();

            Console.WriteLine("Wysłano raport dobowy");

            Console.WriteLine("Wysyłanie email Błędy w aplikacji");
            email.Send("Błędy w aplikacji",
                htmlEmail.GenerateErrors(errors, 10),
                emailReciever).Wait();

            Console.WriteLine("Wysłano raport błędów");

        }
    }
}
