using MailKit.Security;
using Microsoft.Identity.Client;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace NetMailSample.Common
{
    
    internal class OAuth
    {
        
        public async static Task<AuthenticationResult> OAuthToken(string AppID, string TenantID)
        {
            
            var options = new PublicClientApplicationOptions
            {
                ClientId = AppID,
                TenantId = TenantID,
                RedirectUri = "http://localhost"
            };

            var publicClientApplication = PublicClientApplicationBuilder.CreateWithApplicationOptions(options).Build();

            var scopes = new string[]{"email",
                                      "offline_access",
                                      "https://outlook.office.com/SMTP.Send" // SMTP permission scope string
                                     };
            var accounts = await publicClientApplication.GetAccountsAsync();
            //AuthenticationResult result;
            try
            {
                var authToken = await publicClientApplication.AcquireTokenSilent(scopes, accounts.FirstOrDefault()).ExecuteAsync();
                return authToken;
            }
            catch (MsalUiRequiredException)
            {
                var authToken = await publicClientApplication.AcquireTokenInteractive(scopes).ExecuteAsync();
                return authToken;
            }
            finally
            {
                
            }
                

            //Test refresh token
            //var RefehAuthToken = await publicClientApplication.AcquireTokenSilent(scopes, authToken.Account).ExecuteAsync(cancellationToken);

            //var oauth2 = new SaslMechanismOAuth2(authToken.Account.Username, authToken.AccessToken);

            //using (var client = new SmtpClient())
            //{
            //    await client.ConnectAsync("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            //    await client.AuthenticateAsync(oauth2);

            //    var message = new MimeMessage();
            //    message.From.Add(MailboxAddress.Parse(authToken.Account.Username));
            //    message.To.Add(MailboxAddress.Parse("toEmail"));
            //    message.Subject = "Test";
            //    message.Body = new TextPart("plain") { Text = @"Oscar Testar" };

            //    await client.SendAsync(message, cancellationToken);

            //    await client.DisconnectAsync(true);
            //}




        }
    }
}
