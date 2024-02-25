using Application.Services.Setting;
using MimeKit;

using MailKit.Net.Smtp;
using Application.ViewModels.Sender;

namespace Application.Services.Sender
{
    public class Sender:ISender
    {
        private readonly ISetting _setting;

        public Sender(ISetting setting)
        {
            _setting = setting;
        }
        public async Task SendAsync(SenderViewModel model)
        {
            var settingMail = await _setting.GetSetting();
            if (settingMail.ActiveMailService == true)
            {
                try
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Sender Name", settingMail.MailSender));
                    message.To.Add(new MailboxAddress("Receiver Name", settingMail.MailReceiver));
                    message.Subject = model.Subject;

                    message.Body = new TextPart("plain")
                    {
                        Text = model.Body
                    };
        
                    using var client = new SmtpClient();
                    await client.ConnectAsync(settingMail.MailHost, settingMail.MailHostPort, false);
                    await client.AuthenticateAsync(settingMail.SmtpUserName, settingMail.SmtpPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                catch (Exception e)
                {
                  
                }
            }
            
        }
    }
}
