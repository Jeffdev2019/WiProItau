using CotacaoMoeda.Domain.Interfaces.CSV;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotacaoMoeda.Domain.CSV
{
    public  class MoedaCSV : IMoedaCSV
    {
        IConfiguration Configuration { get; }
        private string folder;

        public MoedaCSV(IConfiguration configuration)
        {
            Configuration = configuration;
            folder = Configuration["PathCSV"];
        }

        public async void CriarFileAsync()
        {
            File.Create(Path.Combine(folder, "FilaMoeda.csv")).Dispose();
            await Task.Delay(2000);
        }

        public async Task<bool> VerificaFileAsync()
        {
            var response = File.Exists(folder + "\\FilaMoeda.csv");
            await Task.Delay(2000);

            return response;
        }

        public async Task<List<string>> LerFileAsync()
        {
            List<string> Response = new List<string>();

            var Arquivo = await File.ReadAllLinesAsync(folder + "\\FilaMoeda.csv");

            foreach (var item in Arquivo)
            {
                Response.Add(item);
            }

            await File.WriteAllLinesAsync(folder + "\\FilaMoeda.csv", Arquivo.Take(Arquivo.Length - 1));


            return Response;
        }

        public async void AddFileAsync(string linha)
        {
            await File.WriteAllTextAsync(folder + "\\FilaMoeda.csv", linha);
            await Task.Delay(2000);
        }
    }
}
