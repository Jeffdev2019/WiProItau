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
            Dictionary<string, string> Linhas = new Dictionary<string, string>();
            List<string> Response = new List<string>();
            List<string> file = new List<string>();

            var Arquivo = await File.ReadAllLinesAsync(folder + "\\FilaMoeda.csv");
            int i = 0;
            foreach (var item in Arquivo)
            {
                Linhas.Add(i.ToString(), item);
                i++;
            }
            foreach (var item in Linhas)
            {
                Response.Add(item.Value);
                if (!Equals(item.Key, "0"))
                {
                    file.Add(item.Value);
                }
            }

            await File.WriteAllLinesAsync(folder + "\\FilaMoeda.csv", file.Take(Arquivo.Length - 1));


            return Response;
        }

        public async void AddFileAsync(List<string> linhas)
        {
            List<string> file = new List<string>();
            var Arquivo = await File.ReadAllLinesAsync(folder + "\\FilaMoeda.csv");
            foreach (var item in Arquivo)
            {
                file.Add(item);
            }
            foreach (var linha in linhas)
            {
                file.Add(linha);
            }
            
            
            await File.WriteAllLinesAsync(folder + "\\FilaMoeda.csv", file.Take(file.Count + 1));

        }
    }
}
