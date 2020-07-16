using Net.RafaelEstevam.rAPI;
using System;

namespace ApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CnpjAPI api = new CnpjAPI("");
            var retorno = api.Buscar("17189722000139");
            retorno = retorno;
        }
    }
}
