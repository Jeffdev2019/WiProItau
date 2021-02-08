using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace CotacaoMoedaConsole
{
    class Program
    {
        private static Queue<Moeda> Moedas;
        static void InicializaFila()
        {
            Moedas = new Queue<Moeda>();
        }

        static  void Main(string[] args)
        {
            InicializaFila();

            GetMoeda().Wait();

            while (Moedas.Count > 0)
            {
                new Thread(NovaThread).Start();

                Thread.Sleep(5000);

                GetMoeda().Wait();
            }
        }

        static void NovaThread()
        {
            var str = Moedas.Dequeue();
            Console.WriteLine("\nMoeda: " + str.moeda + "\nData Inicio: " + str.data_inicio + "\nData Fim: " + str.data_fim );
            Thread.Sleep(100);
        }

        static async Task GetMoeda()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/CotacaoMoeda");

                if (response.IsSuccessStatusCode)
                {  //GET
                    var produto = await response.Content.ReadAsStringAsync();
                    if (produto.Contains("Nao ha Objetos na Fila"))
                    {
                        Console.WriteLine("\nNão há Objeto na Fila, Rotina Parou");
                    }
                    else
                    {
                        List<Moeda> moeda = JsonConvert.DeserializeObject<List<Moeda>>(produto);
                        if (moeda.Count > 0)
                        {
                            var obj = moeda.FirstOrDefault();
                            Moedas.Enqueue(new Moeda() { moeda = obj.moeda, data_inicio = obj.data_inicio, data_fim = obj.data_fim });
                        }
                    }
                    
                }
            }
        }
    }
}
