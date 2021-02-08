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
        public async Task<string> AddMoedaAsync(List<MoedaRequest> request)
        {
            try
            {
                if (request.Count > 0)
                {

                    var moedaConvert = await ConvertRequestAsync(request);
                    foreach (var item in moedaConvert)
                    {
                        if (!validaDatas(item.data_inicio, item.data_fim))
                        {
                            throw new Exception("A data_inicio nao pode ser menor que a data_fim.");
                        }
                    }
                    _moeda.AddMoedasAsync(moedaConvert);
                    return "Sucesso";
                }
                return "Request Vazio";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private bool validaDatas(DateTime ini, DateTime fim)
        {
            if (ini < fim)
            {
                return true;
            }
            return false;
        }

        private async Task<List<Moeda>> ConvertRequestAsync(List<MoedaRequest> request)
        {
            try
            {
                List<Moeda> response = new List<Moeda>();

                foreach (var item in request)
                {
                    if (item.data_inicio.Length < 10 || item.data_fim.Length < 10)
                    {
                        throw new FormatException();
                    }
                    response.Add(new Moeda(item.moeda, DateTime.Parse(item.data_inicio), DateTime.Parse(item.data_fim)));

                }
                await Task.Delay(2000);

                return response;
            }
            catch (FormatException)
            {

                throw new FormatException("data_inicio ou data_fim esta no Formato errado ou contem algum caractere invalido.");
            }
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
