using CotacaoMoeda.Domain.CSV;
using CotacaoMoeda.Domain.Interfaces.CSV;
using CotacaoMoeda.Domain.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotacaoMoeda.Domain.Model
{
    public class Moeda : IMoeda
    {
        private IMoedaCSV _moedaCSV;
        public Moeda(string moeda, DateTime data_inicio, DateTime data_fim)
        {
            this.moeda = moeda;
            this.data_inicio = data_inicio;
            this.data_fim = data_fim;
        }
        public Moeda(IMoedaCSV moedaCSV)
        {
            _moedaCSV = moedaCSV;
        }
        public Moeda()
        {

        }

        public string moeda { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime data_inicio { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime data_fim { get; set; }

        public async Task<List<Moeda>> GetMoedasAsync()
        {
            List<Moeda> response = new List<Moeda>();
            if (await _moedaCSV.VerificaFileAsync())
            {
                var linhas = await _moedaCSV.LerFileAsync();

                if (linhas.Count > 0)
                {
                    string[] moeda = linhas.FirstOrDefault().Split(";");

                    response.Add(new Moeda(moeda[0], DateTime.Parse(moeda[1]), DateTime.Parse(moeda[2])));
                }

            }
            return response;
        }
        public async void AddMoedasAsync(List<Moeda> moedas)
        {
            if (!await _moedaCSV.VerificaFileAsync())
            {
                _moedaCSV.CriarFileAsync();
            }
            List<string> Linha = new List<string>();
            foreach (var item in moedas)
            {
                Linha.Add(item.moeda + ";" + item.data_inicio.ToString("yyyy-MM-dd") + ";" + item.data_fim.ToString("yyyy-MM-dd"));
            }
            _moedaCSV.AddFileAsync(Linha);

        }
    }
}
