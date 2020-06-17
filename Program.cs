using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExemploRefit.API
{
    class Program
    {
        static async Task Main(string[] args)
        {
        try                                         
            {
                var cepClient = RestService.For<ICepApiService>("http://www.viacep.com.br");
                Console.WriteLine("Informe seu cep:");
                string cepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Consultando informações do Cep: " + cepInformado);
                var address = await cepClient.GetAddressAsync(cepInformado);
                Console.Write($"\nLogradouro:{address.Logradouro}," +
                    $"\nBairro: {address.Bairro}," +
                    $"\nCidade: {address.Localidade}");
                
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro na consulta de cep: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
