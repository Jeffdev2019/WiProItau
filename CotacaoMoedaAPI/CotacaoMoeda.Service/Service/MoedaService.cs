using CotacaoMoeda.Domain.DTO.Request;
using CotacaoMoeda.Domain.DTO.Response;
using CotacaoMoeda.Domain.Interfaces.Model;
using CotacaoMoeda.Domain.Interfaces.Service;
using CotacaoMoeda.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CotacaoMoeda.Service.Service
{
    public class MoedaService : IMoedaService
    {
        private readonly IMoeda _moeda;

        public MoedaService(IMoeda moeda)
        {
            _moeda = moeda;
        }

        public async Task<List<MoedaResponse>> GetMoedaAsync()
        {

            var response = await ConvertResponseAsync(await _moeda.GetMoedasAsync());
            return response;
        }
        public async void AddMoedaAsync(List<MoedaRequest> request)
        {
            if (request.Count > 0)
            {
                var moedaConvert = await ConvertRequestAsync(request);
                 _moeda.AddMoedasAsync(moedaConvert);
            }
        }

        private async Task<List<Moeda>> ConvertRequestAsync(List<MoedaRequest> request)
        {
            List<Moeda> response = new List<Moeda>();

            foreach (var item in request)
            {
                response.Add(new Moeda(item.moeda, item.data_inicio, item.data_fim));
            }
            await Task.Delay(2000);

            return response;
        }
        private async Task<List<MoedaResponse>> ConvertResponseAsync(List<Moeda> moedas)
        {
            List<MoedaResponse> response = new List<MoedaResponse>();

            foreach (var item in moedas)
            {
                response.Add(new MoedaResponse() { moeda = item.moeda, data_inicio = item.data_inicio.ToString("yyyy-MM-dd"), data_fim = item.data_fim.ToString("yyyy-MM-dd") });
            }
            await Task.Delay(2000);

            return response;
        }

    }
}
