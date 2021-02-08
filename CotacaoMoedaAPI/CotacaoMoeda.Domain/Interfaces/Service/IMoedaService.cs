using CotacaoMoeda.Domain.DTO.Request;
using CotacaoMoeda.Domain.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CotacaoMoeda.Domain.Interfaces.Service
{
    public interface IMoedaService 
    {
        Task<List<MoedaResponse>> GetMoedaAsync();
        Task<string> AddMoedaAsync(List<MoedaRequest> request);
    }
}
