using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace AirTicket
{
    public class AirTicketControll
    {
        public  String post(String url, Object o, WebHeaderCollection webHeader)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            var postData = JsonConvert.SerializeObject(o);
            var data = Encoding.UTF8.GetBytes(postData);

            request.Headers = webHeader;
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36";

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            response.Close();
            return responseString;
        }

        public String postJson(String url, String jsonData, WebHeaderCollection webHeader)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            var data = Encoding.UTF8.GetBytes(jsonData);

            request.Headers = webHeader;
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36";

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            response.Close();
            return responseString;
        }

        public String get(String url, WebHeaderCollection webHeader)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Headers = webHeader;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            response.Close();
            return responseString;
        }

        public void sendEmail(EmailObject emailObject)
        {
            SmtpClient client = new SmtpClient(emailObject.smtpServer, emailObject.emailPort);

            //client.Port = emailObject.emailPort;
            //client.Host = emailObject.smtpServer;
            client.EnableSsl = true;
            client.Timeout = emailObject.emailSendTimeout;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(emailObject.emailUserName,emailObject.emailPassword);

            MailMessage mm = new MailMessage();

            mm.To.Add(emailObject.emailTo);
            mm.From = new MailAddress(emailObject.emailUserName);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            mm.Subject = emailObject.emailSubject;
            mm.Body = emailObject.emailContent;
            client.Send(mm);
            client.Dispose();
        }
    }
}
