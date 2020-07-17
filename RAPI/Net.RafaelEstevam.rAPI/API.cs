using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;

namespace Net.RafaelEstevam.rAPI
{
    public class API
    {
        private readonly string address_cnpj = "https://webserv.rafaelestevam.net/CNPJs.php?cnpj=[CNT]";
        private readonly string address_cep = "https://webserv.rafaelestevam.net/CEPs.php?cep=[CNT]";

        public enum Services
        {
            CNPJ,
            CEP
        }

        public API(string ApiKey)
        {
            this.key = ApiKey;
        }

        readonly string key;
        WebClient wc;

#if !DEBUG
        [DebuggerStepThrough]
#endif
        protected string QueryContent(Services service, string contentValue)
        {
            if (!contentValue.Any(c => char.IsDigit(c))) throw new ArgumentException(); 

            if (wc == null) wc = new WebClient();
            wc.Headers["Apikey"] = key;

            try
            {
#if B_FW
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
#endif
                string url = service == Services.CNPJ ? address_cnpj : address_cep;

                return wc.DownloadString(url.Replace("[CNT]", contentValue));
            }
            catch (WebException ex)
            {
                string errorContent = null;
                if (ex.Response != null)
                {
                    var stream = ex.Response.GetResponseStream();
                    if (stream != null)
                    {
                        using (TextReader tr = new StreamReader(stream))
                        {
                            errorContent = tr.ReadToEnd();
                        }
                    }
                }

                if (errorContent != null)
                {
                    throw new Exception($"API Error: {errorContent}");
                }

                throw;
            }
            catch
            {
                throw;
            }
        }

    }
}
