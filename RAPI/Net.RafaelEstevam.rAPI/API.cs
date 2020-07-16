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
        
        public enum Services
        {
            CNPJ,
            CEP
        }

        public API(string ApiKey)
        {
            this.key = ApiKey;
        }
        string key;
        WebClient wc;

        [DebuggerStepThrough]
        protected string QueryContent(Services service, string contentValue)
        {
            if (!contentValue.Any(c => char.IsDigit(c))) throw new ArgumentException(); 

            if (wc == null) wc = new WebClient();
            wc.Headers["Apikey"] = key;

            try
            {
                return wc.DownloadString(address_cnpj.Replace("[CNT]", contentValue));
            }
            catch (WebException ex)
            {
                string errorContent = null;
                var stream = ex.Response.GetResponseStream();
                if (stream != null)
                {
                    using (TextReader tr = new StreamReader(stream))
                    {
                        errorContent = tr.ReadToEnd();
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
