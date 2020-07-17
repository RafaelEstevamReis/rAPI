using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Net.RafaelEstevam.rAPI
{
    public sealed class CepAPI : API
    {
        public CepAPI(string ApiKey)
           : base(ApiKey)
        { }
        /// <summary>
        /// Buscar CEP, com ou sem formatação de máscara
        /// </summary>
        /// <param name="CEP">CEP com ou sem máscara</param>
        /// <returns>Dados sobre o CEP</returns>
        public DadosCEP Buscar(string CEP)
        {
            CEP = CEP
                .Replace(".", "")
                .Replace("-", "");

            if (CEP.Length != 8) throw new ArgumentException("CEP inválido");
            if (!CEP.Any(c => char.IsDigit(c))) throw new ArgumentException("CEP inválido");

            var s = new XmlSerializer(typeof(DadosCEP));
            using (TextReader reader = new StringReader(QueryContent(Services.CEP, CEP)))
            {
                return (DadosCEP)s.Deserialize(reader);
            }
        }
    }
}
