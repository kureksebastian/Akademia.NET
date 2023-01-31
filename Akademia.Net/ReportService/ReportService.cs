using Cipher;
using EmailSender;
using ReportService.Core;
using ReportService.Core.Repository;
using System;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;

namespace ReportService
{
    public partial class ReportService : ServiceBase
    {
        private readonly int _sendHour;
        private readonly int _intervalInMinutes;
        private readonly bool _sendReports;
        private readonly Timer _timer;
        private ErrorRepository _errorRepository = new ErrorRepository();
        private ReportRepository _reportRepository = new ReportRepository();
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private Email _email;
        private GenerateHtmlEmail _htmlEmail = new GenerateHtmlEmail();
        private string _emailReciever;
        private StringCipher _stringCipher = new StringCipher("51B9521D-3458-4BEB-8BC8-079F7C8911D7");

        public ReportService()
        {
            InitializeComponent();          

            try
            {
                _emailReciever = ConfigurationManager.AppSettings["RecieverEmail"];
                _sendHour = int.Parse(ConfigurationManager.AppSettings["SendHour"]);
                _intervalInMinutes = int.Parse(ConfigurationManager.AppSettings["SendHour"]);
                _sendReports = bool.Parse(ConfigurationManager.AppSettings["SendReports"]);
                _timer = new Timer(_intervalInMinutes * 60000);

                _email = new Email(new EmailParams
                {
                    HostSmtp = ConfigurationManager.AppSettings["HostSmtp"],
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
                    EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]),
                    SenderName = ConfigurationManager.AppSettings["SenderName"],
                    SenderEmail = ConfigurationManager.AppSettings["SenderEmail"],
                    SenderEmailPassword = DecryptSenderEmailPassword(),
                });
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private string DecryptSenderEmailPassword()
        {
            var encryptedPassword = ConfigurationManager.AppSettings["SenderEmailPassword"];
            if (encryptedPassword.StartsWith("encrypt:"))
            {
                encryptedPassword = _stringCipher
                    .Encrypt(encryptedPassword.Replace("encrypt:", ""));

                var configFile = ConfigurationManager.OpenExeConfiguration
                    (ConfigurationUserLevel.None);
                configFile.AppSettings.Settings["SenderEmailPassword"].Value = encryptedPassword;
                configFile.Save();
            }

            return _stringCipher.Decrypt(encryptedPassword);
        }

        protected override void OnStart(string[] args)
        {
            _timer.Elapsed += DoWork;
            _timer.Start();
            Logger.Info("Service started.....");
        }

        private async void DoWork(object sendre, ElapsedEventArgs e)
        {
            try
            {
                await SendErros();
                await SendReport();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private async Task SendErros()
        {
            var errors = _errorRepository.GetLastErrors(_intervalInMinutes);

            if (errors == null || !errors.Any())
                return;

            await _email.Send("Błędy w aplikacji", 
                _htmlEmail.GenerateErrors(errors, _intervalInMinutes), 
                _emailReciever);

            Logger.Info("Error sent.");            
        }

        private async Task SendReport()
        {
            if (!_sendReports)
                return;

            var actualHour = DateTime.Now.Hour;

            if (actualHour < _sendHour)
                return;

            var report = _reportRepository.GetLastNotSentReport();
            if (report == null)
                return;

            await _email.Send("Raport dobowy",
                _htmlEmail.GenerateReport(report),
                _emailReciever);

            _reportRepository.ReportSent(report);
            Logger.Info("Report sent.");
        }

        protected override void OnStop()
        {
            Logger.Info("Service stopped.....");
        }
    }
}
