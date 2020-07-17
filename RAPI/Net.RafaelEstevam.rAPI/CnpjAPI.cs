using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace Net.RafaelEstevam.rAPI
{
    public sealed class CnpjAPI : API
    {
        public CnpjAPI(string ApiKey)
            : base(ApiKey)
        { }
        /// <summary>
        /// Buscar CNPJ, com ou sem formatação de máscara
        /// </summary>
        /// <param name="CNPJ">CNPJ com ou sem máscara</param>
        /// <returns>Dados sobre o CNPJ</returns>
        public EmpresaCNPJ Buscar(string CNPJ)
        {
            CNPJ = CNPJ
                .Replace(".", "")
                .Replace("/", "")
                .Replace("-", "");

            if (CNPJ.Length != 14) throw new ArgumentException("CNPJ inválido");
            if (!CNPJ.Any(c => char.IsDigit(c))) throw new ArgumentException("CNPJ inválido");

            var s = new XmlSerializer(typeof(EmpresaCNPJ));
            using (TextReader reader = new StringReader(QueryContent(Services.CNPJ, CNPJ)))
            {
                return (EmpresaCNPJ)s.Deserialize(reader);
            }
        }
    }
}
