using CotacaoMoeda.Domain.DTO.Request;
using CotacaoMoeda.Domain.DTO.Response;
using CotacaoMoeda.Domain.Interfaces.Model;
using CotacaoMoeda.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace CotacaoMoeda.Service.Service
{
    public class MoedaService : IMoedaService
    {
        private readonly IMoeda _moeda;

        public MoedaService(IMoeda moeda)
        {
            _moeda = moeda;
        }

        public List<MoedaResponse> GetMoeda()
        {
            return  new List<MoedaResponse>()
            {
                new MoedaResponse(){ moeda = "USD", data_fim = "2020-12-01", data_inicio = "2010-01-01" },
                new MoedaResponse(){ moeda = "EUR", data_fim = "2020-12-01", data_inicio = "2010-01-01" },
                new MoedaResponse(){ moeda = "JPY", data_fim = "2000-03-11", data_inicio = "2000-03-30" }
            };
        }
        public string AddMoeda(List<MoedaRequest> request)
        {
            if (request.Count > 0)
               return "Add Com Sucesso.";

            return "Não Add.";
        }
    }
}
