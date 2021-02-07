using CotacaoMoeda.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CotacaoMoeda.Domain.Interfaces.Model
{
    public interface IMoeda
    {
        public Task<List<Moeda>> GetMoedasAsync();

        public void AddMoedasAsync(List<Moeda> moeda);
    }
}
