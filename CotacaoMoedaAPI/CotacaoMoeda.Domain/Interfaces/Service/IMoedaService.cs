using CotacaoMoeda.Domain.DTO.Request;
using CotacaoMoeda.Domain.DTO.Response;
using System.Collections.Generic;

namespace CotacaoMoeda.Domain.Interfaces.Service
{
    public interface IMoedaService 
    {
        public List<MoedaResponse> GetMoeda();
        public string AddMoeda(List<MoedaRequest> request);
    }
}
