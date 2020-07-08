using System;

namespace HttpClientHelper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Iniciando a aplicação");

            var request = new HttpClientHelper("https://viacep.com.br/ws/07263540/");
            var opr = request.Get<Endereco>("json").Result;
            if (opr.Success)
            {
                System.Console.WriteLine(opr.Response.Bairro);
            }
            
            System.Console.ReadLine();
        }
    }
    public class Endereco
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string UF { get; set; }
    }
}
