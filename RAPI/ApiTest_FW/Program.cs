using Net.RafaelEstevam.rAPI;
using System.Diagnostics;

namespace ApiTest_FW
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = "KEY KEY KEY";
            CnpjAPI cnpj = new CnpjAPI(apiKey);
            var retornoCnpj = cnpj.Buscar("17189722000139");

            CepAPI cep = new CepAPI(apiKey);
            var retornoCep = cep.Buscar("13140291");

            retornoCep = retornoCep;
        }
    }
}