using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CotacaoMoeda.Domain.Interfaces.CSV
{
    public interface IMoedaCSV
    {
        void CriarFileAsync();
        Task<bool> VerificaFileAsync();
        Task<List<string>> LerFileAsync();
        void AddFileAsync(List<string> Linha);

    }
}
